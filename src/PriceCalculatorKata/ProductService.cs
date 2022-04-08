namespace PriceCalculatorKata;
public class ProductService
{
    
    public DiscountManager DiscountManager;
    public TaxManager TaxManager;
    public ExpensesManager ExpensesManager;
    public Cap DiscountsCap = new Cap(double.MaxValue, isPercentage: false);
    
    public ProductService(float universalTax, Discount universalDiscount, ExpensesManager expensesManager)

    {
        TaxManager = new TaxManager(universalTax);
        DiscountManager = new DiscountManager(universalDiscount);
        ExpensesManager = expensesManager;
    }

    public Dictionary<string, double> GetFinalCostsForProduct(Product product)
    {
        var costs = new Dictionary<string, double>() { 
            {PriceNames.TotalPrice, product.Price},
            {PriceNames.Discount, 0},
            {PriceNames.Tax, 0}
        };

        double discountNow = DiscountManager.CalculateDiscountBeforeTax(costs[PriceNames.TotalPrice], product.UPC); ;
        costs[PriceNames.Discount] = CappedDiscount(discountNow, product.Price);

        costs[PriceNames.Tax] = TaxManager.CalculateTaxValue(costs[PriceNames.TotalPrice] - costs[PriceNames.Discount]);

        discountNow = DiscountManager.CalculateDiscountAfterTax(costs[PriceNames.TotalPrice], product.UPC);
        costs[PriceNames.Discount] = CappedDiscount(discountNow + costs[PriceNames.Discount], product.Price);
        
        costs[PriceNames.TotalPrice] -= costs[PriceNames.Discount];
        costs[PriceNames.TotalPrice] += costs[PriceNames.Tax];
        costs[PriceNames.TotalPrice] += ExpensesManager.GetSumOfExpensesForPrice(costs[PriceNames.TotalPrice]);

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
