namespace PriceCalculatorKata;
public class SpecialProduct : Product
{
    public float SpecialDiscount { get; set; }

    new public string ReportAboutPrice()
    {
        string messageOutput = $"Product price = {CalculateFinalPrice().ParseToDollars()}";

        double totalDiscount = Discount.CalculateDiscountValue(Price);
        totalDiscount += Discount.CalculateSpecialDiscountValue(Price, SpecialDiscount);

        if (totalDiscount > 0)
            messageOutput += $" with {totalDiscount.ParseToDollars()} discount.";

        return messageOutput;
    }
    new public double CalculateFinalPrice()
    {
        double finalPrice = Tax.AddTaxToPrice(Price);
        finalPrice -= Discount.CalculateDiscountValue(Price);
        finalPrice -= Discount.CalculateSpecialDiscountValue(Price, SpecialDiscount);
        return finalPrice;
    }

}
