namespace PriceCalculatorKata;
public static class PriceExtensions
{
    public static string ParseToDollars(this double price)
    {
        return price.ToString("C2");
    }

}
