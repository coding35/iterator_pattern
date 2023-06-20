namespace IteratorPattern.Iterator;

public class DictionaryIterator<T> : IIterator<T> where T : class
{
    private readonly Dictionary<int, T> _dictionary;
    private int _index;

    public DictionaryIterator(Dictionary<int, T> items)
    {
        _dictionary = items;
        _index = 0;
    }

    public bool HasNext()
    {
        return _dictionary.Count > _index;
    }

    public T? Next()
    {
        T? item = _dictionary[_index];
        _index += 1;
        return item;
    }

    public void Remove()
    {
        _dictionary.Remove(_index);
    }

    public T? CurrentItem()
    {
        return _dictionary[_index];
    }

    public int GetIteration()
    {
        return _index;
    }
}