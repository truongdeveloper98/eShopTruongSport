using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace eShopTruongSport.Data.Migrations
{
    public partial class updateex : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "ConcurrencyStamp",
                value: "97d5539e-d42e-41fb-898d-c72bbb75b549");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "f9c6bce8-a340-4587-9010-a4d2c8310264", "AQAAAAEAACcQAAAAELi/9950FkLWskyPHQ5GpHL1n4KIjZDakmQRSuTcIBV9xG/td5bSm+0osFT3F/E2EA==" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ParentId", "Status" },
                values: new object[] { 1, 1 });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "IsShowOnHome", "ParentId", "SortOrder", "Status" },
                values: new object[,]
                {
                    { 3, true, 1, 3, 1 },
                    { 4, true, 2, 4, 1 },
                    { 5, true, 3, 5, 1 }
                });

            migrationBuilder.UpdateData(
                table: "CategoryTranslations",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Name", "SeoAlias", "SeoDescription", "SeoTitle" },
                values: new object[] { "Giày Đá Bóng", "giay-da-bong", "Sản phẩm giày đá bóng", "Sản phẩm giày đá bóng" });

            migrationBuilder.UpdateData(
                table: "CategoryTranslations",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Name", "SeoAlias", "SeoDescription", "SeoTitle" },
                values: new object[] { "soccer shoes", "soccer-shoes", "The soccer shoes", "The soccer shoes" });

            migrationBuilder.UpdateData(
                table: "CategoryTranslations",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Name", "SeoAlias", "SeoDescription", "SeoTitle" },
                values: new object[] { "Giày sân cỏ nhân tạo", "giay-san-co-nhan-tao", "Sản phẩm giày đá bóng sân cỏ nhân tạo", "Sản phẩm giày đá bóng sân cỏ nhân tạo" });

            migrationBuilder.UpdateData(
                table: "CategoryTranslations",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Name", "SeoAlias", "SeoDescription", "SeoTitle" },
                values: new object[] { "Artificial turf shoes", "artificial-turf-shoes", "Products football shoes artificial turf", "Products football shoes artificial turf" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2021, 6, 21, 13, 27, 21, 770, DateTimeKind.Local).AddTicks(4825));

            migrationBuilder.InsertData(
                table: "CategoryTranslations",
                columns: new[] { "Id", "CategoryId", "LanguageId", "Name", "SeoAlias", "SeoDescription", "SeoTitle" },
                values: new object[,]
                {
                    { 5, 3, "vi-VN", "Giày sân cỏ tự nhiên", "giay-san-co-tu-nhien", "Sản phẩm giày đá bóng sân cỏ tự nhiên", "Sản phẩm giày đá bóng sân cỏ tự nhiên" },
                    { 6, 3, "en-US", "Natural turf shoes", "natural-turf-shoes", "Natural turf soccer shoes", "Natural turf soccer shoes" },
                    { 7, 4, "vi-VN", "Giày TA11 sân cỏ nhân tạo", "giay-ta11-san-co-nhan-tao", "Sản phẩm giày đá bóng TA11 sân cỏ nhân tạo", "Sản phẩm giày đá bóng TA11 sân cỏ nhân tạo" },
                    { 8, 4, "en-US", "TA11 artificial turf shoes", "artificial-turf-shoes", "Products TA11 football shoes artificial turf", "Products TA11 football shoes artificial turf" },
                    { 9, 5, "vi-VN", "Giày TA11 sân cỏ tự nhiên", "giay-ta11-san-co-tu-nhien", "Sản phẩm giày đá bóng TA11 sân cỏ tự nhiên", "Sản phẩm giày đá bóng TA11 sân cỏ tự nhiên" },
                    { 10, 5, "en-US", "TA11 shoes for natural grass", "TA11-shoes-for-natural-grass", "Products TA11 shoes for natural grass courts", "Products TA11 shoes for natural grass courts" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CategoryTranslations",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "CategoryTranslations",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "CategoryTranslations",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "CategoryTranslations",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "CategoryTranslations",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "CategoryTranslations",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "ConcurrencyStamp",
                value: "c4eafc91-899d-42ff-89a2-9d1faff7e70f");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "174254fd-f23e-4777-ac22-003ce6b799e7", "AQAAAAEAACcQAAAAEKr6YIqlZcWgAczZJaj0NIUn7pzr2t8FZdwHog5SS6+k7s/sIhYqRGzEY2ikaztK+Q==" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ParentId", "Status" },
                values: new object[] { null, 1 });

            migrationBuilder.UpdateData(
                table: "CategoryTranslations",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Name", "SeoAlias", "SeoDescription", "SeoTitle" },
                values: new object[] { "Áo nam", "ao-nam", "Sản phẩm áo T-Shirt thể thao nam", "Sản phẩm áo T-Shirt thể thao nam" });

            migrationBuilder.UpdateData(
                table: "CategoryTranslations",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Name", "SeoAlias", "SeoDescription", "SeoTitle" },
                values: new object[] { "Men T-Shirt", "men-t-shirt", "The t-shirt sport products for men", "The t-shirt sport products for men" });

            migrationBuilder.UpdateData(
                table: "CategoryTranslations",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Name", "SeoAlias", "SeoDescription", "SeoTitle" },
                values: new object[] { "Áo nữ", "ao-nu", "Sản phẩm áo T-Shirt thể thao nữ", "Sản phẩm áo T-Shirt thể thao women" });

            migrationBuilder.UpdateData(
                table: "CategoryTranslations",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Name", "SeoAlias", "SeoDescription", "SeoTitle" },
                values: new object[] { "Women Shirt", "women-shirt", "The t-shirt sport products for women", "The t-shirt sport products for women" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2021, 6, 19, 10, 9, 37, 873, DateTimeKind.Local).AddTicks(5769));
        }
    }
}
