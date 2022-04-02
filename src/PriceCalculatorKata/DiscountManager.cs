namespace PriceCalculatorKata;
public class DiscountManager
{
    public DiscountManager(float universalDisscount)
    {
        this.UniversalDisscount = universalDisscount;
        _upcDiscounts = new Dictionary<int, float>();
    }

    public float UniversalDisscount { get; set; }
    private Dictionary<int, float> _upcDiscounts;

    public void UpdateUpcDiscount(int upc, float discount)
    {
        _upcDiscounts[upc] = discount;
    }

    public double CalculateDiscountValue(Product product)
    {
        double discountValue = product.Price * UniversalDisscount;
        if (_upcDiscounts.ContainsKey(product.UPC))
        {
            discountValue += product.Price * _upcDiscounts[product.UPC];
        }
        return discountValue;
    }

}