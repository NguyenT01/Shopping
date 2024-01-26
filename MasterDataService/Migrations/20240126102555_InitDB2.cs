using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MasterDataService.Migrations
{
    /// <inheritdoc />
    public partial class InitDB2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Customer",
                columns: new[] { "CustomerId", "Address", "Email", "FirstName", "LastName" },
                values: new object[,]
                {
                    { new Guid("86a34015-e1b9-499b-a517-7af31841d9f6"), "872 Leed Street, AU", "sans1@gmail.com", "Sandro", "Picheno" },
                    { new Guid("94845d16-1c44-4fc6-8af0-9042dfec41f0"), "123 King Street, UK", "alexo@gmail.com", "Alexa", "Otofun" },
                    { new Guid("dd6a69a9-6922-4b4d-a617-f9e71385006b"), "222 West Street, EU", "poke222@gmail.com", "Maxima", "Pokemon" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Customer",
                keyColumn: "CustomerId",
                keyValue: new Guid("86a34015-e1b9-499b-a517-7af31841d9f6"));

            migrationBuilder.DeleteData(
                table: "Customer",
                keyColumn: "CustomerId",
                keyValue: new Guid("94845d16-1c44-4fc6-8af0-9042dfec41f0"));

            migrationBuilder.DeleteData(
                table: "Customer",
                keyColumn: "CustomerId",
                keyValue: new Guid("dd6a69a9-6922-4b4d-a617-f9e71385006b"));
        }
    }
}
