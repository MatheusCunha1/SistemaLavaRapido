using Microsoft.EntityFrameworkCore.Migrations;

namespace LavaCarros.Migrations
{
    public partial class Atualizacao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Detalhes",
                table: "ServicosLavagem",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Detalhes",
                table: "ServicosLavagem");
        }
    }
}
