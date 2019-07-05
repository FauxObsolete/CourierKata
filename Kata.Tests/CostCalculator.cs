using System;
using System.Collections.Generic;

namespace UnitTestProject1
{
    public class CostCalculator
    {
        public IEnumerable<Result> CalcCost(Package package)
        {
            if (package.LargestDimension < 10)
                yield return new Result { Cost = 3, Size = PackageSize.Small };
            if (package.LargestDimension < 50)
                yield return new Result { Cost = 8, Size = PackageSize.Medium };
            if (package.LargestDimension < 100)
                yield return new Result { Cost = 15, Size = PackageSize.Large };

            yield return new Result { Cost = 25, Size = PackageSize.XL };
        }
    }
}