namespace PriceCalculatorKata;
public static class PriceHandler
{
    public static string ParseToDollars(this double price)
    {
        return price.ToString("C2");
    }

}
