using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CityBreaks.Agency.Migrations
{
    /// <inheritdoc />
    public partial class DefineRelationships : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservas_PacotesTuristicos_PacoteTuristicoId",
                table: "Reservas");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservas_PacotesTuristicos_PacoteTuristicoId",
                table: "Reservas",
                column: "PacoteTuristicoId",
                principalTable: "PacotesTuristicos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservas_PacotesTuristicos_PacoteTuristicoId",
                table: "Reservas");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservas_PacotesTuristicos_PacoteTuristicoId",
                table: "Reservas",
                column: "PacoteTuristicoId",
                principalTable: "PacotesTuristicos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
