namespace IteratorPattern.Iterator;

public interface IIterator<out T>
{
    bool HasNext();
    T? Next();
}