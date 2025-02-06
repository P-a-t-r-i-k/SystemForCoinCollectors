namespace SystemForCoinCollectors.Data
{
    public class Coin
    {
        public int Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public required string Feature { get; set; }
        public string Description { get; set; }
        public string IssuingVolume { get; set; }
        public string IssuingYear { get; set; }
        public string ImagePath { get; set; }
        public string Country { get; set; }

        // navigation properties
        public ICollection<CoinAlbum> CoinAlbums { get; set; }

    }
}
