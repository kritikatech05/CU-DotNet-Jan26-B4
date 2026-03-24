using System.ComponentModel.DataAnnotations;

namespace WealthTrack.Models
{
    public class InvestmentCreateViewModel
    {
        [Required(ErrorMessage = "Ticker is required")]
        [StringLength(10)]
        [Display(Name = "Ticker Symbol")]
        public string TickerSymbol { get; set; }

        [Required]
        [Range(0.01, 1000000)]
        public decimal Price { get; set; }
        [Required]
        [Display(Name ="Asset Name")]
        [StringLength(12)]
        public string  AssetName { get; set; }
        [Required]
        [Range(1, 10000)]
        public int Quantity { get; set; }

        [Display(Name = "Total Investment Value")]
        public string TotalValue => (Price * Quantity).ToString("C");
    }

}
