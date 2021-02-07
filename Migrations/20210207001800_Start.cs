using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BookmakerAPI.Migrations
{
    public partial class Start : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Matches",
                columns: table => new
                {
                    MatchId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MatchDate = table.Column<DateTime>(nullable: false),
                    FirstTeamId = table.Column<int>(nullable: false),
                    SecondTeamId = table.Column<int>(nullable: false),
                    FirstTeamScore = table.Column<int>(nullable: false),
                    SecondTeamScore = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Matches", x => x.MatchId);
                    table.ForeignKey(
                        name: "FK_FirstTeam",
                        column: x => x.FirstTeamId,
                        principalTable: "Teams",
                        principalColumn: "TeamId");
                    table.ForeignKey(
                        name: "FK_SecondTeam",
                        column: x => x.SecondTeamId,
                        principalTable: "Teams",
                        principalColumn: "TeamId");
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Matches");
        }
    }
}
