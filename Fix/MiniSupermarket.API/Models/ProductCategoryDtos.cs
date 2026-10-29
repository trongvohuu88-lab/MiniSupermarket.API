/*
 * Mô tả: Các lớp DTO dùng để nhận/trả dữ liệu Sản phẩm, Nhóm hàng và Vai trò qua mạng,
 *        không trả nguyên Entity CSDL ra ngoài.
 */
using System.ComponentModel.DataAnnotations;

namespace MiniSupermarket.API.Models
{
    // ===================== SẢN PHẨM =====================

    // DTO nhận dữ liệu khi THÊM sản phẩm
    public class ProductCreateDto
    {
        [Required(ErrorMessage = "Mã vạch không được để trống!")]
        [StringLength(50, ErrorMessage = "Mã vạch không vượt quá 50 ký tự!")]
        public string Barcode { get; set; } = string.Empty;

        [Required(ErrorMessage = "Tên sản phẩm không được để trống!")]
        [StringLength(150, ErrorMessage = "Tên sản phẩm không vượt quá 150 ký tự!")]
        public string ProductName { get; set; } = string.Empty;

        [Range(0.01, double.MaxValue, ErrorMessage = "Giá bán phải lớn hơn 0!")]
        public decimal Price { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Số lượng tồn kho không được âm!")]
        public int StockQuantity { get; set; }

        [StringLength(50)]
        public string? Unit { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Vui lòng chọn nhóm hàng hợp lệ!")]
        public int CategoryId { get; set; }
    }

    // DTO nhận dữ liệu khi SỬA sản phẩm (ProductId trong body là tùy chọn, nếu có phải khớp với URL)
    public class ProductUpdateDto : ProductCreateDto
    {
        public int? ProductId { get; set; }
    }

    // DTO trả về cho Client (kèm tên nhóm hàng, không trả Entity)
    public class ProductResponseDto
    {
        public int ProductId { get; set; }
        public string Barcode { get; set; } = string.Empty;
        public string ProductName { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
        public string? Unit { get; set; }
        public bool IsLowStock { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; } = string.Empty;
    }

    // ===================== NHÓM HÀNG =====================

    // DTO nhận dữ liệu khi THÊM / SỬA nhóm hàng
    public class CategoryRequestDto
    {
        [Required(ErrorMessage = "Tên nhóm hàng không được để trống!")]
        [StringLength(100, ErrorMessage = "Tên nhóm hàng không vượt quá 100 ký tự!")]
        public string CategoryName { get; set; } = string.Empty;

        [StringLength(255)]
        public string? Description { get; set; }
    }

    // DTO trả về cho Client
    public class CategoryResponseDto
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; } = string.Empty;
        public string? Description { get; set; }
    }

    // ===================== VAI TRÒ =====================

    // DTO nhận dữ liệu khi THÊM / SỬA vai trò
    public class RoleRequestDto
    {
        [Required(ErrorMessage = "Tên vai trò không được để trống!")]
        [StringLength(50, ErrorMessage = "Tên vai trò không vượt quá 50 ký tự!")]
        public string RoleName { get; set; } = string.Empty;

        [StringLength(255)]
        public string? Description { get; set; }
    }
}
