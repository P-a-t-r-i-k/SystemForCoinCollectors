using System.ComponentModel.DataAnnotations.Schema;

namespace SystemForCoinCollectors.Data
{
    public class AdminChangesInUserTableHistory
    {
        public int Id { get; set; }

        public DateTime DateTimeOfChange { get; set; }


        [ForeignKey(nameof(Admin))]
        public string? AdminId { get; set; }

        [ForeignKey(nameof(ApplicationUser))]
        public string? UserId { get; set; }

        public string OldEmail { get; set; }

        public string? NewEmail { get; set; }

        public int OldReputationPoints { get; set; }
        public int NewReputationPoints { get; set; }

        public string Description { get; set; }


        // navigation properties
        public virtual ApplicationUser ApplicationUser { get; set; }

        public virtual ApplicationUser Admin { get; set; }

    }
}
