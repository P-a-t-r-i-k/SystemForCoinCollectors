using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SystemForCoinCollectors.Migrations
{
    /// <inheritdoc />
    public partial class ChangeCoinTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IssuingDate",
                table: "Coins",
                newName: "IssuingYear");

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "Coins",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Coins",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Country",
                table: "Coins");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "Coins");

            migrationBuilder.RenameColumn(
                name: "IssuingYear",
                table: "Coins",
                newName: "IssuingDate");
        }
    }
}
