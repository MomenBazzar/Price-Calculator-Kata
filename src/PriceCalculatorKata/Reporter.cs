namespace PriceCalculatorKata;
public class Reporter
{
    public Reporter(ProductService productService)
    {
        _productService = productService;
    }

    private ProductService _productService;

    public string ReportPriceWithAllCosts(Product product)
    {
        string message = "";
        addCostToMessage(ref message, "Price", product.Price);

        var costs = _productService.GetFinalCostsForProduct(product);

        if (costs["Discount"] > 0)
            addCostToMessage(ref message, "Discount", costs["Discount"]);

        addCostToMessage(ref message, "Tax", costs["Tax"]);

        AddExpensesOfPriceToMessage(ref message, product.Price);

        addCostToMessage(ref message, "Final Price", costs["Final Price"]);

        return message;
    }

    private void AddExpensesOfPriceToMessage(ref string message, double price)
    {
        var expenses = _productService.ExpensesManager.getAllExpensesForPrice(price);
        foreach (var expense in expenses)
        {
            addCostToMessage(ref message, expense.Key, expense.Value);
        }
    }

    private void addCostToMessage(ref string message, string description, double value)
    {
        message += $"{description} = {value.ParseToDollars()}\n";

    }

}
