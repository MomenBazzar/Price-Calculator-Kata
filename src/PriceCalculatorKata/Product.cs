namespace PriceCalculatorKata;

public class Product
{
    public string? Name { get; set; }
    public int UPC { get; set; }
    public double Price { get; set; }

    public string ReportAboutPrice(double tax, double discount)
    {
        string message = $"Product price = {Price.AddTaxAndDiscount(tax, discount).ParseToDollars()}";
        if (discount > 0)
            message = message + $" with {Price.CalculateDiscountValue(discount).ParseToDollars()} discount.";
        
        return message;
        
    }

    

    public override string ToString()
    {
        return $"Product name = \"{Name}\", UPC = {UPC}, Price = {Price.ParseToDollars()}";
    }
}
