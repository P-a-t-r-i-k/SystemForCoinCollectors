using System.ComponentModel.DataAnnotations.Schema;

namespace SystemForCoinCollectors.Data
{
    public class CoinAlbum
    {
        public int Id { get; set; }
        
        //[ForeignKey("AlbumType")]
        public int AlbumTypeId { get; set; }

        // navigation properties
        public AlbumType AlbumType { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public ICollection<Coin> CollectedCoins { get; set; }
    }
}
