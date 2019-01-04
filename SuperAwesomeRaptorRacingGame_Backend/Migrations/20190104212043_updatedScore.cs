using Microsoft.EntityFrameworkCore.Migrations;

namespace SuperAwesomeRaptorRacingGame_Backend.Migrations
{
    public partial class updatedScore : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Score_Users_UserId",
                table: "Score");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Score",
                table: "Score");

            migrationBuilder.RenameTable(
                name: "Score",
                newName: "Scores");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Users",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Score_UserId",
                table: "Scores",
                newName: "IX_Scores_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Scores",
                table: "Scores",
                column: "ScoreId");

            migrationBuilder.AddForeignKey(
                name: "FK_Scores_Users_UserId",
                table: "Scores",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Scores_Users_UserId",
                table: "Scores");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Scores",
                table: "Scores");

            migrationBuilder.RenameTable(
                name: "Scores",
                newName: "Score");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Users",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_Scores_UserId",
                table: "Score",
                newName: "IX_Score_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Score",
                table: "Score",
                column: "ScoreId");

            migrationBuilder.AddForeignKey(
                name: "FK_Score_Users_UserId",
                table: "Score",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
