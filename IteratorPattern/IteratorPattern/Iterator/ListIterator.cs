namespace IteratorPattern.Iterator;

public class ListIterator<T> : IIterator<T>
{
    private readonly List<T>? _list;
    private int _index;
    
    public ListIterator(List<T>? list)
    {
        _list = list;
        _index = 0;
    }
    
    public bool HasNext()
    {
        return _index < _list!.Count && _list[_index] != null;
    }

    public T? Next()
    {
        T? item = _list![_index];
        _index++;
        return item;
    }

    public void Remove()
    {
        _list![_index] = default!;
    }

    public T? CurrentItem()
    {
        T? item = _list![_index];
        return item;
    }

    public int GetIteration()
    {
        return _index;
    }
}