namespace PriceCalculatorKata;
public class SpecialProduct : IProduct
{
    public string? Name { get; set; }
    public int UPC { get; set; }
    public double Price { get; set; }
    public float SpecialDiscount { get; set; }

    public string ReportAboutPrice()
    {
        string messageOutput = $"Product price = {CalculateFinalPrice().ParseToDollars()}";
        
        float totalDiscount = IProduct.Discount + SpecialDiscount;
        if (totalDiscount > 0)
            messageOutput += $" with {Price.CalculateDiscountValue(totalDiscount).ParseToDollars()} discount.";

        return messageOutput;
    }
    public double CalculateFinalPrice()
    {
        double finalPrice = Price;
        finalPrice += Price.CalculateTaxValue(IProduct.Tax);
        float totalDiscount = IProduct.Discount + SpecialDiscount;
        finalPrice -= Price.CalculateDiscountValue(totalDiscount);
        return finalPrice;
    }

}
