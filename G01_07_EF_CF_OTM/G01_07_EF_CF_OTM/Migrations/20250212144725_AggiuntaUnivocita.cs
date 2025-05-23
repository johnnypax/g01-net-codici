﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace G01_07_EF_CF_OTM.Migrations
{
    /// <inheritdoc />
    public partial class AggiuntaUnivocita : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Codice",
                table: "Autores",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Autores_Codice",
                table: "Autores",
                column: "Codice",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Autores_Codice",
                table: "Autores");

            migrationBuilder.AlterColumn<string>(
                name: "Codice",
                table: "Autores",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }
    }
}
