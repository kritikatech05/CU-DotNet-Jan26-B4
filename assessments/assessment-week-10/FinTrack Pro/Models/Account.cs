
namespace FinTrack_Pro.Models
{
    public class Account
    {
        public int Id { get; set; }

        public string? AccountNumber { get; set; }

        public string? AccountHolder { get; set; }

        public double Balance { get; set; }

        public List<Transaction>? Transactions { get; set; }
    }
}