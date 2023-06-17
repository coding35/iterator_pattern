using System.Reflection;
using IteratorPattern.Iterator;

namespace IteratorPattern;

public class FullCatalog<T> where T : class
{
    private RetailSalePriceList<T> Retail { get; set; }
    private WholeSalePriceList<T> Wholesale { get; set; }

    public FullCatalog(RetailSalePriceList<T> retail, WholeSalePriceList<T> wholesale)
    {
        this.Retail = retail;
        this.Wholesale = wholesale;
    }

    public void PrintCatalog()
    {
        IIterator<T> retailIterator = Retail.CreateIterator();
        IIterator<T> wholesaleIterator = Wholesale.CreateIterator();
        Console.WriteLine("Retail Catalog");
        Print(retailIterator);
        Console.WriteLine("Wholesale Catalog");
        Print(wholesaleIterator);
    }

    private void Print(IIterator<T> iterator)
    {
        while (iterator.HasNext())
        {
            T? item = iterator.Next();
            var objectType = item?.GetType();
            MethodInfo? print = objectType?.GetMethod("Print");
            print?.Invoke(item, null);
        }
    }
}