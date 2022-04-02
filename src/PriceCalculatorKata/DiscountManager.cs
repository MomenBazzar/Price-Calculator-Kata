namespace PriceCalculatorKata;
public class DiscountManager
{
    public DiscountManager(Discount universalDisscount)
    {
        this.UniversalDiscount = universalDisscount;
        _upcDiscounts = new Dictionary<int, Discount>();
    }

    public Discount UniversalDiscount { get; set; }
    private Dictionary<int, Discount> _upcDiscounts;

    public void UpdateUpcDiscount(int upc, Discount discount)

    {
        _upcDiscounts[upc] = discount;
    }

    public double CalculateDiscountBeforeTax(double price, int upc)
    {
        double discountBefore = 0;

        if (UniversalDiscount.IsAppliedFirst)
            discountBefore += price * UniversalDiscount.Value;

        if (_upcDiscounts.ContainsKey(upc) && _upcDiscounts[upc].IsAppliedFirst)
            discountBefore += price * _upcDiscounts[upc].Value;

        return discountBefore;
    }

    public double CalculateDiscountAfterTax(double price, int upc)
    {
        double discountAfter = 0;

        if (!UniversalDiscount.IsAppliedFirst)
            discountAfter += price * UniversalDiscount.Value;

        if (_upcDiscounts.ContainsKey(upc) && !_upcDiscounts[upc].IsAppliedFirst)
            discountAfter += price * _upcDiscounts[upc].Value;

        return discountAfter;
    }

}