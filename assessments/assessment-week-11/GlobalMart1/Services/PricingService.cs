namespace GlobalMart1.Services
{
    public class PricingService : IPricingServices
    {
        public decimal CalculateFinalPrice(decimal basePrice, string promoCode)
        {
            decimal finalPrice = basePrice;

            if (!string.IsNullOrEmpty(promoCode))
            {
               
                if (promoCode == "WINTER25")
                    finalPrice = basePrice * 0.85m;

                else if (promoCode == "FREESHIP")
                    finalPrice = basePrice - 5m;
            }
            if(finalPrice < 0)
            {
                finalPrice = 0;
            }
           

            return finalPrice;
        }
    }
}
