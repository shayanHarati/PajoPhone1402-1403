using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PajoPhone.DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class Title_added_fields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FieldTitle",
                table: "Fields",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FieldTitle",
                table: "Fields");
        }
    }
}
