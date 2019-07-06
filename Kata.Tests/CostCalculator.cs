using System;
using System.Collections.Generic;
using System.Linq;

namespace UnitTestProject1
{
    public class CostCalculator
    {
        public CalcResult CalculateCharges(IEnumerable<Parcel> parcels)
        {
            return new CalcResult(parcels.Select(x => new ParcelCharge(x)));
        }
    }
}