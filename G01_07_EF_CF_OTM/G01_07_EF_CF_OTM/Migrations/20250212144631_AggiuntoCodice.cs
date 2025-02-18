using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace G01_07_EF_CF_OTM.Migrations
{
    /// <inheritdoc />
    public partial class AggiuntoCodice : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Codice",
                table: "Autores",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Codice",
                table: "Autores");
        }
    }
}
