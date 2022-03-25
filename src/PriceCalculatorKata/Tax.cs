namespace PriceCalculatorKata;
public class Tax
{
    public static float UniversalTax { get; set; }

    public static double CalculateTaxValue(double price)
    {
        return price * UniversalTax;
    }
}
