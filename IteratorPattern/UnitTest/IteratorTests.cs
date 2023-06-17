using System;
using System.Collections.Generic;
using IteratorPattern;
using IteratorPattern.Iterator;
using NUnit.Framework;

namespace UnitTest;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void ArrayIteratorShouldIterate()
    {
        var arr = new Item[] { new Item("Item1", 20M), new Item("Item2", 25M) };
        
        ArrayIterator<Item> arrayIterator =
            new ArrayIterator<Item>(arr);

        while (arrayIterator.HasNext())
        {
            var current = arrayIterator.CurrentItem();
            var iteration = arrayIterator.GetIteration();
            Assert.AreEqual(arr[iteration], current);
            Item? item = arrayIterator.Next();
            Console.WriteLine(item?.GetName());
        }
    }

    [Test]
    public void ListIteratorShouldIterate()
    {
        var list = new List<Item> { new Item("Item1", 20M), new Item("Item2", 25M) };
        ListIterator<Item> listIterator =
            new ListIterator<Item>(list);

        while (listIterator.HasNext())
        {
            var current = listIterator.CurrentItem();
            var iteration = listIterator.GetIteration();
            Assert.AreEqual(list[iteration], current);
            Item? item = listIterator.Next();
            Console.WriteLine(item?.GetName());
        }
    }

    [Test]
    public void IteratorShouldIterateOverDifferentCollectionTypes()
    {
        var fullCatalog = new FullCatalog<Item>(
            
            // an array of items
            new RetailSalePriceList<Item>(
                new Item[] { 
                    new("Item1", 20M), 
                    new("Item2", 25M) 
                }),
            
            // a list of items
            new WholeSalePriceList<Item>(
                new List<Item> { 
                    new("Item1", 10M), 
                    new("Item2", 12.50M) 
                })
        );
        fullCatalog.PrintCatalog();
    }
}







