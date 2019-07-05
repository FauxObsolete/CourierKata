using System;
using System.Collections.Generic;
using System.Linq;

namespace UnitTestProject1
{
    public class CostCalculator
    {
        private readonly Dictionary<ParcelSize, decimal> WeightLimits
            = new Dictionary<ParcelSize, decimal>(){
                { ParcelSize.Small, 1 },
                { ParcelSize.Medium, 3},
                { ParcelSize.Large, 6},
                { ParcelSize.XL, 10} };

        private const decimal OverweightChargePerKilo = 2.0m; 

        public CalcResult CalcCost(IEnumerable<Parcel> packages)
        {
            return new CalcResult(
                        packages.Select(x => SizeCalc(x))
                                .Select(x => OverWeightCalc(x)));
        }

        private ParcelCharge SizeCalc(Parcel parcel)
        {
            if (parcel.LargestDimension < 10)
                return new ParcelCharge(parcel) { SizeCharge = 3, Size = ParcelSize.Small };
            if (parcel.LargestDimension < 50)
                return new ParcelCharge(parcel) { SizeCharge = 8, Size = ParcelSize.Medium };
            if (parcel.LargestDimension < 100)
                return new ParcelCharge(parcel) { SizeCharge = 15, Size = ParcelSize.Large };

            return new ParcelCharge(parcel) { SizeCharge = 25, Size = ParcelSize.XL };
        }

        private ParcelCharge OverWeightCalc(ParcelCharge parcelCharge)
        {
            var weightLimit = WeightLimits[parcelCharge.Size];
            var overWeight = parcelCharge.Parcel.Weight - weightLimit;

            if (overWeight > 0)
                parcelCharge.OverweightCharge = OverweightChargePerKilo * overWeight;

            return parcelCharge;
        }
    }
}