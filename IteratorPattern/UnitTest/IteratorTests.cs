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
        var arr = new [] { new Item("Item1", 20M), new Item("Item2", 25M) };
        
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
    public void DictionaryIteratorShouldIterate()
    {
        var list = new Dictionary<int, Item>
        {
            { 0, new Item("Item1", 20M) },
            { 1, new Item("Item2", 25M) }
        };
        DictionaryIterator<Item> dictionaryIterator =
            new DictionaryIterator<Item>(list);

        while (dictionaryIterator.HasNext())
        {
            var current = dictionaryIterator.CurrentItem();
            var iteration = dictionaryIterator.GetIteration();
            Assert.AreEqual(list[iteration], current);
            Item? item = dictionaryIterator.Next();
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
                }),
            
            // a dictionary of items
            new PartnerPriceList<Item>(
                new Dictionary<int, Item>
                {
                    { 0, new Item("Item1", 12M) },
                    { 1, new Item("Item2", 14.25M) }
                })
        );
        fullCatalog.PrintCatalog();
    }
    
    [Test]
    public void IteratorShouldIterateOverCombinedCollectionTypes()
    {

            // an array of items
            var retail = new RetailSalePriceList<Item>(
                new Item[]
                {
                    new("Item1", 20M),
                    new("Item2", 25M)
                });
            
            // a list of items
            var wholesale = new WholeSalePriceList<Item>(
                new List<Item>
                {
                    new("Item1", 10M),
                    new("Item2", 12.50M)
                });
            
            // a dictionary of items
            var partner = new PartnerPriceList<Item>(
                new Dictionary<int, Item>
                {
                    { 0, new Item("Item1", 12M) },
                    { 1, new Item("Item2", 14.25M) }
                });

            var list = new List<Item>();
            list.AddRange(retail.CreateIterator().GetList());
            list.AddRange(wholesale.CreateIterator().GetList());
            list.AddRange(partner.CreateIterator().GetList());
            
        var simpleCatalog = new SimpleCatalog<Item>(list);
        
        simpleCatalog.PrintCatalog();
    }
}







