using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SystemOdonto.Migrations
{
    /// <inheritdoc />
    public partial class AgregarTablaTratamientoAdicional : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CostoTratamientoAdicional",
                table: "Pacientes");

            migrationBuilder.DropColumn(
                name: "TratamientoAdicional",
                table: "Pacientes");

            migrationBuilder.CreateTable(
                name: "TratamientoAdicional",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Costo = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PacienteId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TratamientoAdicional", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TratamientoAdicional_Pacientes_PacienteId",
                        column: x => x.PacienteId,
                        principalTable: "Pacientes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_TratamientoAdicional_PacienteId",
                table: "TratamientoAdicional",
                column: "PacienteId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TratamientoAdicional");

            migrationBuilder.AddColumn<decimal>(
                name: "CostoTratamientoAdicional",
                table: "Pacientes",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "TratamientoAdicional",
                table: "Pacientes",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
