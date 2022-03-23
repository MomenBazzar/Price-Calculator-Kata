namespace PriceCalculatorKata;
public static class PriceHandler
{
    public static string ParseToDollars(this double price)
    {
        return price.ToString("C2");
    }

    public static double CalculateTaxValue(this double price, double tax)
    {
        return price * tax;
    }

    public static double CalculateDiscountValue(this double price, double discount)
    {
        return price * discount;
    }

    public static string ParseToPercentage(this double tax)
    {
        return (tax * 100).ToString("0.##") + "%";
    }
}
