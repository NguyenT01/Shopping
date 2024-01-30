using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ProductServiceNamespace.Migrations
{
    /// <inheritdoc />
    public partial class InitProductDbSample2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "Description", "Name" },
                values: new object[,]
                {
                    { new Guid("bcda33a3-476e-40a0-b558-0c14e7c70ed0"), "Khoai tây, thuộc họ Cà. Khoai tây là loài cây nông nghiệp ngắn ngày, trồng lấy củ chứa tinh bột. Chúng là loại cây trồng lấy củ rộng rãi nhất thế giới và là loại", "Khoai tay" },
                    { new Guid("de2018fd-4e94-4a9c-83f4-e41b5114064c"), "Cá thu Nhật hay Cá sa ba hay sa pa, còn biết đến như là cá thu Thái Bình Dương, cá thu Nhật Bản, cá thu lam hoặc cá thu bống", "Ca Sa Ba" },
                    { new Guid("e2a85f91-ddab-427d-91eb-4c8c74a487ff"), "Bắp cải hay cải bắp hay cải nồi là một loại rau chủ lực trong họ Cải, phát sinh từ vùng Địa Trung Hải. Nó là cây thân thảo, sống hai năm,", "Bap cai" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("bcda33a3-476e-40a0-b558-0c14e7c70ed0"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("de2018fd-4e94-4a9c-83f4-e41b5114064c"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("e2a85f91-ddab-427d-91eb-4c8c74a487ff"));
        }
    }
}
