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
        string messageOutput = $"Product price = {_productService.CalculateFinalPrice(product).ParseToDollars()}";

        double totalDiscount = _productService.discountManager.CalculateDiscountValue(product);
        if (totalDiscount > 0)
            messageOutput += $" with {totalDiscount.ParseToDollars()} discount.";
            
        return messageOutput;
    }

}
