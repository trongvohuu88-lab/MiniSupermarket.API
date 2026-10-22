/*
 * Mo ta: Controller ADO.NET thuc thi Stored Procedure xuat bao cao ca ban
 */
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using MiniSupermarket.API.Models;
using System.Data;

namespace MiniSupermarket.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportsController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        // Dependency Injection lay chuoi ket noi tu appsettings.json
        public ReportsController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // =========================================================================
        // GET: api/reports/revenue-by-cashier
        // Chuc nang: Goi Stored Procedure sp_GetRevenueByCashier qua SqlDataReader
        // =========================================================================
        [HttpGet("revenue-by-cashier")]
        public IActionResult GetRevenueByCashier()
        {
            var reportList = new List<CashierRevenueDto>();
            string connectionString = _configuration.GetConnectionString("DefaultConnection")!;

            // 1. Khoi tao SqlConnection trong khoi using dam bao tu dong dong ket noi
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // 2. Gan CommandText la CHINH XAC ten Stored Procedure tren SQL Server
                using (SqlCommand command = new SqlCommand("sp_GetRevenueByCashier", connection))
                {
                    // 3. DIEM KHOA HOC QUAN TRONG: Thiet lap CommandType la StoredProcedure
                    // Neu thieu dong nay, SQL Server se hieu nham day la chuoi SQL thuong va bao loi cu phap!
                    command.CommandType = CommandType.StoredProcedure;

                    try
                    {
                        // 4. Mo ket noi vat ly toi SQL Server
                        connection.Open();

                        // 5. Thuc thi bang ExecuteReader(): Nhan ve luong du lieu forward-only
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            // 6. Vong lap doc tung dong ket qua cua Stored Procedure
                            while (reader.Read())
                            {
                                // Anh xa tung cot du lieu tu reader vao doi tuong DTO
                                var item = new CashierRevenueDto
                                {
                                    CashierUsername = reader["CashierUsername"].ToString() ?? string.Empty,
                                    TotalOrders = Convert.ToInt32(reader["TotalOrders"]),
                                    TotalRevenue = Convert.ToDecimal(reader["TotalRevenue"]),
                                    TotalPointsAwarded = reader["TotalPointsAwarded"] != DBNull.Value
                                        ? Convert.ToInt32(reader["TotalPointsAwarded"])
                                        : 0
                                };

                                reportList.Add(item);
                            }
                        } // reader tu dong Close() tai day
                    }
                    catch (SqlException ex)
                    {
                        // Bat loi neu quen tao Stored Procedure tren CSDL hoac sai chuoi ket noi
                        return StatusCode(500, new
                        {
                            success = false,
                            message = "Lỗi thực thi Stored Procedure trên SQL Server: " + ex.Message
                        });
                    }
                }
            } // connection tu dong Close() va Dispose() tai day

            // 7. Tra ve ma 200 OK kem danh sach bao cao da tong hop
            return Ok(new
            {
                success = true,
                generatedAt = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                totalCashiers = reportList.Count,
                grandTotalRevenue = reportList.Sum(x => x.TotalRevenue),
                data = reportList
            });
        }
    }
}

