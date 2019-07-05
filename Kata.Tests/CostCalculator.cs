using System;
using System.Collections.Generic;
using System.Linq;

namespace UnitTestProject1
{
    public class CostCalculator
    {
        public CalcResult CalcCost(IEnumerable<Parcel> packages)
        {
            return new CalcResult(packages.Select(x => DoSizeCalc(x)));
        }

        private PackageCharge DoSizeCalc(Parcel package)
        {
            if (package.LargestDimension < 10)
                return new PackageCharge { Cost = 3, Size = PackageSize.Small };
            if (package.LargestDimension < 50)
                return new PackageCharge { Cost = 8, Size = PackageSize.Medium };
            if (package.LargestDimension < 100)
                return new PackageCharge { Cost = 15, Size = PackageSize.Large };

            return new PackageCharge { Cost = 25, Size = PackageSize.XL };
        }
    }
}