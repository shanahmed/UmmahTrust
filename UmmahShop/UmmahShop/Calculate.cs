using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UmmahShop
{
    public class Calculate
    {

        public static decimal CalculatePrice(List<Dictionary<string, int>> bucketsList)
        {
            var perItemPrice = 20;
            decimal price = 0;
            var discounts = DiscountCategories();

            foreach (var item in bucketsList)
            {
                var quantity = item.Count;
                var discount = discounts[quantity];

                price = price + ((quantity * perItemPrice) * discount);
            }
            return price;
        }

        public static List<Dictionary<string, int>> DiscountBuckets(Dictionary<string, int> order)
        {
            List<Dictionary<string, int>> bucketsList = new List<Dictionary<string, int>>();


            var maxListCount = order.Values.Max();

            for (var i = 0; i < maxListCount; i++)
            {
                bucketsList.Add(new Dictionary<string, int>());
            }

            foreach (var item in order)
            {
                for (var i = 0; i < item.Value; i++)
                {
                    if (bucketsList.Any(x => x.ContainsKey(item.Key)))
                    {
                        var lastIndex = bucketsList.FindLastIndex(c => c.ContainsKey(item.Key));

                        bucketsList[lastIndex + 1].Add(item.Key, 1);
                    }
                    else
                    {
                        bucketsList[0].Add(item.Key, 1);
                    }

                }
            }
            return bucketsList;
        }

        private static Dictionary<int, decimal> DiscountCategories()
        {

            Dictionary<int, decimal> discounts = new Dictionary<int, decimal>();
            discounts.Add(1, 1m);
            discounts.Add(2, 0.95m);
            discounts.Add(3, 0.90m);
            discounts.Add(4, 0.80m);
            discounts.Add(5, 0.75m);

            return discounts;
        }
    }
}
