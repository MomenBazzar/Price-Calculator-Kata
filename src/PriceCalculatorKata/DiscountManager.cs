namespace PriceCalculatorKata;
public class DiscountManager
{
    public Discount UniversalDiscount { get; set; }
    public bool IsMultiplicativeDisounts { get; set; }
    private Dictionary<int, Discount> _upcDiscounts;

    public DiscountManager(Discount universalDisscount, bool isMultiplicativeDisounts = false)
    {
        UniversalDiscount = universalDisscount;
        IsMultiplicativeDisounts = isMultiplicativeDisounts;
        _upcDiscounts = new Dictionary<int, Discount>();
    }

    public void UpdateUpcDiscount(int upc, Discount discount)
    {
        _upcDiscounts[upc] = discount;
    }

    public double CalculateDiscountBeforeTax(double price, int upc)
    {
        double discount1 = 0;
        if (UniversalDiscount.IsAppliedFirst)
            discount1 = UniversalDiscount.Value;

        double discount2 = 0;
        if (_upcDiscounts.ContainsKey(upc) && _upcDiscounts[upc].IsAppliedFirst)
            discount2 = _upcDiscounts[upc].Value;

        return GetTotalDiscount(price, discount1, discount2);
    }

    public double CalculateDiscountAfterTax(double price, int upc)
    {
        double discount1 = 0;
        if (!UniversalDiscount.IsAppliedFirst)
            discount1 = UniversalDiscount.Value;

        double discount2 = 0;
        if (_upcDiscounts.ContainsKey(upc) && !_upcDiscounts[upc].IsAppliedFirst)
            discount2 = _upcDiscounts[upc].Value;

        return GetTotalDiscount(price, discount1, discount2);
    }
    private double GetTotalDiscount(double price, double discount1, double discount2)
    {
        if (IsMultiplicativeDisounts)
            return MultiplicativeDiscount(price, discount1, discount2);

        return AdditiveDiscount(price, discount1, discount2);
    }
    private double MultiplicativeDiscount(double price, double discount1, double discount2)
    {
        discount1 = price * discount1;
        return discount1 + (price - discount1) * discount2;
    }

    private double AdditiveDiscount(double price, double discount1, double discount2)
    {
        return (price * discount1) + (price * discount2);
    }
}