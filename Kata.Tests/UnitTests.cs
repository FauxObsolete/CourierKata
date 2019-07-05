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
        public void TestGetCostsOfPackage(int height, int width, int length, PackageSize type, decimal cost)
        {
            // arrange
            var calc = new CostCalculator();
            var package = new Package(height, width, length);

            // act
            var res = calc.CalcCost(new List<Package>() { package });

            // assert
            Assert.AreEqual(cost, res.Charges.First().Cost);
            Assert.AreEqual(type, res.Charges.First().Size);

        }
    }
}
