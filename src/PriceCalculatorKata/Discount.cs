namespace PriceCalculatorKata;
public class Discount
{
    public static float UniversalDisscount { get; set; }
    private static Dictionary<int, float> _UpcDiscounts = new Dictionary<int, float>();

    public static void UpdateUpcDiscount(int UPC, float discount)
    {
        _UpcDiscounts[UPC] = discount;
    }

    public static double CalculateDiscountValue(Product product)
    {
        double discountValue = product.Price * UniversalDisscount;
        if (_UpcDiscounts.ContainsKey(product.UPC))
        {
            discountValue += product.Price * _UpcDiscounts[product.UPC];
        }
        return discountValue;
    }

}