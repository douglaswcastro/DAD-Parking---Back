using Microsoft.EntityFrameworkCore.Migrations;

namespace DADParkingBack.Migrations
{
    public partial class Vinculo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NumeroVaga",
                table: "vaga",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumeroVaga",
                table: "vaga");
        }
    }
}
