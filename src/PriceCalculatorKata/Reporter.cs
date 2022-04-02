namespace PriceCalculatorKata;
public class Reporter
{
    public Reporter(ProductService productService)
    {
        _productService = productService;
    }
    private ProductService _productService;
    public string MakeReportAboutProduct(Product product)
    {
        var priceAndDiscount = _productService.CalculateFinalPriceAndDiscount(product);
        var finalPrice = priceAndDiscount[0];
        var finalDiscount = priceAndDiscount[1];

        string messageOutput = $"Product price = {finalPrice.ParseToDollars()}";

        if (finalDiscount > 0)
            messageOutput += $" with {finalDiscount.ParseToDollars()} discount.";
            
        return messageOutput;
    }

}
