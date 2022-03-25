namespace PriceCalculatorKata;

public class Product
{
    public string? Name { get; set; }
    public int UPC { get; set; }
    public double Price { get; set; }

    public string ReportAboutPrice()
    {
        string messageOutput = $"Product price = {CalculateFinalPrice().ParseToDollars()}";
        var discountValue = Discount.CalculateDiscountValue(this);
        if (discountValue > 0)
            messageOutput += $" with {discountValue.ParseToDollars()} discount.";

        return messageOutput;
    }

    public double CalculateFinalPrice()
    {
        double finalPrice = Price;
        finalPrice += Tax.CalculateTaxValue(Price);
        finalPrice -= Discount.CalculateDiscountValue(this);
        return finalPrice;
    }


    public override string ToString()
    {
        return $"Product name = \"{Name}\", UPC = {UPC}, Price = {Price.ParseToDollars()}";
    }
}
