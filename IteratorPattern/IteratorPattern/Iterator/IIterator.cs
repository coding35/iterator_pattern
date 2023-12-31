namespace IteratorPattern.Iterator;

public interface IIterator<out T>
{
    bool HasNext();
    T? Next();
    void Remove();
    T? CurrentItem();
    int GetIteration();
    IEnumerable<Item> GetList();
}