namespace PriceCalculatorKata;
public class ProductService
{
    public ProductService(float universalTax, Discount universalDiscount, ExpensesManager costManager)
    {
        TaxManager = new TaxManager(universalTax);
        DiscountManager = new DiscountManager(universalDiscount);
        ExpensesManager = costManager;
    }
    public DiscountManager DiscountManager;
    public TaxManager TaxManager;
    public ExpensesManager ExpensesManager;
    public Dictionary<string, double> GetFinalCostsForProduct(Product product)
    {
        var costs = new Dictionary<string, double>() { 
            {"Final Price", product.Price},
            {"Discount", 0},
            {"Tax", 0}
        };

        double discountNow = DiscountManager.CalculateDiscountBeforeTax(costs["Final Price"], product.UPC); ;
        costs["Final Price"] -= discountNow;
        costs["Discount"] += discountNow;

        costs["Tax"] = TaxManager.CalculateTaxValue(costs["Final Price"]);

        discountNow = DiscountManager.CalculateDiscountAfterTax(costs["Final Price"], product.UPC);
        costs["Final Price"] -= discountNow;
        costs["Discount"] += discountNow;

        costs["Final Price"] += costs["Tax"];

        costs["Final Price"] += ExpensesManager.GetSumOfExpensesForPrice(costs["Final Price"]);

        return costs;
    }


}
