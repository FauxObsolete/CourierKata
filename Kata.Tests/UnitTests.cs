using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace UnitTestProject1
{
    [TestFixture]
    public class UnitTests
    {
        [TestCase(2, 1, 3, PackageSize.Small, 3)]
        [TestCase(1, 12, 43, PackageSize.Medium, 8)]
        [TestCase(67, 78, 1, PackageSize.Large, 15)]
        [TestCase(120, 40, 1, PackageSize.XL, 25)]
        public void TestGetCostsOfSinglePackage(int height, int width, int length, PackageSize type, decimal cost)
        {
            // arrange
            var package = new Parcel(height, width, length);

            // act
            var calc = new CostCalculator();
            var res = calc.CalcCost(new List<Parcel>() { package });

            // assert
            Assert.AreEqual(cost, res.Charges.First().Cost);
            Assert.AreEqual(type, res.Charges.First().Size);

        }

        [Test]
        public void TestTotals()
        {
            // arrange
            var order = new List<Parcel>
            {
                new Parcel(12,12,12),
                new Parcel(60,60,60),
                new Parcel(110,110,110)
            };

            //act 
            var calc = new CostCalculator();
            var res = calc.CalcCost(order);

            // assert
            Assert.AreEqual(48, res.Total);
            Assert.AreEqual(96, res.SpeedyTotal);

        }
    }
}
