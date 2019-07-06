﻿using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace UnitTestProject1
{
    [TestFixture]
    public class UnitTests
    {
        [TestCase(2, 1, 3, ParcelType.Small, 3)]
        [TestCase(1, 12, 43, ParcelType.Medium, 8)]
        [TestCase(67, 78, 1, ParcelType.Large, 15)]
        [TestCase(120, 40, 1, ParcelType.XL, 25)]
        public void TestSizeCharge(int height, int width, int length, ParcelType type, decimal cost)
        {
            // arrange
            var package = new Parcel(height, width, length, 0);

            // act
            var calc = new CostCalculator();
            var res = calc.CalcCost(new List<Parcel>() { package });

            // assert
            Assert.AreEqual(cost, res.Charges.First().TotalCharge);
            Assert.AreEqual(type, res.Charges.First().Type);
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

        [TestCase(20, ParcelType.Small, 38)]
        [TestCase(1, ParcelType.Small, 0)]
        [TestCase(20, ParcelType.Medium, 34)]
        [TestCase(2, ParcelType.Medium, 0)]
        [TestCase(20, ParcelType.Large, 28)]
        [TestCase(20, ParcelType.XL, 20)]
        public void TestOverweightCharge(int weight, ParcelType type, decimal overweightCharge)
        {
            // arrange
            Dictionary<ParcelType, Parcel> testParcels = new Dictionary<ParcelType, Parcel>()
            { {ParcelType.Small, new Parcel(2,2,2, weight) },
              {ParcelType.Medium, new Parcel(20,20,20, weight) },
              {ParcelType.Large, new Parcel(70,70,70, weight) },
              {ParcelType.XL, new Parcel(120,120,120, weight) },
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
