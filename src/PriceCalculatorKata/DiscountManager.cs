namespace PriceCalculatorKata;
public class DiscountManager
{
    public DiscountManager(float universalDisscount)
    {
        this.UniversalDisscount = universalDisscount;
        _UpcDiscounts = new Dictionary<int, float>();
    }

    public float UniversalDisscount { get; set; }
    private Dictionary<int, float> _UpcDiscounts;

    public void UpdateUpcDiscount(int UPC, float discount)
    {
        _UpcDiscounts[UPC] = discount;
    }

    public double CalculateDiscountValue(Product product)
    {
        double discountValue = product.Price * UniversalDisscount;
        if (_UpcDiscounts.ContainsKey(product.UPC))
        {
            discountValue += product.Price * _UpcDiscounts[product.UPC];
        }
        return discountValue;
    }

}