using System.Reflection;
using IteratorPattern.Iterator;

namespace IteratorPattern;

public class SimpleCatalog<T> where T : class
{
    private readonly List<T> _items;
    
    public SimpleCatalog(List<T> items)
    {
        _items = items;
    }
    
    public void PrintCatalog()
    {
        IIterator<T?> iterator = new ListIterator<T?>(_items!);
        while (iterator.HasNext())
        {
            Print(iterator);
        }
    }

    private void Print(IIterator<T?> iterator)
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