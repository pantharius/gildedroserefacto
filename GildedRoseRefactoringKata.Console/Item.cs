using System;

namespace GildedRoseRefactoringKata.IHMConsole
{
    public class Item
    {
        public string Name { get; set; }
        public int SellIn { get; set; }
        public int Quality { get; set; }

        public override string ToString()
        {
            return this.Name + ", " + this.SellIn + ", " + this.Quality;
        }

        public bool IsConjured => (this.Name == "Conjured Mana Cake");
        public bool IsSulfuras => (this.Name == "Sulfuras, Hand of Ragnaros");
        public bool IsQualityIncrWhenGetOlder => (this.Name == "Aged Brie" || this.IsTicket);
        public bool IsTicket => (this.Name == "Backstage passes to a TAFKAL80ETC concert");
    }
}
