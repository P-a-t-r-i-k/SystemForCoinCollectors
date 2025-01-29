using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SystemForCoinCollectors.Migrations
{
    /// <inheritdoc />
    public partial class AddAlbumTypeAndCoinAlbumTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Image",
                table: "Coins",
                newName: "ImagePath");

            migrationBuilder.CreateTable(
                name: "AlbumTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlbumTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CoinAlbums",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AlbumTypeId = table.Column<int>(type: "int", nullable: false),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoinAlbums", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CoinAlbums_AlbumTypes_AlbumTypeId",
                        column: x => x.AlbumTypeId,
                        principalTable: "AlbumTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CoinAlbums_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CoinAlbums_AlbumTypeId",
                table: "CoinAlbums",
                column: "AlbumTypeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CoinAlbums_ApplicationUserId",
                table: "CoinAlbums",
                column: "ApplicationUserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CoinAlbums");

            migrationBuilder.DropTable(
                name: "AlbumTypes");

            migrationBuilder.RenameColumn(
                name: "ImagePath",
                table: "Coins",
                newName: "Image");
        }
    }
}
