using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace net_ef_videogame.Migrations
{
    /// <inheritdoc />
    public partial class column_name_to_videogames_table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_videogames_software_house_prova_1",
                table: "videogames");

            migrationBuilder.RenameColumn(
                name: "prova_1",
                table: "videogames",
                newName: "software_house_id");

            migrationBuilder.RenameIndex(
                name: "IX_videogames_prova_1",
                table: "videogames",
                newName: "IX_videogames_software_house_id");

            migrationBuilder.AddForeignKey(
                name: "FK_videogames_software_house_software_house_id",
                table: "videogames",
                column: "software_house_id",
                principalTable: "software_house",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_videogames_software_house_software_house_id",
                table: "videogames");

            migrationBuilder.RenameColumn(
                name: "software_house_id",
                table: "videogames",
                newName: "prova_1");

            migrationBuilder.RenameIndex(
                name: "IX_videogames_software_house_id",
                table: "videogames",
                newName: "IX_videogames_prova_1");

            migrationBuilder.AddForeignKey(
                name: "FK_videogames_software_house_prova_1",
                table: "videogames",
                column: "prova_1",
                principalTable: "software_house",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
