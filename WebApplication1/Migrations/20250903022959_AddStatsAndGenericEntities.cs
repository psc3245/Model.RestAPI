using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class AddStatsAndGenericEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlayerGameStat_Games_GameId",
                table: "PlayerGameStat");

            migrationBuilder.DropForeignKey(
                name: "FK_PlayerGameStat_Players_PlayerId",
                table: "PlayerGameStat");

            migrationBuilder.DropForeignKey(
                name: "FK_Players_Teams_CurrentTeamId",
                table: "Players");

            migrationBuilder.DropForeignKey(
                name: "FK_TeamGameStat_Games_GameId",
                table: "TeamGameStat");

            migrationBuilder.DropForeignKey(
                name: "FK_TeamGameStat_Teams_TeamId",
                table: "TeamGameStat");

            migrationBuilder.DropIndex(
                name: "IX_Players_CurrentTeamId",
                table: "Players");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TeamGameStat",
                table: "TeamGameStat");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PlayerGameStat",
                table: "PlayerGameStat");

            migrationBuilder.DropColumn(
                name: "FoundedYear",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "Birthdate",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "CurrentTeamId",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "AwayScore",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "HomeScore",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "Round",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "Venue",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "StatCategory",
                table: "TeamGameStat");

            migrationBuilder.DropColumn(
                name: "StatValue",
                table: "TeamGameStat");

            migrationBuilder.RenameTable(
                name: "TeamGameStat",
                newName: "TeamStats");

            migrationBuilder.RenameTable(
                name: "PlayerGameStat",
                newName: "PlayerStats");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "Players",
                newName: "Name");

            migrationBuilder.RenameIndex(
                name: "IX_TeamGameStat_TeamId",
                table: "TeamStats",
                newName: "IX_TeamStats_TeamId");

            migrationBuilder.RenameIndex(
                name: "IX_TeamGameStat_GameId",
                table: "TeamStats",
                newName: "IX_TeamStats_GameId");

            migrationBuilder.RenameIndex(
                name: "IX_PlayerGameStat_PlayerId",
                table: "PlayerStats",
                newName: "IX_PlayerStats_PlayerId");

            migrationBuilder.RenameIndex(
                name: "IX_PlayerGameStat_GameId",
                table: "PlayerStats",
                newName: "IX_PlayerStats_GameId");

            migrationBuilder.AddColumn<int>(
                name: "Number",
                table: "Players",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TeamId",
                table: "Players",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Points",
                table: "TeamStats",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Yards",
                table: "TeamStats",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_TeamStats",
                table: "TeamStats",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PlayerStats",
                table: "PlayerStats",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Stats",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PlayerId = table.Column<int>(type: "integer", nullable: true),
                    TeamId = table.Column<int>(type: "integer", nullable: true),
                    GameId = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Value = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stats", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Stats_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Stats_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Stats_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Players_TeamId",
                table: "Players",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Stats_GameId",
                table: "Stats",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_Stats_PlayerId",
                table: "Stats",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_Stats_TeamId",
                table: "Stats",
                column: "TeamId");

            migrationBuilder.AddForeignKey(
                name: "FK_Players_Teams_TeamId",
                table: "Players",
                column: "TeamId",
                principalTable: "Teams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PlayerStats_Games_GameId",
                table: "PlayerStats",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PlayerStats_Players_PlayerId",
                table: "PlayerStats",
                column: "PlayerId",
                principalTable: "Players",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TeamStats_Games_GameId",
                table: "TeamStats",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TeamStats_Teams_TeamId",
                table: "TeamStats",
                column: "TeamId",
                principalTable: "Teams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Players_Teams_TeamId",
                table: "Players");

            migrationBuilder.DropForeignKey(
                name: "FK_PlayerStats_Games_GameId",
                table: "PlayerStats");

            migrationBuilder.DropForeignKey(
                name: "FK_PlayerStats_Players_PlayerId",
                table: "PlayerStats");

            migrationBuilder.DropForeignKey(
                name: "FK_TeamStats_Games_GameId",
                table: "TeamStats");

            migrationBuilder.DropForeignKey(
                name: "FK_TeamStats_Teams_TeamId",
                table: "TeamStats");

            migrationBuilder.DropTable(
                name: "Stats");

            migrationBuilder.DropIndex(
                name: "IX_Players_TeamId",
                table: "Players");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TeamStats",
                table: "TeamStats");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PlayerStats",
                table: "PlayerStats");

            migrationBuilder.DropColumn(
                name: "Number",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "TeamId",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "Points",
                table: "TeamStats");

            migrationBuilder.DropColumn(
                name: "Yards",
                table: "TeamStats");

            migrationBuilder.RenameTable(
                name: "TeamStats",
                newName: "TeamGameStat");

            migrationBuilder.RenameTable(
                name: "PlayerStats",
                newName: "PlayerGameStat");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Players",
                newName: "LastName");

            migrationBuilder.RenameIndex(
                name: "IX_TeamStats_TeamId",
                table: "TeamGameStat",
                newName: "IX_TeamGameStat_TeamId");

            migrationBuilder.RenameIndex(
                name: "IX_TeamStats_GameId",
                table: "TeamGameStat",
                newName: "IX_TeamGameStat_GameId");

            migrationBuilder.RenameIndex(
                name: "IX_PlayerStats_PlayerId",
                table: "PlayerGameStat",
                newName: "IX_PlayerGameStat_PlayerId");

            migrationBuilder.RenameIndex(
                name: "IX_PlayerStats_GameId",
                table: "PlayerGameStat",
                newName: "IX_PlayerGameStat_GameId");

            migrationBuilder.AddColumn<int>(
                name: "FoundedYear",
                table: "Teams",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "Birthdate",
                table: "Players",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "CurrentTeamId",
                table: "Players",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Players",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "AwayScore",
                table: "Games",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "HomeScore",
                table: "Games",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Round",
                table: "Games",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Venue",
                table: "Games",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "StatCategory",
                table: "TeamGameStat",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<double>(
                name: "StatValue",
                table: "TeamGameStat",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_TeamGameStat",
                table: "TeamGameStat",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PlayerGameStat",
                table: "PlayerGameStat",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Players_CurrentTeamId",
                table: "Players",
                column: "CurrentTeamId");

            migrationBuilder.AddForeignKey(
                name: "FK_PlayerGameStat_Games_GameId",
                table: "PlayerGameStat",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PlayerGameStat_Players_PlayerId",
                table: "PlayerGameStat",
                column: "PlayerId",
                principalTable: "Players",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Players_Teams_CurrentTeamId",
                table: "Players",
                column: "CurrentTeamId",
                principalTable: "Teams",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TeamGameStat_Games_GameId",
                table: "TeamGameStat",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TeamGameStat_Teams_TeamId",
                table: "TeamGameStat",
                column: "TeamId",
                principalTable: "Teams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
