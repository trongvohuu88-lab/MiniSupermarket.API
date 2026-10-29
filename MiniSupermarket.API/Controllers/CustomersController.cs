using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MiniSupermarket.API.Data;
using MiniSupermarket.API.Models;

namespace MiniSupermarket.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize] // Yêu cầu đăng nhập
    public class CustomersController : ControllerBase
    {
        private readonly SupermarketDbContext _context;

        public CustomersController(SupermarketDbContext context)
        {
            _context = context;
        }

        // 1. GET /api/customers - Lấy danh sách khách hàng (Admin & Cashier)
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customer>>> GetCustomers()
        {
            var customers = await _context.Customers
                .AsNoTracking()
                .OrderBy(c => c.CustomerId)
                .ToListAsync();

            return Ok(customers);
        }

        // GET /api/customers/paged?pageNumber=1&pageSize=5
        [HttpGet("paged")]
        public async Task<ActionResult<PagedResult<CustomerItemDto>>> GetPagedCustomers(
            [FromQuery] int pageNumber = 1,
            [FromQuery] int pageSize = 5)
        {
            if (pageNumber < 1) pageNumber = 1;
            if (pageSize < 1 || pageSize > 50) pageSize = 5;

            var query = _context.Customers
                .AsNoTracking()
                .OrderByDescending(c => c.RewardPoints)
                .ThenBy(c => c.CustomerId);

            var totalItems = await query.CountAsync();
            var totalPages = (int)Math.Ceiling((double)totalItems / pageSize);
            pageNumber = totalPages == 0 ? 1 : Math.Min(pageNumber, totalPages);

            var items = await query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .Select(c => new CustomerItemDto
                {
                    CustomerId = c.CustomerId,
                    CustomerName = c.CustomerName,
                    PhoneNumber = c.PhoneNumber,
                    RewardPoints = c.RewardPoints,
                    MembershipRank = c.MembershipRank
                })
                .ToListAsync();

            return Ok(new PagedResult<CustomerItemDto>
            {
                CurrentPage = pageNumber,
                PageSize = pageSize,
                TotalItems = totalItems,
                TotalPages = totalPages,
                Items = items
            });
        }

        // 2. GET /api/customers/{id} - Lấy chi tiết khách hàng (Admin & Cashier)
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Customer>> GetCustomer(int id)
        {
            var customer = await _context.Customers
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.CustomerId == id);

            if (customer == null)
                return NotFound(new { message = $"Không tìm thấy khách hàng có mã {id}." });

            return Ok(customer);
        }

        // 3. GET /api/customers/search?keyword=... - Tìm khách hàng (Admin & Cashier)
        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<Customer>>> SearchCustomers([FromQuery] string? keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
                return await GetCustomers();

            keyword = keyword.Trim();

            var results = await _context.Customers
                .AsNoTracking()
                .Where(c => c.CustomerName.Contains(keyword) || c.PhoneNumber.Contains(keyword))
                .OrderBy(c => c.CustomerName)
                .ToListAsync();

            return Ok(results);
        }

        // 4. POST /api/customers - Thêm mới khách hàng (Admin & Cashier)
        [HttpPost]
        public async Task<ActionResult<Customer>> PostCustomer(Customer customer)
        {
            bool phoneExists = await _context.Customers
                .AnyAsync(c => c.PhoneNumber == customer.PhoneNumber);

            if (phoneExists)
                return Conflict(new { message = "Số điện thoại này đã được đăng ký." });

            customer.CustomerId = 0;

            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCustomer),
                new { id = customer.CustomerId }, customer);
        }

        // 5. PUT /api/customers/{id} - Cập nhật thông tin (Chỉ Admin)
        [HttpPut("{id:int}")]
        [Authorize(Roles = "Admin,Cashier")]
        public async Task<IActionResult> PutCustomer(int id, Customer customer)
        {
            if (id != customer.CustomerId)
                return BadRequest(new { message = "Mã khách hàng trên URL và trong dữ liệu không khớp." });

            var existing = await _context.Customers.FindAsync(id);
            if (existing == null)
                return NotFound(new { message = $"Không tìm thấy khách hàng có mã {id}." });

            bool phoneUsed = await _context.Customers
                .AnyAsync(c => c.PhoneNumber == customer.PhoneNumber && c.CustomerId != id);

            if (phoneUsed)
                return Conflict(new { message = "Số điện thoại này đã thuộc về khách hàng khác." });

            existing.CustomerName = customer.CustomerName;
            existing.PhoneNumber = customer.PhoneNumber;
            existing.Address = customer.Address;
            existing.RewardPoints = customer.RewardPoints;
            existing.MembershipRank = customer.MembershipRank;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        // 6. DELETE /api/customers/{id} - Xóa khách hàng (Chỉ Admin)
        [HttpDelete("{id:int}")]
        [Authorize(Roles = "Admin,Cashier")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            var customer = await _context.Customers.FindAsync(id);
            if (customer == null)
                return NotFound(new { message = $"Không tìm thấy khách hàng có mã {id}." });

            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}