namespace PriceCalculatorKata;
public static class PriceHandler
{
    public static string PriceInDollarsString(double price)
    {
        return price.ToString("C2");
    }
}
