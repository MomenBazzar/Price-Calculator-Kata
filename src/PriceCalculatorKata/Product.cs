namespace PriceCalculatorKata;

public class Product
{
    public static double Tax { get; set; }
    public static double Discount { get; set; }
    public string? Name { get; set; }
    public int UPC { get; set; }
    public double Price { get; set; }
    
    public string ReportAboutPrice()
    {
        string message = $"Product price = {Price.AddTaxAndDiscount(Tax, Discount).ParseToDollars()}";
        if (Discount > 0)
            message = message + $" with {Price.CalculateDiscountValue(Discount).ParseToDollars()} discount.";
        
        return message;
        
    }

    

    public override string ToString()
    {
        return $"Product name = \"{Name}\", UPC = {UPC}, Price = {Price.ParseToDollars()}";
    }
}
