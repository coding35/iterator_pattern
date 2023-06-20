using System.Reflection;
using IteratorPattern.Iterator;

namespace IteratorPattern;

public class FullCatalog<T> where T : class
{
    private IFullCatalog<T> Retail { get; set; }
    private IFullCatalog<T> Wholesale { get; set; }
    
    private IFullCatalog<T> Partner { get; set; }

    public FullCatalog(IFullCatalog<T> retail, IFullCatalog<T> wholesale, IFullCatalog<T> partner)
    {
        this.Retail = retail;
        this.Wholesale = wholesale;
        this.Partner = partner;
    }

    public void PrintCatalog()
    {
        IIterator<T> retailIterator = Retail.CreateIterator();
        IIterator<T> wholesaleIterator = Wholesale.CreateIterator();
        IIterator<T> partnerIterator = Partner.CreateIterator();
        Console.WriteLine("Retail Catalog");
        Print(retailIterator);
        Console.WriteLine("Wholesale Catalog");
        Print(wholesaleIterator);
        Console.WriteLine("Partner Catalog");
        Print(partnerIterator);
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