namespace PriceCalculatorKata;
public class Expense
{
    public Expense(string description, double amount, bool isPercentageAmount = false)
    {
        Description = description;
        Amount = amount;
        IsPercentageAmount = isPercentageAmount;
    }
    public string Description { get; set; }
    public bool IsPercentageAmount { get; set; }
    public double Amount { get; set; }
}
