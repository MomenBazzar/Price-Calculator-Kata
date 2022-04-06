namespace PriceCalculatorKata;
public static class PriceExtensions
{
    public static string ParseToDollars(this double price, string currency)
    {
        return $"{Math.Round(price, 2)} {currency}";
    }
}
