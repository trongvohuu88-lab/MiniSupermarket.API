using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MiniSupermarket.API.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDatabaseSchema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PhoneNumber = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    RewardPoints = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    MembershipRank = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, defaultValue: "Chuẩn")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerId);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

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

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName", "Description" },
                values: new object[,]
                {
                    { 6, "Gạo, Bột & Khô", "Gạo thơm, bột mỹ, miến, bún khô" },
                    { 7, "Đồ đóng hộp & Chế biến sẵn", "Cá hộp, thịt hộp, xúc xích, pate" },
                    { 8, "Hóa mỹ phẩm & Vệ sinh cá nhân", "Dầu gội, sữa tắm, kem đánh răng, xà phòng" },
                    { 9, "Chăm sóc nhà cửa", "Nước lau sàn, nước rửa chén, bột giặt" },
                    { 10, "Khăn giấy & Tã bỉm", "Giấy vệ sinh, khăn giấy khô/ướt, tã em bé" },
                    { 11, "Thực phẩm đông lạnh", "Cá viên, bò viên, chả giò, há cảo" },
                    { 12, "Kem & Đồ lạnh", "Kem que, kem hộp, đá viên đóng túi" },
                    { 13, "Bia & Đồ uống có cồn", "Bia lon, rượu nhẹ, cồn thực phẩm" },
                    { 14, "Cà phê & Cacao", "Cà phê hòa tan, cà phê rang xay, bột cacao" },
                    { 15, "Trái cây tươi Phố Thị", "Táo, chuối, cam, dưa hấu theo mùa" },
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

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "CustomerId", "Address", "CustomerName", "MembershipRank", "PhoneNumber", "RewardPoints" },
                values: new object[,]
                {
                    { 1, "12 Nguyễn Trãi, Q.1, TP.HCM", "Nguyễn Văn A", "Vàng", "0901122334", 150 },
                    { 2, "45 Lê Lợi, Q.1, TP.HCM", "Trần Thị B", "Bạc", "0918877665", 50 },
                    { 3, "88 CMT8, Q.3, TP.HCM", "Lê Văn C", "Chuẩn", "0983344556", 10 },
                    { 4, "102 Võ Văn Tần, Q.3, TP.HCM", "Phạm Hoàng Dũng", "Kim Cương", "0934567891", 520 },
                    { 5, "15 Lý Tự Trọng, Q.1, TP.HCM", "Hoàng Thị Mai", "Vàng", "0978123456", 210 }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "CustomerId", "Address", "CustomerName", "MembershipRank", "PhoneNumber" },
                values: new object[] { 6, "23 Trần Hưng Đạo, Q.5, TP.HCM", "Vũ Đình Trọng", "Chuẩn", "0965432187" });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "CustomerId", "Address", "CustomerName", "MembershipRank", "PhoneNumber", "RewardPoints" },
                values: new object[,]
                {
                    { 7, "67 Nguyễn Thị Minh Khai, Q.3, TP.HCM", "Đặng Thu Thảo", "Bạc", "0923456789", 85 },
                    { 8, "120 Điện Biên Phủ, Bình Thạnh, TP.HCM", "Bùi Anh Tuấn", "Chuẩn", "0945678912", 25 },
                    { 9, "89 Hai Bà Trưng, Q.1, TP.HCM", "Đỗ Kim Ngân", "Vàng", "0912345678", 180 },
                    { 10, "34 Hoàng Văn Thụ, Phú Nhuận, TP.HCM", "Hồ Văn Khoa", "Bạc", "0987654321", 95 },
                    { 11, "56 Xô Viết Nghệ Tĩnh, Bình Thạnh, TP.HCM", "Ngoạn Thị Bích", "Chuẩn", "0909988776", 5 },
                    { 12, "11 Sư Vạn Hạnh, Q.10, TP.HCM", "Dương Quốc Bảo", "Kim Cương", "0933221100", 610 },
                    { 13, "223 Ba Tháng Hai, Q.10, TP.HCM", "Lý Mỹ Linh", "Bạc", "0977665544", 70 },
                    { 14, "44 Phan Đăng Lưu, Phú Nhuận, TP.HCM", "Huỳnh Minh Trí", "Chuẩn", "0944556677", 15 },
                    { 15, "78 Lê Văn Sỹ, Q.3, TP.HCM", "Phan Thị Mỹ", "Vàng", "0911223344", 300 }
                });

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

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "Barcode", "CategoryId", "Price", "ProductName", "StockQuantity", "Unit" },
                values: new object[,]
                {
                    { 1, "893456789001", 1, 12000m, "Bánh Lay's Vị Tự Nhiên 63g", 150, null },
                    { 2, "893456789002", 1, 25000m, "Kẹo Dẻo Haribo Goldbears 80g", 80, null },
                    { 3, "893456789003", 2, 10000m, "Nước Ngọt Coca-Cola Lon 320ml", 300, null },
                    { 4, "893456789004", 2, 8000m, "Trà Green Tea C2 Vị Chanh 360ml", 250, null },
                    { 5, "893456789005", 3, 38000m, "Sữa Tươi Vinamilk Ít Đường 1L", 90, null },
                    { 6, "893456789006", 3, 28000m, "Sữa Chua TH True Milk Lốc 4 Hộp", 110, null },
                    { 7, "893456789007", 4, 4500m, "Mì Hảo Hảo Vị Tôm Chua Cay 75g", 500, null },
                    { 8, "893456789008", 4, 8500m, "Phở Bò Đệ Nhất Gói 120g", 200, null },
                    { 9, "893456789009", 5, 42000m, "Nước Mắm Nam Ngư Đệ Nhất 900ml", 75, null },
                    { 10, "893456789010", 5, 52000m, "Dầu Ăn Tường An Cooking Oil 1L", 60, null }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Description", "RoleName" },
                values: new object[,]
                {
                    { 1, "Quản trị viên toàn hệ thống, toàn quyền thao tác", "Admin" },
                    { 2, "Nhân viên thu ngân, chuyên trách bán hàng tại quầy POS", "Cashier" },
                    { 3, "Nhân viên quản lý kho, nhập hàng và kiểm kê", "Warehouse" },
                    { 4, "Quản lý cửa hàng Phố Thị, giám sát vận hành chung", "StoreManager" },
                    { 5, "Trợ lý quản lý cửa hàng Phố Thị", "AssistantManager" },
                    { 6, "Quản lý tồn kho và kế hoạch dự trữ", "InventoryManager" },
                    { 7, "Nhân viên thu mua hàng hóa tạp hóa", "PurchasingStaff" },
                    { 8, "Trưởng phòng thu mua, duyệt đơn nhập hàng", "PurchasingManager" },
                    { 9, "Nhân viên kế toán, thu chi và hóa đơn", "Accountant" },
                    { 10, "Kế toán trưởng Phố Thị", "ChiefAccountant" },
                    { 11, "Nhân viên bán hàng & tư vấn trực tiếp", "SalesStaff" },
                    { 12, "Giám sát sảnh và gian hàng Phố Thị", "FloorSupervisor" },
                    { 13, "Nhân viên chăm sóc & giải quyết khiếu nại", "CustomerService" },
                    { 14, "Quản lý chương trình khách hàng thân thiết", "CRMManager" },
                    { 15, "Nhân viên marketing & chương trình khuyến mãi", "MarketingStaff" },
                    { 16, "Trưởng phòng tiếp thị & truyền thông Phố Thị", "MarketingManager" },
                    { 17, "Nhân viên hỗ trợ kỹ thuật POS và hệ thống", "ITSupport" },
                    { 18, "Quản trị viên hạ tầng mạng & cơ sở dữ liệu", "SysAdmin" },
                    { 19, "Nhân viên bảo vệ & giữ xe cửa hàng", "SecurityGuard" },
                    { 20, "Nhân viên giao hàng Phố Thị Express", "DeliveryStaff" },
                    { 21, "Quản lý vận chuyển & giao nhận", "LogisticsManager" },
                    { 22, "Nhân viên nhân sự & chấm công", "HRStaff" },
                    { 23, "Trưởng phòng nhân sự & tuyển dụng", "HRManager" },
                    { 24, "Nhân viên trưng bày & sắp xếp kệ hàng", "Merchandiser" },
                    { 25, "Kiểm định chất lượng & hạn sử dụng (HSD)", "QualityControl" },
                    { 26, "Nhân viên kiểm toán nội bộ & thất thoát", "AuditStaff" },
                    { 27, "Trưởng ca làm việc Phố Thị", "ShiftLeader" },
                    { 28, "Chuyên viên phân tích doanh thu & xu hướng", "DataAnalyst" },
                    { 29, "Nhân viên quản lý đơn hàng online", "EcomStaff" },
                    { 30, "Giám đốc điều hành chuỗi Tạp hóa Phố Thị", "GeneralManager" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "Barcode", "CategoryId", "Price", "ProductName", "StockQuantity", "Unit" },
                values: new object[,]
                {
                    { 11, "893456789011", 6, 180000m, "Gạo ST25 Phố Thị Túi 5kg", 40, null },
                    { 12, "893456789012", 7, 19000m, "Cá Sốt Cà Ba Cô Gái Hộp 155g", 120, null },
                    { 13, "893456789013", 8, 135000m, "Dầu Gội Sunsilk Mềm Mượt 650g", 35, null },
                    { 14, "893456789014", 9, 32000m, "Nước Rửa Chén Sunlight Chanh 750ml", 85, null },
                    { 15, "893456789015", 10, 75000m, "Giấy Vệ Sinh Pulppy 10 Cuộn", 65, null },
                    { 16, "893456789016", 11, 65000m, "Chả Giò Cầu Tre Nhân Thịt 500g", 45, null },
                    { 17, "893456789017", 12, 12000m, "Kem Merino Đậu Đỏ Que 60g", 100, null },
                    { 18, "893456789018", 13, 18500m, "Bia Tiger Lon 330ml", 400, null },
                    { 19, "893456789019", 14, 58000m, "Cà Phê G7 3in1 Hộp 18 Gói", 95, null },
                    { 20, "893456789020", 15, 25000m, "Cam Sành Miền Tây (1kg)", 50, null },
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

            migrationBuilder.CreateIndex(
                name: "IX_Customers_PhoneNumber",
                table: "Customers",
                column: "PhoneNumber",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Roles");

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
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 20);

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
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 15);

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

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 2,
                column: "Description",
                value: "Nước ngọt, nước khoáng, trà");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 3,
                column: "Description",
                value: "Sữa tươi, sữa chua, phô mai");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 4,
                column: "Description",
                value: "Mì ăn liền, phở khô, cháo gói");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 5,
                column: "Description",
                value: "Nước mắm, hạt nêm, dầu thực vật");
        }
    }
}
