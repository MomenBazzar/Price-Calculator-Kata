namespace PriceCalculatorKata;
public class ExpensesManager
{
    private List<Expense> _expenses;

    public ExpensesManager()
    {
        _expenses = new List<Expense>();
    }
    public double GetSumOfExpensesForPrice(double price)
    {
        Dictionary<string, double> expenses = GetAllExpensesForPrice(price);
        
        return expenses.Sum(ex => ex.Value);
    }
    public Dictionary<string, double> GetAllExpensesForPrice(double price)
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
        if (FindExpenseByDescription(expense.Description) != null)
            throw new ArgumentException($"an expense with same Description=\"{expense.Description}\" already exists");

        _expenses.Add(expense);
    }

    public void UpdateExpenseAmount(string expenseDescription, double amount)
    {
        var expenseItem = FindExpenseByDescription(expenseDescription);
        if (expenseItem == null)
            throw new ArgumentException($"coudn't find an expense with Description=\"{expenseDescription}\"");

        expenseItem.Amount = amount;
    }

    private Expense? FindExpenseByDescription(string expenseDescription)
    {
        return _expenses.Where(e => e.Description == expenseDescription).FirstOrDefault();
    }
}
