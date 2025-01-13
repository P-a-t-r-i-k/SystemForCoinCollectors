namespace SystemForCoinCollectors.Data
{
    public class Coin
    {
        public int Id { get; set; }
        public required string Feature { get; set; }
        public string Description { get; set; }
        public string IssuingVolume { get; set; }
        public string IssuingYear { get; set; }
        public string Image { get; set; }
        public string Country { get; set; }

    }
}
