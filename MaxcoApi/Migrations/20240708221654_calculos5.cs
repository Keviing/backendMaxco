using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MaxcoApi.Migrations
{
    /// <inheritdoc />
    public partial class calculos5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "VentaId",
                table: "DetallesVentas",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_DetallesVentas_VentaId",
                table: "DetallesVentas",
                column: "VentaId");

            migrationBuilder.AddForeignKey(
                name: "FK_DetallesVentas_Ventas_VentaId",
                table: "DetallesVentas",
                column: "VentaId",
                principalTable: "Ventas",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DetallesVentas_Ventas_VentaId",
                table: "DetallesVentas");

            migrationBuilder.DropIndex(
                name: "IX_DetallesVentas_VentaId",
                table: "DetallesVentas");

            migrationBuilder.DropColumn(
                name: "VentaId",
                table: "DetallesVentas");
        }
    }
}
