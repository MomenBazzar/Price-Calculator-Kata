namespace PriceCalculatorKata;
public class Reporter
{
    public string Currency = "JPY";
    private ProductService _productService;

    public Reporter(ProductService productService)
    {
        _productService = productService;
    }

    public string ReportPriceWithAllCosts(Product product)
    {
        string message = "";
        message = AddCostToMessage(message, PriceNames.ProductPrice, product.Price);

        var costs = _productService.GetFinalCostsForProduct(product);

        if (costs[PriceNames.Discount] > 0)
            AddCostToMessage(message, PriceNames.Discount, costs[PriceNames.Discount]);

        message = AddCostToMessage(message, PriceNames.Tax, costs[PriceNames.Tax]);

        message = AddExpensesOfPriceToMessage(message, product.Price);

        message = AddCostToMessage(message, PriceNames.TotalPrice, costs[PriceNames.TotalPrice]);

        return message;
    }

    private string AddExpensesOfPriceToMessage(string message, double price)
    {
        var expenses = _productService.ExpensesManager.GetAllExpensesForPrice(price);
        foreach (var expense in expenses)
        {
            message = AddCostToMessage(message, expense.Key, expense.Value);
        }
        return message;
    }

    private string AddCostToMessage(string message, string description, double value)
    {
        message += $"{description} = {value.ParseToDollars(Currency)}\n";
        return message;
    }

}
