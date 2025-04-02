using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SystemOdonto.Migrations
{
    /// <inheritdoc />
    public partial class UpdatePaciente : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TratamientoAdicional_Pacientes_PacienteId",
                table: "TratamientoAdicional");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TratamientoAdicional",
                table: "TratamientoAdicional");

            migrationBuilder.RenameTable(
                name: "TratamientoAdicional",
                newName: "TratamientosAdicionales");

            migrationBuilder.RenameIndex(
                name: "IX_TratamientoAdicional_PacienteId",
                table: "TratamientosAdicionales",
                newName: "IX_TratamientosAdicionales_PacienteId");

            migrationBuilder.AlterColumn<int>(
                name: "PacienteId",
                table: "TratamientosAdicionales",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_TratamientosAdicionales",
                table: "TratamientosAdicionales",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TratamientosAdicionales_Pacientes_PacienteId",
                table: "TratamientosAdicionales",
                column: "PacienteId",
                principalTable: "Pacientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TratamientosAdicionales_Pacientes_PacienteId",
                table: "TratamientosAdicionales");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TratamientosAdicionales",
                table: "TratamientosAdicionales");

            migrationBuilder.RenameTable(
                name: "TratamientosAdicionales",
                newName: "TratamientoAdicional");

            migrationBuilder.RenameIndex(
                name: "IX_TratamientosAdicionales_PacienteId",
                table: "TratamientoAdicional",
                newName: "IX_TratamientoAdicional_PacienteId");

            migrationBuilder.AlterColumn<int>(
                name: "PacienteId",
                table: "TratamientoAdicional",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TratamientoAdicional",
                table: "TratamientoAdicional",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TratamientoAdicional_Pacientes_PacienteId",
                table: "TratamientoAdicional",
                column: "PacienteId",
                principalTable: "Pacientes",
                principalColumn: "Id");
        }
    }
}
