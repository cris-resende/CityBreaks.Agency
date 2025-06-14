namespace CityBreaks.Agency.Utils
{
    public class Delegates
    {
        public delegate decimal CalculateDelegate(decimal originalPrice);

        public static class DiscountCalculator
        {
            public static decimal ApplyTenPercentDiscount(decimal originalPrice)
            {
                return originalPrice * 0.90M;
            }
        }
    }
}
