using Microsoft.EntityFrameworkCore.Migrations;

namespace P03_FootballBetting.Migrations
{
    public partial class CorrectingNames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LogogUrl",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "Amaunt",
                table: "Bets");

            migrationBuilder.AddColumn<string>(
                name: "LogoUrl",
                table: "Teams",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Amount",
                table: "Bets",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LogoUrl",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "Amount",
                table: "Bets");

            migrationBuilder.AddColumn<string>(
                name: "LogogUrl",
                table: "Teams",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Amaunt",
                table: "Bets",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
