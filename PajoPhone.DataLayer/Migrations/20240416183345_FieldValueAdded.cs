using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PajoPhone.DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class FieldValueAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Value",
                table: "FieldProducts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Value",
                table: "FieldProducts");
        }
    }
}
