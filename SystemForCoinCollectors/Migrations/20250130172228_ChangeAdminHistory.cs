using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SystemForCoinCollectors.Migrations
{
    /// <inheritdoc />
    public partial class ChangeAdminHistory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AdminId",
                table: "AdminChangesInUserTableHistory",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "AdminChangesInUserTableHistory",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "NewEmail",
                table: "AdminChangesInUserTableHistory",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NewReputationPoints",
                table: "AdminChangesInUserTableHistory",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "OldEmail",
                table: "AdminChangesInUserTableHistory",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "OldReputationPoints",
                table: "AdminChangesInUserTableHistory",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "AdminChangesInUserTableHistory",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AdminChangesInUserTableHistory_AdminId",
                table: "AdminChangesInUserTableHistory",
                column: "AdminId");

            migrationBuilder.CreateIndex(
                name: "IX_AdminChangesInUserTableHistory_UserId",
                table: "AdminChangesInUserTableHistory",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_AdminChangesInUserTableHistory_AspNetUsers_AdminId",
                table: "AdminChangesInUserTableHistory",
                column: "AdminId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AdminChangesInUserTableHistory_AspNetUsers_UserId",
                table: "AdminChangesInUserTableHistory",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AdminChangesInUserTableHistory_AspNetUsers_AdminId",
                table: "AdminChangesInUserTableHistory");

            migrationBuilder.DropForeignKey(
                name: "FK_AdminChangesInUserTableHistory_AspNetUsers_UserId",
                table: "AdminChangesInUserTableHistory");

            migrationBuilder.DropIndex(
                name: "IX_AdminChangesInUserTableHistory_AdminId",
                table: "AdminChangesInUserTableHistory");

            migrationBuilder.DropIndex(
                name: "IX_AdminChangesInUserTableHistory_UserId",
                table: "AdminChangesInUserTableHistory");

            migrationBuilder.DropColumn(
                name: "AdminId",
                table: "AdminChangesInUserTableHistory");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "AdminChangesInUserTableHistory");

            migrationBuilder.DropColumn(
                name: "NewEmail",
                table: "AdminChangesInUserTableHistory");

            migrationBuilder.DropColumn(
                name: "NewReputationPoints",
                table: "AdminChangesInUserTableHistory");

            migrationBuilder.DropColumn(
                name: "OldEmail",
                table: "AdminChangesInUserTableHistory");

            migrationBuilder.DropColumn(
                name: "OldReputationPoints",
                table: "AdminChangesInUserTableHistory");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "AdminChangesInUserTableHistory");
        }
    }
}
