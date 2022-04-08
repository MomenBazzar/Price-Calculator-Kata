namespace PriceCalculatorKata;
public class TaxManager
{

    public float UniversalTax { get; set; }

    public TaxManager(float universalTax)
    {
        UniversalTax = universalTax;
    }
    
    public double CalculateTaxValue(double price)
    {
        return price * UniversalTax;
    }
}
