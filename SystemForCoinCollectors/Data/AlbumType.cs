namespace SystemForCoinCollectors.Data
{
    public class AlbumType
    {
        public int Id { get; set; }
        public required string Type { get; set; }

        // navigation properties
        public CoinAlbum CoinAlbum { get; set; }
    }
}
