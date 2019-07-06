using System.Collections.Generic;

namespace UnitTestProject1
{
    public class ParcelCharge
    {
        private const decimal OverweightSurchargePerKiloStandard = 2;
        private const decimal OverweightSurchargePerKiloHeavy = 1;

        private readonly Dictionary<ParcelType, decimal> WeightLimits
            = new Dictionary<ParcelType, decimal>(){
                { ParcelType.Small, 1 },
                { ParcelType.Medium, 3},
                { ParcelType.Large, 6},
                { ParcelType.XL, 10} ,
                { ParcelType.Heavy, 50}
        };

        private readonly Dictionary<ParcelType, decimal> CategoryCharges
            = new Dictionary<ParcelType, decimal>()
            {
                { ParcelType.Small, 3},
                { ParcelType.Medium, 8},
                { ParcelType.Large, 15},
                { ParcelType.XL, 25},
                { ParcelType.Heavy, 50 }
            };

        public ParcelCharge(Parcel parcel)
        {
            Parcel = parcel;
            Type = CategorizeParcel(parcel);
            SizeCharge = CategoryCharges[Type];
            OverweightSurcharge = CalculateOverWeightSurcharge();
        }
        public decimal TotalCharge
        {
            get
            {
                return SizeCharge + OverweightSurcharge;
            }
        }
        public decimal OverweightSurcharge { get; }
        public decimal SizeCharge { get; }
        public ParcelType Type { get; }
        public Parcel Parcel { get; }

        private ParcelType CategorizeParcel(Parcel parcel)
        {
            if (parcel.Weight > WeightLimits[ParcelType.Heavy])
                return ParcelType.Heavy;
            if (parcel.LargestDimension < 10)
                return ParcelType.Small;
            if (parcel.LargestDimension < 50)
                return ParcelType.Medium;
            if (parcel.LargestDimension < 100)
                return ParcelType.Large;

            return ParcelType.XL;
        }

        private decimal CalculateOverWeightSurcharge()
        {
            var overWeight = Parcel.Weight - WeightLimits[Type];

            var weightMultiplier = (Type == ParcelType.Heavy)
                ? OverweightSurchargePerKiloHeavy : OverweightSurchargePerKiloStandard;

            return (overWeight > 0) ?
               weightMultiplier * overWeight : 0;
        }
    }
}