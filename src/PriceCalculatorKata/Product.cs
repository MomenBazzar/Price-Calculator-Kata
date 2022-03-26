namespace PriceCalculatorKata;

public class Product
{
    public string? Name { get; set; }
    public int UPC { get; set; }
    public double Price { get; set; }

    public override string ToString()
    {
        return $"Product name = \"{Name}\", UPC = {UPC}, Price = {Price.ParseToDollars()}";
    }
}
