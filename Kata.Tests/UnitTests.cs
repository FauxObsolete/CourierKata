using System;
using System.Linq;
using NUnit.Framework;

namespace UnitTestProject1
{
    [TestFixture]
    public class UnitTest1
    {
        [TestCase(2, 1, 3, PackageSize.Small, 3)]
        [TestCase(1, 12, 43, PackageSize.Medium, 8)]
        [TestCase(67, 78, 1, PackageSize.Large, 15)]
        [TestCase(120, 78, 1, PackageSize.XL, 25)]
        public void TestGetCost(int height, int width, int depth, PackageSize type, decimal cost)
        {
            var x = new CostCalculator();

            var pack = new Package() { Height = height, Width = width, Depth = depth };

            var res = x.CalcCost(pack).First();

            Assert.AreEqual(cost, res.Cost);
            Assert.AreEqual(type, res.Size);

        }
    }
}
