namespace PriceCalculatorKata;

public class Product
{
    public string? Name { get; set; }
    public int UPC { get; set; }
    public double Price { get; set; }
    
    public string ReportAboutPrice()
    {
        string messageOutput = $"Product price = {CalculateFinalPrice().ParseToDollars()}";
        if (Discount.UniversalDisscount > 0)
            messageOutput += $" with {Discount.CalculateDiscountValue(Price).ParseToDollars()} discount.";

        return messageOutput;
    }

    public double CalculateFinalPrice()
    {
        double finalPrice = Tax.AddTaxToPrice(Price);
        finalPrice -= Discount.CalculateDiscountValue(Price);
        return finalPrice;
    }

    public override string ToString()
    {
        return $"Product name = \"{Name}\", UPC = {UPC}, Price = {Price.ParseToDollars()}";
    }
}
