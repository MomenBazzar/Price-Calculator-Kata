namespace PriceCalculatorKata;
class Program
{
    public static void Main()
    {
        var expensesManager = new ExpensesManager();
        expensesManager.AddNewExpense(new Expense("Packaging", 0.01, isPercentageAmount: true));
        expensesManager.AddNewExpense(new Expense("Transport", 2.2));
        expensesManager.UpdateExpenseAmount("Transport", 2.2);
        var allCosts = expensesManager.GetAllExpensesForPrice(20.25);

        var universalTax = 0.21f;
        var universalDiscount = new Discount(0.15f);
        var productService = new ProductService(universalTax, universalDiscount, expensesManager);
        var reporter = new Reporter(productService);

        var products = new List<Product>();
        FillProductsList(products);

        var newDiscount = new Discount(0.07f, false);
        productService.DiscountManager.UpdateUpcDiscount(172, newDiscount);
        foreach (var product in products)
        {
            Console.WriteLine("===========");
            Console.WriteLine(product.Name);
            Console.Write(reporter.ReportPriceWithAllCosts(product));
        }

    }

    public static void FillProductsList(List<Product> products)
    {
        products.AddRange(new[]{
            new Product()
            {
                Name = "Asus VivoBook",
                UPC = 123,
                Price = 800.30
            },
            new Product()
            {
                Name = "MSI MG63",
                UPC = 543,
                Price = 1120
            },
            new Product()
            {
                Name = "Apple MacBook",
                UPC = 172,
                Price = 20.25,
            }
        });
    }
}
