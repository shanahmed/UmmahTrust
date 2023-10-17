using Microsoft.VisualStudio.TestTools.UnitTesting;
using UmmahShop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace UmmahShop.Tests
{
    [TestClass()]
    public class CalculateTests
    {
        [TestMethod()]
        public void DiscountBucketsCountTest()
        {
            var expectedResult = 2;

            var order = new Dictionary<string, int>();
            order.Add("White", 2);
            order.Add("Black", 2);
            order.Add("Grey", 2);
            order.Add("Green", 1);
            order.Add("Blue", 1);

            List<Dictionary<string, int>> result = Calculate.DiscountBuckets(order);

            Assert.AreEqual(expectedResult, result.Count);
            Assert.AreNotEqual(6, result.Count);



        }

        [TestMethod()]
        public void DiscountBucketsInstanceTest()
        {
            var order = new Dictionary<string, int>();
            order.Add("White", 4);
            order.Add("Black", 3);
            order.Add("Grey", 2);
            order.Add("Green", 1);
            order.Add("Blue", 1);

            List<Dictionary<string, int>> result = Calculate.DiscountBuckets(order);

            Assert.IsInstanceOfType(result, typeof(List<Dictionary<string, int>>));
            Assert.IsNotInstanceOfType(result, typeof(List<Dictionary<int, string>>));
        }

        [TestMethod()]
        public void DiscountBucketsDataTest()
        {
            var expectedCount = 4;
            var expectedData = new List<Dictionary<string, int>>();
            expectedData.Add(new Dictionary<string, int>
            {
                { "White", 1 },
                { "Black", 1 },
                { "Grey", 1 },
                { "Green", 1 },
                { "Blue", 1 },
            });
            expectedData.Add(new Dictionary<string, int>
            {
                { "White", 1 },
                { "Black", 1 },
                { "Grey", 1 },

            });
            expectedData.Add(new Dictionary<string, int>
            {
                { "White", 1 },
                { "Black", 1 },

            });
            expectedData.Add(new Dictionary<string, int>
            {
                { "White", 1 },


            }); ;

            var order = new Dictionary<string, int>();
            order.Add("White", 4);
            order.Add("Black", 3);
            order.Add("Grey", 2);
            order.Add("Green", 1);
            order.Add("Blue", 1);

            List<Dictionary<string, int>> result = Calculate.DiscountBuckets(order);

            Assert.AreEqual(expectedCount, result.Count);

            CollectionAssert.AreEqual(expectedData[0], result[0]);
            CollectionAssert.AreEqual(expectedData[1], result[1]);
            CollectionAssert.AreEqual(expectedData[2], result[2]);
            CollectionAssert.AreEqual(expectedData[3], result[3]);

            CollectionAssert.AllItemsAreUnique(result);

            CollectionAssert.AllItemsAreNotNull(result);
        }

        [TestMethod()]
        public void CalculatePriceTest()
        {
            decimal expectedResult = 129.00m;

            var bucketsList = new List<Dictionary<string, int>>();
            bucketsList.Add(new Dictionary<string, int>
            {
                { "White", 1 },
                { "Black", 1 },
                { "Grey", 1 },
                { "Green", 1 },
                { "Blue", 1 },
            });
            bucketsList.Add(new Dictionary<string, int>
            {
                { "White", 1 },
                { "Black", 1 },
                { "Grey", 1 },

            });
          
            decimal result = Calculate.CalculatePrice(bucketsList);

            Assert.AreEqual(expectedResult, result);
        }
    }
}