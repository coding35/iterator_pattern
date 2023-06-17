using IteratorPattern.Iterator;

namespace IteratorPattern;

public interface IFullCatalog<T> where T : class
{
    public IIterator<T> CreateIterator();
}