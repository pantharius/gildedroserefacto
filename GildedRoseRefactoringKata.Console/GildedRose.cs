using System.Collections.Generic;

namespace GildedRoseRefactoringKata.IHMConsole
{
    public class GildedRose
    {
        IList<Item> Items;
        public GildedRose(IList<Item> Items)
        {
            this.Items = Items;
        }
        public void UpdateQuality()
        {
            foreach (Item item in Items)
            {
                if (item.IsSulfuras) continue;

                item.SellIn--;

                if (!item.IsQualityIncrWhenGetOlder)
                {
                    if (item.IsConjured)
                        item.Quality -= (item.SellIn < 0) ? 4 : 2;
                    else
                        item.Quality -= (item.SellIn < 0) ? 2 : 1;
                }
                else
                {
                    if (item.IsTicket)
                    {
                        if (item.SellIn < 0) item.Quality = 0;
                        else if (item.SellIn < 5) item.Quality += 3;
                        else if (item.SellIn < 10) item.Quality += 2;
                        else item.Quality+=1;
                    }
                    else
                    {
                        item.Quality += (item.SellIn < 0) ? 2 : 1;
                    }
                }

                if (item.Quality < 0) item.Quality = 0;
                if (item.Quality > 50) item.Quality = 50;
            }
        }
    }
}
