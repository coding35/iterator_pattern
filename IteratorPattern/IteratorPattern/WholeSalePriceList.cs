using IteratorPattern.Iterator;

namespace IteratorPattern;

public class WholeSalePriceList<T> : IFullCatalog<T> where T : class
{
    private readonly List<T> _items;

    public WholeSalePriceList(List<T> items)
    {
        this._items = items;
    }
    
    public IIterator<T> CreateIterator()
    {
        return new ListIterator<T>(_items);
    }
}