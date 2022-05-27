using GildedRoseRefactoringKata.IHMConsole;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace GildedRoseRefactoringKata.UnitTests
{
    [TestClass]
    public class GildedRoseTest
    {
        [TestMethod]
        public void UpdateQuality_ShouldLowerQualityOfITems()
        {
            IList<Item> Items = new List<Item> {
                new Item { Name = "test1", SellIn = 3, Quality = 2 },
                new Item { Name = "test2", SellIn = 2, Quality = 3 }
            };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual(2, Items[0].SellIn);
            Assert.AreEqual(1, Items[0].Quality);
            Assert.AreEqual(1, Items[1].SellIn);
            Assert.AreEqual(2, Items[1].Quality);
            app.UpdateQuality();
            Assert.AreEqual(1, Items[0].SellIn);
            Assert.AreEqual(0, Items[0].Quality);
            Assert.AreEqual(0, Items[1].SellIn);
            Assert.AreEqual(1, Items[1].Quality);
        }

        [TestMethod]
        public void UpdateQuality_ShouldLowerTwiceQuality_WhenSellInPassed()
        {
            IList<Item> Items = new List<Item> {
                new Item { Name = "test1", SellIn = 0, Quality = 20 },
                new Item { Name = "test2", SellIn = 0, Quality = 30 }
            };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual(-1, Items[0].SellIn);
            Assert.AreEqual(18, Items[0].Quality);
            Assert.AreEqual(-1, Items[1].SellIn);
            Assert.AreEqual(28, Items[1].Quality);
            app.UpdateQuality();
            Assert.AreEqual(-2, Items[0].SellIn);
            Assert.AreEqual(16, Items[0].Quality);
            Assert.AreEqual(-2, Items[1].SellIn);
            Assert.AreEqual(26, Items[1].Quality);
        }

        [TestMethod]
        public void UpdateQuality_ShouldNeverPassQualityToNegative()
        {
            IList<Item> Items = new List<Item> {
                new Item { Name = "test1", SellIn = 2, Quality = 3 },
                new Item { Name = "test2", SellIn = 0, Quality = 0 },
            };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            app.UpdateQuality();
            app.UpdateQuality();
            Assert.AreEqual(-1, Items[0].SellIn);
            Assert.AreEqual(0, Items[0].Quality);
            Assert.AreEqual(-3, Items[1].SellIn);
            Assert.AreEqual(0, Items[1].Quality);
        }

        [TestMethod]
        public void UpdateQuality_ShouldIncreaseTwiceQualityOnAgedBrie()
        {
            IList<Item> Items = new List<Item> {
                new Item { Name = "Aged Brie", SellIn = 2, Quality = 3 },
                new Item { Name = "Aged Brie", SellIn = 20, Quality = 0 },
            };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual(1, Items[0].SellIn);
            Assert.AreEqual(4, Items[0].Quality);
            Assert.AreEqual(19, Items[1].SellIn);
            Assert.AreEqual(1, Items[1].Quality);
            app.UpdateQuality();
            Assert.AreEqual(0, Items[0].SellIn);
            Assert.AreEqual(5, Items[0].Quality);
            Assert.AreEqual(18, Items[1].SellIn);
            Assert.AreEqual(2, Items[1].Quality);
        }

        [TestMethod]
        public void UpdateQuality_ShouldIncreaseTwiceQualityOnAgedBrie_WhenSellInPassed()
        {
            IList<Item> Items = new List<Item> {
                new Item { Name = "Aged Brie", SellIn = -1, Quality = 3 },
                new Item { Name = "Aged Brie", SellIn = -1, Quality = 0 },
            };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual(-2, Items[0].SellIn);
            Assert.AreEqual(5, Items[0].Quality);
            Assert.AreEqual(-2, Items[1].SellIn);
            Assert.AreEqual(2, Items[1].Quality);
            app.UpdateQuality();
            Assert.AreEqual(-3, Items[0].SellIn);
            Assert.AreEqual(7, Items[0].Quality);
            Assert.AreEqual(-3, Items[1].SellIn);
            Assert.AreEqual(4, Items[1].Quality);
        }

        [TestMethod]
        public void UpdateQuality_ShouldNeverPassQualityUpMoreThan50()
        {
            IList<Item> Items = new List<Item> {
                new Item { Name = "Aged Brie", SellIn = 2, Quality = 49 },
                new Item { Name = "Aged Brie", SellIn = 15, Quality = 50 },
            };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            app.UpdateQuality();
            app.UpdateQuality();
            Assert.AreEqual(-1, Items[0].SellIn);
            Assert.AreEqual(50, Items[0].Quality);
            Assert.AreEqual(12, Items[1].SellIn);
            Assert.AreEqual(50, Items[1].Quality);
        }

        [TestMethod]
        public void UpdateQuality_ShouldNeverChangeSulfuras()
        {
            IList<Item> Items = new List<Item> {
                new Item { Name = "Sulfuras, Hand of Ragnaros",  SellIn = -1, Quality = 80 },
                new Item { Name = "Sulfuras, Hand of Ragnaros",  SellIn = 0, Quality = 80 },
            };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            app.UpdateQuality();
            app.UpdateQuality();
            Assert.AreEqual(-1, Items[0].SellIn);
            Assert.AreEqual(80, Items[0].Quality);
            Assert.AreEqual(0, Items[1].SellIn);
            Assert.AreEqual(80, Items[1].Quality);
        }

        [TestMethod]
        public void UpdateQuality_ShouldIncreaseQualityOnTicket()
        {
            IList<Item> Items = new List<Item> {
                new Item { Name = "Backstage passes to a TAFKAL80ETC concert",  SellIn = 11, Quality = 5 },
                new Item { Name = "Backstage passes to a TAFKAL80ETC concert",  SellIn = 6, Quality = 12 },
            };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual(10, Items[0].SellIn);
            Assert.AreEqual(6, Items[0].Quality);
            Assert.AreEqual(5, Items[1].SellIn);
            Assert.AreEqual(14, Items[1].Quality);
            app.UpdateQuality();
            Assert.AreEqual(9, Items[0].SellIn);
            Assert.AreEqual(8, Items[0].Quality);
            Assert.AreEqual(4, Items[1].SellIn);
            Assert.AreEqual(17, Items[1].Quality);
            app.UpdateQuality();
            Assert.AreEqual(8, Items[0].SellIn);
            Assert.AreEqual(10, Items[0].Quality);
            Assert.AreEqual(3, Items[1].SellIn);
            Assert.AreEqual(20, Items[1].Quality);
        }

        [TestMethod]
        public void UpdateQuality_ShouldSetQualityToZeroOnTicket_WhenSellInPassed()
        {
            IList<Item> Items = new List<Item> {
                new Item { Name = "Backstage passes to a TAFKAL80ETC concert",  SellIn = 1, Quality = 41 },
                new Item { Name = "Backstage passes to a TAFKAL80ETC concert",  SellIn = 0, Quality = 35 },
            };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual(0, Items[0].SellIn);
            Assert.AreEqual(44, Items[0].Quality);
            Assert.AreEqual(-1, Items[1].SellIn);
            Assert.AreEqual(0, Items[1].Quality);
            app.UpdateQuality();
            Assert.AreEqual(-1, Items[0].SellIn);
            Assert.AreEqual(0, Items[0].Quality);
            Assert.AreEqual(-2, Items[1].SellIn);
            Assert.AreEqual(0, Items[1].Quality);
        }
    }
}
