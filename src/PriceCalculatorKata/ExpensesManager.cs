namespace PriceCalculatorKata;
public class ExpensesManager
{
    public ExpensesManager()
    {
        _expenses = new List<Expense>();
    }
    private List<Expense> _expenses;

    public double GetSumOfExpensesForPrice(double price)
    {
        double sum = 0;
        Dictionary<string, double> expenses = getAllExpensesForPrice(price);
        foreach (var expense in expenses)
        {
            sum += expense.Value;
        }
        return sum;
    }
    public Dictionary<string, double> getAllExpensesForPrice(double price)
    {
        var expensesAnswer = new Dictionary<string, double>();
        foreach (var expense in _expenses)
        {
            var actualAmount = expense.Amount;
            if (expense.IsPercentageAmount) actualAmount *= price;

            expensesAnswer.Add(expense.Description, actualAmount);

        }
        return expensesAnswer;
    }

    public void AddNewExpense(Expense expense)
    {
        if (FindExpenseOrNull(expense.Description) != null)
            throw new ArgumentException($"an expense with same Description=\"{expense.Description}\" already exists");

        _expenses.Add(expense);
    }

    public void UpdateExpenseAmount(string expenseDescription, double amount)
    {
        var expenseItem = FindExpenseOrNull(expenseDescription);
        if (expenseItem == null)
            throw new ArgumentException($"coudn't find an expense with Description=\"{expenseDescription}\"");

        expenseItem.Amount = amount;
    }

    private Expense? FindExpenseOrNull(string expenseDescription)
    {
        foreach (var expense in _expenses)
        {
            if (expense.Description.Equals(expenseDescription))
            {
                return expense;
            }
        }
        return null;
    }
}
