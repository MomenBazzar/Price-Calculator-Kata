namespace PriceCalculatorKata;

public class Product
{
    public string? Name { get; set; }
    public int UPC { get; set; }
    public double Price { get; set; }

    public string ReportAboutPriceWithTaxing(int tax)
    {
        return $"Product price reported as {PriceHandler.PriceInDollarsString(Price)} before tax "
        + $"and {PriceHandler.PriceInDollarsString(this.PriceWithAddedTax(tax))} after {tax}% tax.";
    }

    public double PriceWithAddedTax(int tax)
    {
        return Price + (Price * tax / 100);
    }

    public override string ToString()
    {
        return $"Product name = \"{Name}\", UPC = {UPC}, Price = {PriceHandler.PriceInDollarsString(Price)}";
    }
}
