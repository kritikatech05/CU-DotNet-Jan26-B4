namespace GlobalMart1.Services
{
    public interface IPricingServices
    {
        decimal CalculateFinalPrice(decimal basePrice, string promoCode);
    }
}
