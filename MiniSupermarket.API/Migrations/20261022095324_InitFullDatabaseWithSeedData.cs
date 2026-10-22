using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MiniSupermarket.API.Migrations
{
    /// <inheritdoc />
    public partial class InitFullDatabaseWithSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 28);

            migrationBuilder.AlterColumn<int>(
                name: "RewardPoints",
                table: "Customers",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "Customers",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(15)",
                oldMaxLength: 15);

            migrationBuilder.AlterColumn<string>(
                name: "MembershipRank",
                table: "Customers",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldDefaultValue: "Chuẩn");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Categories",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CategoryName",
                table: "Categories",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    CashierUsername = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TotalItems = table.Column<int>(type: "int", nullable: false),
                    FinalAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    RewardPoints = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderId);
                    table.ForeignKey(
                        name: "FK_Orders_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Role = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetails",
                columns: table => new
                {
                    OrderDetailId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    LineTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetails", x => x.OrderDetailId);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 1,
                column: "Description",
                value: "Snack khoai tây, bánh quy bơ, kẹo trái cây");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 2,
                column: "Description",
                value: "Nước ngọt lon, nước khoáng thiên nhiên, trà xanh đóng chai");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 3,
                column: "Description",
                value: "Sữa tươi tiệt trùng, sữa đặc, sữa chua ăn, phô mai lát");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 4,
                column: "Description",
                value: "Mì ăn liền, hủ tiếu, phở khô, cháo gói dinh dưỡng");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 5,
                column: "Description",
                value: "Nước mắm cá cơm, hạt nêm, dầu ăn nguyên chất, muối i-ốt");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 6,
                columns: new[] { "CategoryName", "Description" },
                values: new object[] { "Đồ hộp & Chế biến sẵn", "Cá hộp sốt cà, thịt heo hầm hộp, pate gan, xúc xích ăn liền" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 7,
                columns: new[] { "CategoryName", "Description" },
                values: new object[] { "Hóa phẩm tẩy rửa", "Nước giặt xả, nước lau sàn nhà, nước rửa chén, bột tẩy" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 8,
                columns: new[] { "CategoryName", "Description" },
                values: new object[] { "Chăm sóc cá nhân", "Dầu gội đầu, sữa tắm dưỡng ẩm, kem đánh răng, xà phòng" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 9,
                columns: new[] { "CategoryName", "Description" },
                values: new object[] { "Đồ gia dụng tiện ích", "Màng bọc thực phẩm, túi rác sinh học, khăn giấy rút, pin tiểu" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 10,
                columns: new[] { "CategoryName", "Description" },
                values: new object[] { "Rau củ tươi sạch", "Cà chua bi, rau cải xanh, khoai tây, cà rốt Đà Lạt" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 11,
                columns: new[] { "CategoryName", "Description" },
                values: new object[] { "Thịt tươi & Thủy sản", "Thịt ba chỉ heo, ức gà phi lê, cá phi lê tươi sống" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 12,
                columns: new[] { "CategoryName", "Description" },
                values: new object[] { "Thực phẩm đông lạnh", "Bánh bao nhân thịt, há cảo hấp, cá viên, bò viên chiên" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 13,
                columns: new[] { "CategoryName", "Description" },
                values: new object[] { "Cà phê & Ngũ cốc", "Cà phê hòa tan 3in1, bột yến mạch, bột ngũ cốc dinh dưỡng" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 14,
                columns: new[] { "CategoryName", "Description" },
                values: new object[] { "Văn phòng phẩm mini", "Bút bi bấm, vở viết học sinh, kéo cắt giấy văn phòng" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 15,
                columns: new[] { "CategoryName", "Description" },
                values: new object[] { "Vật tư đóng gói POS", "Bao xốp quầy thu ngân, giấy in bill nhiệt k80, tem dán nhãn" });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 1,
                columns: new[] { "Address", "CustomerName", "MembershipRank", "PhoneNumber", "RewardPoints" },
                values: new object[] { "123 Lê Lợi, Quận 1, TPHCM", "Trần Văn Hoàng", "Bạc", "0903123456", 120 });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 2,
                columns: new[] { "Address", "CustomerName", "MembershipRank", "PhoneNumber", "RewardPoints" },
                values: new object[] { "45 Điện Biên Phủ, Quận Bình Thạnh, TPHCM", "Nguyễn Thị Kim Loan", "Vàng", "0918234567", 350 });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 3,
                columns: new[] { "Address", "CustomerName", "PhoneNumber", "RewardPoints" },
                values: new object[] { "88 Nam Kỳ Khởi Nghĩa, Quận 3, TPHCM", "Lê Minh Trí", "0977345678", 45 });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 4,
                columns: new[] { "Address", "CustomerName", "MembershipRank", "PhoneNumber" },
                values: new object[] { "102 Quang Trung, Quận Gò Vấp, TPHCM", "Phạm Hồng Nhung", "Bạch Kim", "0988456789" });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 5,
                columns: new[] { "Address", "CustomerName", "MembershipRank", "PhoneNumber", "RewardPoints" },
                values: new object[] { "15 Phan Xích Long, Quận Phú Nhuận, TPHCM", "Võ Thành Nam", "Chuẩn", "0909567890", 80 });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 6,
                columns: new[] { "Address", "CustomerName", "MembershipRank", "PhoneNumber", "RewardPoints" },
                values: new object[] { "234 Hoàng Văn Thụ, Quận Tân Bình, TPHCM", "Đỗ Thị Mỹ Duyên", "Bạc", "0933678901", 210 });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 7,
                columns: new[] { "Address", "CustomerName", "MembershipRank", "PhoneNumber", "RewardPoints" },
                values: new object[] { "312 Ba Tháng Hai, Quận 10, TPHCM", "Hoàng Quốc Bảo", "Chuẩn", "0944789012", 15 });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 8,
                columns: new[] { "Address", "CustomerName", "MembershipRank", "PhoneNumber", "RewardPoints" },
                values: new object[] { "56 Nguyễn Thị Thập, Quận 7, TPHCM", "Bùi Lan Hương", "Vàng", "0966890123", 410 });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 9,
                columns: new[] { "Address", "CustomerName", "MembershipRank", "PhoneNumber", "RewardPoints" },
                values: new object[] { "79 Kinh Dương Vương, Quận Bình Tân, TPHCM", "Đặng Tuấn Kiệt", "Chuẩn", "0922901234", 95 });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 10,
                columns: new[] { "Address", "CustomerName", "MembershipRank", "PhoneNumber", "RewardPoints" },
                values: new object[] { "18 Hoàng Diệu, Quận 4, TPHCM", "Ngô Thanh Vân", "Bạch Kim", "0971012345", 650 });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 11,
                columns: new[] { "Address", "CustomerName", "PhoneNumber", "RewardPoints" },
                values: new object[] { "405 Lê Văn Khương, Quận 12, TPHCM", "Trương Đình Trọng", "0982123456", 30 });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 12,
                columns: new[] { "Address", "CustomerName", "MembershipRank", "PhoneNumber", "RewardPoints" },
                values: new object[] { "123 Long Thuận, TP. Thủ Đức, TPHCM", "Lý Mỹ Lệ", "Bạc", "0904234567", 180 });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 13,
                columns: new[] { "Address", "CustomerName", "PhoneNumber", "RewardPoints" },
                values: new object[] { "67 Lũy Bán Bích, Quận Tân Phú, TPHCM", "Vũ Đức Thịnh", "0915345678", 290 });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 14,
                columns: new[] { "Address", "CustomerName", "MembershipRank", "PhoneNumber", "RewardPoints" },
                values: new object[] { "142 Phạm Thế Hiển, Quận 8, TPHCM", "Phan Bích Thủy", "Vàng", "0936456789", 480 });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 15,
                columns: new[] { "Address", "CustomerName", "MembershipRank", "PhoneNumber", "RewardPoints" },
                values: new object[] { "89 An Dương Vương, Quận 5, TPHCM", "Dương Gia Huy", "Chuẩn", "0977567890", 0 });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "OrderId", "CashierUsername", "CreatedDate", "CustomerId", "FinalAmount", "OrderCode", "RewardPoints", "TotalItems" },
                values: new object[,]
                {
                    { 1, "cashier01", new DateTime(2026, 10, 1, 8, 30, 0, 0, DateTimeKind.Unspecified), 1, 57000m, "HD20261001-001", 5, 3 },
                    { 2, "cashier01", new DateTime(2026, 10, 1, 9, 15, 0, 0, DateTimeKind.Unspecified), 2, 145000m, "HD20261001-002", 14, 2 },
                    { 3, "cashier02", new DateTime(2026, 10, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), 3, 45000m, "HD20261001-003", 4, 10 },
                    { 4, "cashier02", new DateTime(2026, 10, 2, 8, 45, 0, 0, DateTimeKind.Unspecified), 4, 138000m, "HD20261002-001", 13, 4 },
                    { 5, "cashier03", new DateTime(2026, 10, 2, 11, 20, 0, 0, DateTimeKind.Unspecified), 5, 69000m, "HD20261002-002", 6, 2 },
                    { 6, "cashier03", new DateTime(2026, 10, 3, 14, 10, 0, 0, DateTimeKind.Unspecified), 6, 53500m, "HD20261003-001", 5, 3 },
                    { 7, "cashier04", new DateTime(2026, 10, 3, 16, 40, 0, 0, DateTimeKind.Unspecified), 7, 30000m, "HD20261003-002", 3, 5 },
                    { 8, "cashier04", new DateTime(2026, 10, 4, 9, 5, 0, 0, DateTimeKind.Unspecified), 8, 155000m, "HD20261004-001", 15, 2 },
                    { 9, "cashier05", new DateTime(2026, 10, 4, 13, 30, 0, 0, DateTimeKind.Unspecified), 9, 48500m, "HD20261004-002", 4, 4 },
                    { 10, "cashier05", new DateTime(2026, 10, 5, 10, 50, 0, 0, DateTimeKind.Unspecified), 10, 168000m, "HD20261005-001", 16, 6 },
                    { 11, "cashier06", new DateTime(2026, 10, 5, 17, 15, 0, 0, DateTimeKind.Unspecified), 11, 36000m, "HD20261005-002", 3, 8 },
                    { 12, "cashier06", new DateTime(2026, 10, 6, 8, 20, 0, 0, DateTimeKind.Unspecified), 12, 108000m, "HD20261006-001", 10, 2 },
                    { 13, "cashier07", new DateTime(2026, 10, 6, 15, 0, 0, 0, DateTimeKind.Unspecified), 13, 78000m, "HD20261006-002", 7, 3 },
                    { 14, "cashier07", new DateTime(2026, 10, 7, 12, 10, 0, 0, DateTimeKind.Unspecified), 14, 125000m, "HD20261007-001", 12, 1 },
                    { 15, "cashier01", new DateTime(2026, 10, 7, 18, 45, 0, 0, DateTimeKind.Unspecified), 15, 40000m, "HD20261007-002", 4, 4 }
                });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 1,
                columns: new[] { "Price", "ProductName" },
                values: new object[] { 12500m, "Snack Khoai Tây O'Star Gói 60g" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 2,
                columns: new[] { "Price", "ProductName", "StockQuantity" },
                values: new object[] { 135000m, "Bánh Quy Bơ Danisa Hộp Thiếc 454g", 40 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 3,
                columns: new[] { "CategoryId", "Price", "ProductName", "StockQuantity" },
                values: new object[] { 1, 15000m, "Kẹo Dẻo Chupa Chups Hương Trái Cây 90g", 120 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 4,
                columns: new[] { "CategoryId", "Price", "ProductName", "StockQuantity" },
                values: new object[] { 1, 54000m, "Bánh Chocopie Orion Hộp 12 Cái", 60 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 5,
                columns: new[] { "CategoryId", "Price", "ProductName", "StockQuantity" },
                values: new object[] { 2, 10000m, "Nước Ngọt Coca Cola Lon 320ml", 320 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 6,
                columns: new[] { "CategoryId", "Price", "ProductName", "StockQuantity" },
                values: new object[] { 2, 6000m, "Nước Khoáng Thiên Nhiên Lavie Chai 500ml", 200 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 7,
                columns: new[] { "CategoryId", "Price", "ProductName", "StockQuantity" },
                values: new object[] { 2, 11000m, "Trà Xanh Không Độ Chai 455ml", 180 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 8,
                columns: new[] { "CategoryId", "Price", "ProductName", "StockQuantity" },
                values: new object[] { 2, 14500m, "Nước Tăng Lực Red Bull Lon 250ml", 150 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 9,
                columns: new[] { "CategoryId", "Price", "ProductName", "StockQuantity" },
                values: new object[] { 3, 34500m, "Sữa Tươi Tiệt Trùng Vinamilk Có Đường 1L", 85 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 10,
                columns: new[] { "CategoryId", "Price", "ProductName" },
                values: new object[] { 3, 39000m, "Phô Mai Con Bò Cười Hộp 8 Miếng" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 11,
                columns: new[] { "CategoryId", "Price", "ProductName", "StockQuantity" },
                values: new object[] { 3, 28000m, "Sữa Chua Ăn Vinamilk Có Đường Lốc 4 Hộp", 95 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 12,
                columns: new[] { "CategoryId", "Price", "ProductName", "StockQuantity" },
                values: new object[] { 3, 26000m, "Sữa Đặc Có Đường Ông Thọ Lon 380g", 110 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 13,
                columns: new[] { "CategoryId", "Price", "ProductName", "StockQuantity" },
                values: new object[] { 4, 4500m, "Mì Tôm Hảo Hảo Chua Cay Gói 75g", 500 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 14,
                columns: new[] { "CategoryId", "Price", "ProductName", "StockQuantity" },
                values: new object[] { 4, 8500m, "Phở Bò Đệ Nhất Gói 68g", 140 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 15,
                columns: new[] { "CategoryId", "Price", "ProductName", "StockQuantity" },
                values: new object[] { 4, 14000m, "Mì Trộn Tương Đen Koreno Gói 115g", 80 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 16,
                columns: new[] { "CategoryId", "Price", "ProductName" },
                values: new object[] { 5, 125000m, "Dầu Ăn Simply Nguyên Chất Can 2L" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 17,
                columns: new[] { "CategoryId", "Price", "ProductName", "StockQuantity" },
                values: new object[] { 5, 30000m, "Nước Mắm Nam Ngư Đệ Nhị Chai 900ml", 90 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 18,
                columns: new[] { "CategoryId", "Price", "ProductName", "StockQuantity" },
                values: new object[] { 5, 36000m, "Hạt Nêm Knorr Từ Thịt Thăn Gói 400g", 75 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 19,
                columns: new[] { "CategoryId", "Price", "ProductName", "StockQuantity" },
                values: new object[] { 6, 19000m, "Cá Nục Sốt Cà Ba Cô Gái Hộp 155g", 130 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 20,
                columns: new[] { "CategoryId", "Price", "ProductName", "StockQuantity" },
                values: new object[] { 7, 29000m, "Nước Rửa Chén Sunlight Chanh Chai 750g", 80 });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "FullName", "IsActive", "PasswordHash", "Role", "Username" },
                values: new object[,]
                {
                    { 1, "Nguyễn Quản Trị", true, "admin@123", "Admin", "admin" },
                    { 2, "Trần Cửa Hàng Trưởng", true, "manager@123", "Admin", "manager01" },
                    { 3, "Lê Thu Ngân 1", true, "cashier@123", "Cashier", "cashier01" },
                    { 4, "Phạm Thu Ngân 2", true, "cashier@123", "Cashier", "cashier02" },
                    { 5, "Hoàng Thu Ngân 3", true, "cashier@123", "Cashier", "cashier03" },
                    { 6, "Vũ Thu Ngân 4", true, "cashier@123", "Cashier", "cashier04" },
                    { 7, "Đỗ Thu Ngân 5", true, "cashier@123", "Cashier", "cashier05" },
                    { 8, "Ngô Thu Ngân 6", true, "cashier@123", "Cashier", "cashier06" },
                    { 9, "Bùi Thu Ngân 7", true, "cashier@123", "Cashier", "cashier07" },
                    { 10, "Đặng Thủ Kho 1", true, "wh@123", "Warehouse", "warehouse01" },
                    { 11, "Trương Thủ Kho 2", true, "wh@123", "Warehouse", "warehouse02" },
                    { 12, "Lý Kiểm Kê", true, "wh@123", "Warehouse", "warehouse03" },
                    { 13, "Mai Thu Ngân 8", true, "cashier@123", "Cashier", "cashier08" },
                    { 14, "Dương Thu Ngân 9", true, "cashier@123", "Cashier", "cashier09" },
                    { 15, "Hồ Nhân Viên Nghỉ Việc", false, "lock@123", "Cashier", "staff_lock" }
                });

            migrationBuilder.InsertData(
                table: "OrderDetails",
                columns: new[] { "OrderDetailId", "LineTotal", "OrderId", "ProductId", "Quantity", "UnitPrice" },
                values: new object[,]
                {
                    { 1, 10000m, 1, 5, 1, 10000m },
                    { 2, 12500m, 1, 1, 1, 12500m },
                    { 3, 34500m, 1, 9, 1, 34500m },
                    { 4, 135000m, 2, 2, 1, 135000m },
                    { 5, 10000m, 2, 5, 1, 10000m },
                    { 6, 45000m, 3, 13, 10, 4500m },
                    { 7, 138000m, 4, 9, 4, 34500m },
                    { 8, 34500m, 5, 9, 1, 34500m },
                    { 9, 34500m, 5, 9, 1, 34500m },
                    { 10, 53500m, 6, 4, 1, 53500m },
                    { 11, 30000m, 7, 6, 5, 6000m },
                    { 12, 125000m, 8, 16, 1, 125000m },
                    { 13, 30000m, 8, 17, 1, 30000m },
                    { 14, 30000m, 9, 3, 2, 15000m },
                    { 15, 11000m, 9, 7, 1, 11000m },
                    { 16, 108000m, 10, 4, 2, 54000m },
                    { 17, 60000m, 10, 18, 2, 30000m },
                    { 18, 125000m, 14, 16, 1, 125000m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_Barcode",
                table: "Products",
                column: "Barcode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Categories_CategoryName",
                table: "Categories",
                column: "CategoryName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_OrderId",
                table: "OrderDetails",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_ProductId",
                table: "OrderDetails",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerId",
                table: "Orders",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_OrderCode",
                table: "Orders",
                column: "OrderCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_Username",
                table: "Users",
                column: "Username",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderDetails");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Products_Barcode",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Categories_CategoryName",
                table: "Categories");

            migrationBuilder.AlterColumn<int>(
                name: "RewardPoints",
                table: "Customers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "Customers",
                type: "varchar(15)",
                maxLength: 15,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(15)",
                oldMaxLength: 15);

            migrationBuilder.AlterColumn<string>(
                name: "MembershipRank",
                table: "Customers",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "Chuẩn",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CategoryName",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 1,
                column: "Description",
                value: "Snack, bánh quy, kẹo dẻo");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 2,
                column: "Description",
                value: "Nước ngọt, nước khoáng, trà lon");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 3,
                column: "Description",
                value: "Sữa tươi, sữa chua, phô mai, bơ");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 4,
                column: "Description",
                value: "Mì, phở, cháo gói, hủ tiếu ăn liền");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 5,
                column: "Description",
                value: "Nước mắm, hạt nêm, dầu ăn, nước tương");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 6,
                columns: new[] { "CategoryName", "Description" },
                values: new object[] { "Gạo, Bột & Khô", "Gạo thơm, bột mỹ, miến, bún khô" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 7,
                columns: new[] { "CategoryName", "Description" },
                values: new object[] { "Đồ đóng hộp & Chế biến sẵn", "Cá hộp, thịt hộp, xúc xích, pate" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 8,
                columns: new[] { "CategoryName", "Description" },
                values: new object[] { "Hóa mỹ phẩm & Vệ sinh cá nhân", "Dầu gội, sữa tắm, kem đánh răng, xà phòng" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 9,
                columns: new[] { "CategoryName", "Description" },
                values: new object[] { "Chăm sóc nhà cửa", "Nước lau sàn, nước rửa chén, bột giặt" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 10,
                columns: new[] { "CategoryName", "Description" },
                values: new object[] { "Khăn giấy & Tã bỉm", "Giấy vệ sinh, khăn giấy khô/ướt, tã em bé" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 11,
                columns: new[] { "CategoryName", "Description" },
                values: new object[] { "Thực phẩm đông lạnh", "Cá viên, bò viên, chả giò, há cảo" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 12,
                columns: new[] { "CategoryName", "Description" },
                values: new object[] { "Kem & Đồ lạnh", "Kem que, kem hộp, đá viên đóng túi" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 13,
                columns: new[] { "CategoryName", "Description" },
                values: new object[] { "Bia & Đồ uống có cồn", "Bia lon, rượu nhẹ, cồn thực phẩm" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 14,
                columns: new[] { "CategoryName", "Description" },
                values: new object[] { "Cà phê & Cacao", "Cà phê hòa tan, cà phê rang xay, bột cacao" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 15,
                columns: new[] { "CategoryName", "Description" },
                values: new object[] { "Trái cây tươi Phố Thị", "Táo, chuối, cam, dưa hấu theo mùa" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName", "Description" },
                values: new object[,]
                {
                    { 16, "Rau củ & Nấm tươi", "Rau cải, cà chua, khoai tây, nấm rơm" },
                    { 17, "Thực phẩm tươi sống", "Thịt heo, thịt gà, trứng gia cầm" },
                    { 18, "Hạt & Đồ khô ăn kiêng", "Hạt điều, hạnh nhân, yến mạch, granola" },
                    { 19, "Bánh tươi Phố Thị", "Bánh mì sandwich, bánh giò, bánh bao" },
                    { 20, "Đồ dùng gia đình nhỏ", "Màng bọc thực phẩm, túi bóng, đũa muỗng" },
                    { 21, "Văn phòng phẩm tạp hóa", "Bút, tập học sinh, băng keo, kéo" },
                    { 22, "Chăm sóc thú cưng", "Thức ăn cho chó mèo, cát vệ sinh" },
                    { 23, "Sản phẩm Mẹ & Bé", "Sữa bột, bình sữa, rơ lưỡi, ty giả" },
                    { 24, "Thuốc không kê đơn & Y tế", "Khẩu y tế, bông gòn, dầu gió, C sủi" },
                    { 25, "Đồ kim khí & Điện gia dụng", "Pin AA/AAA, bóng đèn, ổ cắm, băng keo điện" },
                    { 26, "Trà thảo mộc & Đông y", "Trà atiso, trà hoa cúc, mủ trôm, hạt chia" },
                    { 27, "Nước mát Phố Thị", "Nước nha đam, sâm mát, rau má đóng chai" },
                    { 28, "Đồ ăn vặt truyền thống", "Bánh tráng trộn, cơm cháy, mứt tép" },
                    { 29, "Thời trang & Phụ kiện nhỏ", "Khẩu trang vải, tất chân, áo mưa tiện lợi" },
                    { 30, "Đồ lưu niệm & Quà tặng Phố Thị", "Túi vải Phố Thị, thiệp mừng, gấu bông nhỏ" }
                });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 1,
                columns: new[] { "Address", "CustomerName", "MembershipRank", "PhoneNumber", "RewardPoints" },
                values: new object[] { "12 Nguyễn Trãi, Q.1, TP.HCM", "Nguyễn Văn A", "Vàng", "0901122334", 150 });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 2,
                columns: new[] { "Address", "CustomerName", "MembershipRank", "PhoneNumber", "RewardPoints" },
                values: new object[] { "45 Lê Lợi, Q.1, TP.HCM", "Trần Thị B", "Bạc", "0918877665", 50 });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 3,
                columns: new[] { "Address", "CustomerName", "PhoneNumber", "RewardPoints" },
                values: new object[] { "88 CMT8, Q.3, TP.HCM", "Lê Văn C", "0983344556", 10 });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 4,
                columns: new[] { "Address", "CustomerName", "MembershipRank", "PhoneNumber" },
                values: new object[] { "102 Võ Văn Tần, Q.3, TP.HCM", "Phạm Hoàng Dũng", "Kim Cương", "0934567891" });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 5,
                columns: new[] { "Address", "CustomerName", "MembershipRank", "PhoneNumber", "RewardPoints" },
                values: new object[] { "15 Lý Tự Trọng, Q.1, TP.HCM", "Hoàng Thị Mai", "Vàng", "0978123456", 210 });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 6,
                columns: new[] { "Address", "CustomerName", "MembershipRank", "PhoneNumber", "RewardPoints" },
                values: new object[] { "23 Trần Hưng Đạo, Q.5, TP.HCM", "Vũ Đình Trọng", "Chuẩn", "0965432187", 0 });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 7,
                columns: new[] { "Address", "CustomerName", "MembershipRank", "PhoneNumber", "RewardPoints" },
                values: new object[] { "67 Nguyễn Thị Minh Khai, Q.3, TP.HCM", "Đặng Thu Thảo", "Bạc", "0923456789", 85 });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 8,
                columns: new[] { "Address", "CustomerName", "MembershipRank", "PhoneNumber", "RewardPoints" },
                values: new object[] { "120 Điện Biên Phủ, Bình Thạnh, TP.HCM", "Bùi Anh Tuấn", "Chuẩn", "0945678912", 25 });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 9,
                columns: new[] { "Address", "CustomerName", "MembershipRank", "PhoneNumber", "RewardPoints" },
                values: new object[] { "89 Hai Bà Trưng, Q.1, TP.HCM", "Đỗ Kim Ngân", "Vàng", "0912345678", 180 });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 10,
                columns: new[] { "Address", "CustomerName", "MembershipRank", "PhoneNumber", "RewardPoints" },
                values: new object[] { "34 Hoàng Văn Thụ, Phú Nhuận, TP.HCM", "Hồ Văn Khoa", "Bạc", "0987654321", 95 });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 11,
                columns: new[] { "Address", "CustomerName", "PhoneNumber", "RewardPoints" },
                values: new object[] { "56 Xô Viết Nghệ Tĩnh, Bình Thạnh, TP.HCM", "Ngoạn Thị Bích", "0909988776", 5 });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 12,
                columns: new[] { "Address", "CustomerName", "MembershipRank", "PhoneNumber", "RewardPoints" },
                values: new object[] { "11 Sư Vạn Hạnh, Q.10, TP.HCM", "Dương Quốc Bảo", "Kim Cương", "0933221100", 610 });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 13,
                columns: new[] { "Address", "CustomerName", "PhoneNumber", "RewardPoints" },
                values: new object[] { "223 Ba Tháng Hai, Q.10, TP.HCM", "Lý Mỹ Linh", "0977665544", 70 });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 14,
                columns: new[] { "Address", "CustomerName", "MembershipRank", "PhoneNumber", "RewardPoints" },
                values: new object[] { "44 Phan Đăng Lưu, Phú Nhuận, TP.HCM", "Huỳnh Minh Trí", "Chuẩn", "0944556677", 15 });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 15,
                columns: new[] { "Address", "CustomerName", "MembershipRank", "PhoneNumber", "RewardPoints" },
                values: new object[] { "78 Lê Văn Sỹ, Q.3, TP.HCM", "Phan Thị Mỹ", "Vàng", "0911223344", 300 });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "CustomerId", "Address", "CustomerName", "MembershipRank", "PhoneNumber" },
                values: new object[] { 16, "90 Nguyễn Trãi, Q.5, TP.HCM", "Ngô Thành Nam", "Chuẩn", "0988990011" });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "CustomerId", "Address", "CustomerName", "MembershipRank", "PhoneNumber", "RewardPoints" },
                values: new object[,]
                {
                    { 17, "101 Nguyễn Đình Chiểu, Q.3, TP.HCM", "Trịnh Khánh Vy", "Bạc", "0931122334", 60 },
                    { 18, "12 Đinh Tiên Hoàng, Q.1, TP.HCM", "Đinh Văn Hùng", "Chuẩn", "0961122334", 30 },
                    { 19, "55 Pasteur, Q.1, TP.HCM", "Lương Hải Yến", "Vàng", "0921122334", 250 },
                    { 20, "88 Nam Kỳ Khởi Nghĩa, Q.1, TP.HCM", "Mai Văn Hải", "Chuẩn", "0951122334", 12 },
                    { 21, "202 Bùi Viện, Q.1, TP.HCM", "Cao Thị Hương", "Bạc", "0971122334", 90 },
                    { 22, "333 Nguyễn Oanh, Gò Vấp, TP.HCM", "Tạ Quang Khải", "Chuẩn", "0941122334", 8 },
                    { 23, "150 Quang Trung, Gò Vấp, TP.HCM", "Trương Tấn Phát", "Kim Cương", "0919988776", 800 },
                    { 24, "66 Phạm Văn Đồng, Thủ Đức, TP.HCM", "Thái Thị Ánh", "Vàng", "0989988776", 190 },
                    { 25, "12 Võ Văn Ngân, Thủ Đức, TP.HCM", "Lâm Văn Thanh", "Chuẩn", "0939988776", 2 },
                    { 26, "88 Kha Vạn Cân, Thủ Đức, TP.HCM", "Đào Thúy Hằng", "Bạc", "0969988776", 55 },
                    { 27, "45 Lê Văn Việt, Q.9, TP.HCM", "Vương Đình Tấn", "Chuẩn", "0929988776", 18 },
                    { 28, "77 Đỗ Xuân Hợp, Q.9, TP.HCM", "Nguyễn Ngọc Ánh", "Vàng", "0959988776", 230 }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "CustomerId", "Address", "CustomerName", "MembershipRank", "PhoneNumber" },
                values: new object[] { 29, "12 Nguyễn Duy Trinh, Q.2, TP.HCM", "Trần Bảo Lâm", "Chuẩn", "0979988776" });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "CustomerId", "Address", "CustomerName", "MembershipRank", "PhoneNumber", "RewardPoints" },
                values: new object[] { 30, "01 Thảo Điền, Q.2, TP.HCM", "Lê Thị Hồng", "Kim Cương", "0949988776", 950 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 1,
                columns: new[] { "Price", "ProductName" },
                values: new object[] { 12000m, "Bánh Lay's Vị Tự Nhiên 63g" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 2,
                columns: new[] { "Price", "ProductName", "StockQuantity" },
                values: new object[] { 25000m, "Kẹo Dẻo Haribo Goldbears 80g", 80 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 3,
                columns: new[] { "CategoryId", "Price", "ProductName", "StockQuantity" },
                values: new object[] { 2, 10000m, "Nước Ngọt Coca-Cola Lon 320ml", 300 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 4,
                columns: new[] { "CategoryId", "Price", "ProductName", "StockQuantity" },
                values: new object[] { 2, 8000m, "Trà Green Tea C2 Vị Chanh 360ml", 250 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 5,
                columns: new[] { "CategoryId", "Price", "ProductName", "StockQuantity" },
                values: new object[] { 3, 38000m, "Sữa Tươi Vinamilk Ít Đường 1L", 90 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 6,
                columns: new[] { "CategoryId", "Price", "ProductName", "StockQuantity" },
                values: new object[] { 3, 28000m, "Sữa Chua TH True Milk Lốc 4 Hộp", 110 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 7,
                columns: new[] { "CategoryId", "Price", "ProductName", "StockQuantity" },
                values: new object[] { 4, 4500m, "Mì Hảo Hảo Vị Tôm Chua Cay 75g", 500 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 8,
                columns: new[] { "CategoryId", "Price", "ProductName", "StockQuantity" },
                values: new object[] { 4, 8500m, "Phở Bò Đệ Nhất Gói 120g", 200 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 9,
                columns: new[] { "CategoryId", "Price", "ProductName", "StockQuantity" },
                values: new object[] { 5, 42000m, "Nước Mắm Nam Ngư Đệ Nhất 900ml", 75 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 10,
                columns: new[] { "CategoryId", "Price", "ProductName" },
                values: new object[] { 5, 52000m, "Dầu Ăn Tường An Cooking Oil 1L" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 11,
                columns: new[] { "CategoryId", "Price", "ProductName", "StockQuantity" },
                values: new object[] { 6, 180000m, "Gạo ST25 Phố Thị Túi 5kg", 40 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 12,
                columns: new[] { "CategoryId", "Price", "ProductName", "StockQuantity" },
                values: new object[] { 7, 19000m, "Cá Sốt Cà Ba Cô Gái Hộp 155g", 120 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 13,
                columns: new[] { "CategoryId", "Price", "ProductName", "StockQuantity" },
                values: new object[] { 8, 135000m, "Dầu Gội Sunsilk Mềm Mượt 650g", 35 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 14,
                columns: new[] { "CategoryId", "Price", "ProductName", "StockQuantity" },
                values: new object[] { 9, 32000m, "Nước Rửa Chén Sunlight Chanh 750ml", 85 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 15,
                columns: new[] { "CategoryId", "Price", "ProductName", "StockQuantity" },
                values: new object[] { 10, 75000m, "Giấy Vệ Sinh Pulppy 10 Cuộn", 65 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 16,
                columns: new[] { "CategoryId", "Price", "ProductName" },
                values: new object[] { 11, 65000m, "Chả Giò Cầu Tre Nhân Thịt 500g" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 17,
                columns: new[] { "CategoryId", "Price", "ProductName", "StockQuantity" },
                values: new object[] { 12, 12000m, "Kem Merino Đậu Đỏ Que 60g", 100 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 18,
                columns: new[] { "CategoryId", "Price", "ProductName", "StockQuantity" },
                values: new object[] { 13, 18500m, "Bia Tiger Lon 330ml", 400 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 19,
                columns: new[] { "CategoryId", "Price", "ProductName", "StockQuantity" },
                values: new object[] { 14, 58000m, "Cà Phê G7 3in1 Hộp 18 Gói", 95 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 20,
                columns: new[] { "CategoryId", "Price", "ProductName", "StockQuantity" },
                values: new object[] { 15, 25000m, "Cam Sành Miền Tây (1kg)", 50 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "Barcode", "CategoryId", "Price", "ProductName", "StockQuantity", "Unit" },
                values: new object[,]
                {
                    { 21, "893456789021", 16, 15000m, "Cà Chua Đà Lạt Fresh (500g)", 40, null },
                    { 22, "893456789022", 17, 31000m, "Trứng Gà Tươi Vĩnh Thành Đạt (Hộp 10 quả)", 100, null },
                    { 23, "893456789023", 18, 68000m, "Hạt Điều Rang Salted Phố Thị 200g", 55, null },
                    { 24, "893456789024", 19, 22000m, "Bánh Mì Sandwich Kinh Đô 275g", 30, null },
                    { 25, "893456789025", 20, 35000m, "Màng Bọc Thực Phẩm Lasms 30cm", 70, null },
                    { 26, "893456789026", 21, 6000m, "Bút Cầu Gel Thiên Long 0.5mm", 200, null },
                    { 27, "893456789027", 22, 16000m, "Pate Cho Mèo Whiskas Vị Cá Biển 85g", 80, null },
                    { 28, "893456789028", 24, 35000m, "Khẩu Trang Y Tế 4 Lớp Phố Thị (Hộp 50 cái)", 150, null },
                    { 29, "893456789029", 25, 20000m, "Pin AA Panasonic Hyper Vỉ 4 Viên", 110, null },
                    { 30, "893456789030", 28, 28000m, "Cơm Cháy Chà Bông Phố Thị 150g", 90, null }
                });
        }
    }
}
