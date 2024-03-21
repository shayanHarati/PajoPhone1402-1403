using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PajoPhone.DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class ParentCategoryId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PrentCategoryId",
                table: "Category",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 1,
                column: "PrentCategoryId",
                value: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PrentCategoryId",
                table: "Category");
        }
    }
}
