namespace IteratorPattern.Iterator;

public class ArrayIterator<T> : IIterator<T>
    where T : class
{
    private readonly T?[] _array;
    private int _index;

    public ArrayIterator(T?[] array)
    {
        _array = array;
        _index = 0;
    }
    
    public bool HasNext()
    {
        return _index < _array.Length && _array[_index] != null;
    }

    public T? Next()
    {
        T? item = _array[_index];
        _index += 1;
        return item;
    }

    public void Remove()
    {
        throw new InvalidOperationException("Cannot remove from an array.");
    }

    public T? CurrentItem()
    {
        T? item = _array![_index];
        return item;
    }

    public int GetIteration()
    {
        return _index;
    }

    public IEnumerable<Item> GetList()
    {
        return (IEnumerable<Item>)_array.ToList();
    }
}