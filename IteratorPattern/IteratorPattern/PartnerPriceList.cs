using IteratorPattern.Iterator;

namespace IteratorPattern;

public class PartnerPriceList<T> : IFullCatalog<T> where T : class
{
    private readonly Dictionary<int, T> _items;

    public PartnerPriceList(Dictionary<int, T> items)
    {
        _items = items;
    }
    
    public IIterator<T> CreateIterator()
    {
        return new DictionaryIterator<T>(_items);
    }
}