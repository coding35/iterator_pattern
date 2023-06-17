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
}