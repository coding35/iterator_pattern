using IteratorPattern.Iterator;

namespace IteratorPattern;

public class RetailSalePriceList<T> where T : class
{
    private readonly T?[] _items;

    public RetailSalePriceList(T?[] items)
    {
        this._items = items;
    }

    public IIterator<T> CreateIterator()
    {
        return new ArrayIterator<T>(_items);
    }
}