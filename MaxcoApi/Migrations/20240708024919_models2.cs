using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MaxcoApi.Migrations
{
    /// <inheritdoc />
    public partial class models2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Nombre_Zona",
                table: "Zonas",
                newName: "NombreZona");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NombreZona",
                table: "Zonas",
                newName: "Nombre_Zona");
        }
    }
}
