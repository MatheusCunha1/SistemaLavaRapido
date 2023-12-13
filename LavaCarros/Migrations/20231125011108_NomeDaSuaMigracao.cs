using Microsoft.EntityFrameworkCore.Migrations;

namespace LavaCarros.Migrations
{
    public partial class NomeDaSuaMigracao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Tipo",
                table: "ServicosLavagem",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "TipoLavagemId",
                table: "Carros",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Carros_TipoLavagemId",
                table: "Carros",
                column: "TipoLavagemId");

            migrationBuilder.AddForeignKey(
                name: "FK_Carros_ServicosLavagem_TipoLavagemId",
                table: "Carros",
                column: "TipoLavagemId",
                principalTable: "ServicosLavagem",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carros_ServicosLavagem_TipoLavagemId",
                table: "Carros");

            migrationBuilder.DropIndex(
                name: "IX_Carros_TipoLavagemId",
                table: "Carros");

            migrationBuilder.DropColumn(
                name: "TipoLavagemId",
                table: "Carros");

            migrationBuilder.AlterColumn<string>(
                name: "Tipo",
                table: "ServicosLavagem",
                type: "longtext",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");
        }
    }
}
