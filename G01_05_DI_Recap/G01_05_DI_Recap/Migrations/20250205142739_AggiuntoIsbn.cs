using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace G01_05_DI_Recap.Migrations
{
    /// <inheritdoc />
    public partial class AggiuntoIsbn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Isbn",
                table: "Libros",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Isbn",
                table: "Libros");
        }
    }
}
