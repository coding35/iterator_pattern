namespace IteratorPattern;

public class Item
{
    public Item(string name, decimal @decimal)
    {
        this.Name = name;
        this.Price = @decimal;
    }

    private string Name { get; set; }
    private decimal Price { get; set; }

    public string GetName()
    {
        return Name;
    }

    public decimal GetPrice()
    {
        return Price;
    }
    
    public void Print()
    {
        Console.WriteLine($"Item: {Name}, Price: {Price}");
    }
}