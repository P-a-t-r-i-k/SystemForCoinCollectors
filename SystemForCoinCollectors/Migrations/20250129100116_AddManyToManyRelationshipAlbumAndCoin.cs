using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SystemForCoinCollectors.Migrations
{
    /// <inheritdoc />
    public partial class AddManyToManyRelationshipAlbumAndCoin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CoinCoinAlbum",
                columns: table => new
                {
                    CoinAlbumsId = table.Column<int>(type: "int", nullable: false),
                    CollectedCoinsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoinCoinAlbum", x => new { x.CoinAlbumsId, x.CollectedCoinsId });
                    table.ForeignKey(
                        name: "FK_CoinCoinAlbum_CoinAlbums_CoinAlbumsId",
                        column: x => x.CoinAlbumsId,
                        principalTable: "CoinAlbums",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CoinCoinAlbum_Coins_CollectedCoinsId",
                        column: x => x.CollectedCoinsId,
                        principalTable: "Coins",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CoinCoinAlbum_CollectedCoinsId",
                table: "CoinCoinAlbum",
                column: "CollectedCoinsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CoinCoinAlbum");
        }
    }
}
