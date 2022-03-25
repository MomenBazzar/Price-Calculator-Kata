namespace PriceCalculatorKata;
public class Tax
{
    public static float UniversalTax { get; set; }

    public static double AddTaxToPrice(double price)
    {
        return price + CalculateTaxValue(price);
    }

    private static double CalculateTaxValue(double price)
    {
        return price * UniversalTax;
    }
}
