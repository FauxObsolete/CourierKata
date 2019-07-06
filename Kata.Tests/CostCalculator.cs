using System;
using System.Collections.Generic;
using System.Linq;

namespace UnitTestProject1
{
    public class CostCalculator
    {
        private readonly Dictionary<ParcelType, decimal> WeightLimits
            = new Dictionary<ParcelType, decimal>(){
                { ParcelType.Small, 1 },
                { ParcelType.Medium, 3},
                { ParcelType.Large, 6},
                { ParcelType.XL, 10} };

        private const decimal OverweightChargePerKilo = 2;
        private const decimal HeavyChargeLimit = 50; 

        public CalcResult CalcCost(IEnumerable<Parcel> packages)
        {
            return new CalcResult(
                        packages.Select(x => SizeCalc(x))
                                .Select(x => OverWeightCalc(x)));
        }

        private ParcelCharge SizeCalc(Parcel parcel)
        {
            if (parcel.LargestDimension < 10)
                return new ParcelCharge(parcel) { SizeCharge = 3, Type = ParcelType.Small };
            if (parcel.LargestDimension < 50)
                return new ParcelCharge(parcel) { SizeCharge = 8, Type = ParcelType.Medium };
            if (parcel.LargestDimension < 100)
                return new ParcelCharge(parcel) { SizeCharge = 15, Type = ParcelType.Large };

            return new ParcelCharge(parcel) { SizeCharge = 25, Type = ParcelType.XL };
        }

        private ParcelCharge OverWeightCalc(ParcelCharge parcelCharge)
        {
            if (parcelCharge.Parcel.Weight > HeavyChargeLimit)
            {
                parcelCharge.Type = ParcelType.Heavy;
                overweight
                return parcelCharge; 
            }

            var weightLimit = WeightLimits[parcelCharge.Type];
            var overWeight = parcelCharge.Parcel.Weight - weightLimit;

            if (overWeight > 0)
                parcelCharge.OverweightCharge = OverweightChargePerKilo * overWeight;

            return parcelCharge;
        }
    }
}