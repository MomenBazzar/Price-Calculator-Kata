namespace PriceCalculatorKata;
public class Report
{
    public static string MakeReportAboutProduct(Product product)
    {
        string messageOutput = $"Product price = {product.CalculateFinalPrice().ParseToDollars()}";

        double totalDiscount = Discount.CalculateDiscountValue(product);
        if (totalDiscount > 0)
            messageOutput += $" with {totalDiscount.ParseToDollars()} discount.";
            
        return messageOutput;
    }

}
