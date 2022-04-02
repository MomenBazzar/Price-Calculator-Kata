namespace PriceCalculatorKata;
public class ProductService
{
    public ProductService(float universalTax, Discount universalDiscount)
    {
        taxManager = new TaxManager(universalTax);
        discountManager = new DiscountManager(universalDiscount);
    }
    public DiscountManager discountManager;
    public TaxManager taxManager;
    public List<double> CalculateFinalPriceAndDiscount(Product product)
    {
        double finalPrice = product.Price;
        double finalDiscount = 0;

        double discountNow = discountManager.CalculateDiscountBeforeTax(finalPrice, product.UPC);;
        finalPrice -= discountNow;
        finalDiscount += discountNow;

        var tax = taxManager.CalculateTaxValue(finalPrice);

        discountNow = discountManager.CalculateDiscountAfterTax(finalPrice, product.UPC);
        finalPrice -= discountNow;
        finalDiscount += discountNow;

        finalPrice += tax;
        
        return new List<double>(){finalPrice, finalDiscount};
    }
}
