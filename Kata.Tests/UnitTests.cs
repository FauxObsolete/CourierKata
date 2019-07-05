using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace UnitTestProject1
{
    [TestFixture]
    public class UnitTests
    {
        [TestCase(2, 1, 3, ParcelSize.Small, 3)]
        [TestCase(1, 12, 43, ParcelSize.Medium, 8)]
        [TestCase(67, 78, 1, ParcelSize.Large, 15)]
        [TestCase(120, 40, 1, ParcelSize.XL, 25)]
        public void TestSizeCharge(int height, int width, int length, ParcelSize type, decimal cost)
        {
            // arrange
            var package = new Parcel(height, width, length, 0);

            // act
            var calc = new CostCalculator();
            var res = calc.CalcCost(new List<Parcel>() { package });

            // assert
            Assert.AreEqual(cost, res.Charges.First().TotalCharge);
            Assert.AreEqual(type, res.Charges.First().Size);
        }

        [Test]
        public void TestTotals()
        {
            // arrange
            var order = new List<Parcel>
            {
                new Parcel(12,12,12,0),
                new Parcel(60,60,60,0),
                new Parcel(110,110,110,0)
            };

            //act 
            var calc = new CostCalculator();
            var res = calc.CalcCost(order);

            // assert
            Assert.AreEqual(48, res.Total);
            Assert.AreEqual(96, res.SpeedyTotal);

        }

        [TestCase(20, ParcelSize.Small, 38)]
        [TestCase(1, ParcelSize.Small, 0)]
        [TestCase(20, ParcelSize.Medium, 34)]
        [TestCase(2, ParcelSize.Medium, 0)]
        [TestCase(20, ParcelSize.Large, 28)]
        [TestCase(20, ParcelSize.XL, 20)]
        public void TestOverweightCharge(int weight, ParcelSize type, decimal overweightCharge)
        {
            // arrange
            Dictionary<ParcelSize, Parcel> testParcels = new Dictionary<ParcelSize, Parcel>()
            { {ParcelSize.Small, new Parcel(2,2,2, weight) },
              {ParcelSize.Medium, new Parcel(20,20,20, weight) },
              {ParcelSize.Large, new Parcel(70,70,70, weight) },
              {ParcelSize.XL, new Parcel(120,120,120, weight) },
             };

            var parcel = testParcels[type];
                            
            // act
            var calc = new CostCalculator();
            var res = calc.CalcCost(new List<Parcel>() { parcel });

            // assert
            Assert.AreEqual(overweightCharge, res.Charges.First().OverweightCharge);
        }
    }
}
