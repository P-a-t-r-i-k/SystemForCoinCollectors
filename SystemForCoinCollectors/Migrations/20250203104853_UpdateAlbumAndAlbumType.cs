using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SystemForCoinCollectors.Migrations
{
    /// <inheritdoc />
    public partial class UpdateAlbumAndAlbumType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_CoinAlbums_AlbumTypeId",
                table: "CoinAlbums");

            migrationBuilder.CreateIndex(
                name: "IX_CoinAlbums_AlbumTypeId",
                table: "CoinAlbums",
                column: "AlbumTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_CoinAlbums_AlbumTypeId",
                table: "CoinAlbums");

            migrationBuilder.CreateIndex(
                name: "IX_CoinAlbums_AlbumTypeId",
                table: "CoinAlbums",
                column: "AlbumTypeId",
                unique: true);
        }
    }
}
