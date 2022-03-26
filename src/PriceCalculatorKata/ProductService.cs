namespace PriceCalculatorKata;
public class ProductService
{
    public ProductService(float universalTax, float universalDiscount)
    {
        taxManager = new TaxManager(universalTax);
        discountManager = new DiscountManager(universalDiscount);
    }
    public DiscountManager discountManager;
    public TaxManager taxManager;
    public double CalculateFinalPrice(Product product)
    {
        double finalPrice = product.Price;
        finalPrice += taxManager.CalculateTaxValue(product.Price);
        finalPrice -= discountManager.CalculateDiscountValue(product);
        return finalPrice;
    }
}
