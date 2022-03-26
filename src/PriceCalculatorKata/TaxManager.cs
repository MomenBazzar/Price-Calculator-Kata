namespace PriceCalculatorKata;
public class TaxManager
{
    public TaxManager(float universalTax)
    {
        UniversalTax = universalTax;
    }
    public float UniversalTax { get; set; }

    public double CalculateTaxValue(double price)
    {
        return price * UniversalTax;
    }
}
