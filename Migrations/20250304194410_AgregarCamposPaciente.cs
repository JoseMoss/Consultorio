using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SystemOdonto.Migrations
{
    /// <inheritdoc />
    public partial class AgregarCamposPaciente : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "CostoTratamientoAdicional",
                table: "Pacientes",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaInicioTratamiento",
                table: "Pacientes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "TipoTratamiento",
                table: "Pacientes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TratamientoAdicional",
                table: "Pacientes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CostoTratamientoAdicional",
                table: "Pacientes");

            migrationBuilder.DropColumn(
                name: "FechaInicioTratamiento",
                table: "Pacientes");

            migrationBuilder.DropColumn(
                name: "TipoTratamiento",
                table: "Pacientes");

            migrationBuilder.DropColumn(
                name: "TratamientoAdicional",
                table: "Pacientes");
        }
    }
}
