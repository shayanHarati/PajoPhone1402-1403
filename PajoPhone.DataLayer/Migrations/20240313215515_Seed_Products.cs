using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PajoPhone.DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class Seed_Products : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "ImageProduct", "ProductColor", "ProductDescription", "ProductName", "ProductPrice" },
                values: new object[,]
                {
                    { 1, "p1.jpg", "مشکی", null, "محصول 1", 12000000m },
                    { 2, "p1.jpg", "سفید", null, "محصول 2", 5000000m },
                    { 3, "p1.jpg", "مشکی", null, "محصول 3", 20000000m },
                    { 4, "p1.jpg", "مشکی", null, "محصول 4", 500000m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
