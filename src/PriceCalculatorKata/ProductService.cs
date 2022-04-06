namespace PriceCalculatorKata;
public class ProductService
{
    public ProductService(float universalTax, Discount universalDiscount, ExpensesManager expensesManager)
    {
        TaxManager = new TaxManager(universalTax);
        DiscountManager = new DiscountManager(universalDiscount);
        ExpensesManager = expensesManager;
    }
    public DiscountManager DiscountManager;
    public TaxManager TaxManager;
    public ExpensesManager ExpensesManager;
    public Cap DiscountsCap = new Cap(double.MaxValue, isPercentage: false);
    public Dictionary<string, double> GetFinalCostsForProduct(Product product)
    {
        var costs = new Dictionary<string, double>() { 
            {"Final Price", product.Price},
            {"Discount", 0},
            {"Tax", 0}
        };

        double discountNow = DiscountManager.CalculateDiscountBeforeTax(costs["Final Price"], product.UPC); ;
        costs["Discount"] = CappedDiscount(discountNow, product.Price);

        costs["Tax"] = TaxManager.CalculateTaxValue(costs["Final Price"] - costs["Discount"]);

        discountNow = DiscountManager.CalculateDiscountAfterTax(costs["Final Price"], product.UPC);
        costs["Discount"] = CappedDiscount(discountNow + costs["Discount"], product.Price);
        
        costs["Final Price"] -= costs["Discount"];
        costs["Final Price"] += costs["Tax"];
        costs["Final Price"] += ExpensesManager.GetSumOfExpensesForPrice(costs["Final Price"]);

        return costs;
    }

    private double CappedDiscount(double discount, double price)
    {
        return Math.Min(discount, GetCapValue(price));
    }

    private double GetCapValue(double price)
    {
        if (DiscountsCap.IsPercentage)
            return DiscountsCap.Value * price;
        
        return DiscountsCap.Value;
    }

}
