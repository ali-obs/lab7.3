
class Product
{
    public string ProductCode { get; init; }
    public string Name { get; set; }
    private double price;
    public double Price
    {
        get => price;
        set
        {
            if (value > 0)
            {
                price = value;
            }
            else
            {
                Console.WriteLine($"Invalid price: {value}");
                price = 1.0;
            }
        }
    }
    public int Stock { get; private set; }
    public Product(string productCode, string name, double price, int initialStock)
    {
        ProductCode = productCode;
        Name = name;
        Price = price;
        Stock = initialStock >= 0 ? initialStock : 0;
    }
    public void Restock(int amount)
    {
        if (amount > 0)
        {
            Stock += amount;
        }
    }
    public string Info()
    {
        return $"[{ProductCode}] {Name} - ${Price:F2} (Stock: {Stock})";
    }
}
class Program
{
    static void Main()
    {
        Product[] products = new Product[]
        {
            new Product("P101", "Wireless Mouse", 25.50, 15),
            new Product("P102", "Mechanical Keyboard", 85.00, 10),
            new Product("P103", "USB-C Cable", -15, 40),
            new Product("P104", "Gaming Monitor", 220.00, 5) 
        };
        products[2].Restock(10);
        foreach (Product p in products)
        {
            Console.WriteLine(p.Info());
        }
        double[] prices = new double[products.Length];
        for (int i = 0; i < products.Length; i++)
        {
            prices[i] = products[i].Price;
        }
        Console.WriteLine($"\nMin Price: {prices.Min()} | Max Price: {prices.Max()} | Average: {prices.Average():F2}");
        Console.WriteLine($"Products >= $50: {prices.Count(p => p >= 50)}");
        double[] sortedPrices = prices[..];
        Array.Sort(sortedPrices);
        Console.WriteLine("Sorted Prices: " + string.Join(" ", sortedPrices));
        double targetPrice = 85;
        int index = Array.BinarySearch(sortedPrices, targetPrice);
        if (index >= 0)
            Console.WriteLine($"Binary Search for {targetPrice}: Found at index {index}");
        else
            Console.WriteLine($"Binary Search for {targetPrice}: Not found");
    }
}