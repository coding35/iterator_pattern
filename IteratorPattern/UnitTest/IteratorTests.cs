using System;
using System.Collections.Generic;
using System.Reflection;
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
        ArrayIterator<Item> arrayIterator =
            new ArrayIterator<Item>(new Item[] { new Item("Item1", 20M), new Item("Item2", 25M) });

        while (arrayIterator.HasNext())
        {
            Item? item = arrayIterator.Next();
            Console.WriteLine(item?.GetName());
        }
    }

    [Test]
    public void ListIteratorShouldIterate()
    {
        ListIterator<Item> listIterator =
            new ListIterator<Item>(new List<Item> { new Item("Item1", 20M), new Item("Item2", 25M) });

        while (listIterator.HasNext())
        {
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
                new[] { 
                    new Item("Item1", 20M), 
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







