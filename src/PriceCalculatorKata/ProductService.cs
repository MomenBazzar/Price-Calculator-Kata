namespace PriceCalculatorKata;
public class ProductService
{
    public DiscountManager DiscountManager;
    public TaxManager TaxManager;
    public ExpensesManager ExpensesManager;

    public ProductService(float universalTax, Discount universalDiscount, ExpensesManager costManager)
    {
        TaxManager = new TaxManager(universalTax);
        DiscountManager = new DiscountManager(universalDiscount);
        ExpensesManager = costManager;
    }

    public Dictionary<string, double> GetFinalCostsForProduct(Product product)
    {
        var costs = new Dictionary<string, double>() { 
            {PriceNames.TotalPrice, product.Price},
            {PriceNames.Discount, 0},
            {PriceNames.Tax, 0}
        };

        double discountNow = DiscountManager.CalculateDiscountBeforeTax(costs[PriceNames.TotalPrice], product.UPC); ;
        costs[PriceNames.TotalPrice] -= discountNow;
        costs[PriceNames.Discount] += discountNow;

        costs[PriceNames.Tax] = TaxManager.CalculateTaxValue(costs[PriceNames.TotalPrice]);

        discountNow = DiscountManager.CalculateDiscountAfterTax(costs[PriceNames.TotalPrice], product.UPC);
        costs[PriceNames.TotalPrice] -= discountNow;
        costs[PriceNames.Discount] += discountNow;

        costs[PriceNames.TotalPrice] += costs[PriceNames.Tax];

        costs[PriceNames.TotalPrice] += ExpensesManager.GetSumOfExpensesForPrice(costs[PriceNames.TotalPrice]);

        return costs;
    }


}
