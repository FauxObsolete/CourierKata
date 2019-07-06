using System.Collections.Generic;
using System.Linq;

namespace UnitTestProject1
{
    public class Parcel
    {
        public Parcel(int height, int width, int length, int weight)
        {
            Height = height;
            Width = width;
            Length = length;
            Weight = weight;
        }

        public int Height { get; }

        public int Width { get; }

        public int Length { get; }

        public int Weight { get; }

        public int LargestDimension
        {
            get
            {
                return Enumerable.Max(new[] { Height, Width, Length });
            }
        }
    }

    public class CalcResult
    {
        public CalcResult(IEnumerable<ParcelCharge> charges)
        {
            Charges = charges;
        }
        public decimal Total
        {
            get
            {
                return Charges.Sum(x => x.TotalCharge);
            }
        }

        public IEnumerable<ParcelCharge> Charges { get; }

        public decimal SpeedyTotal
        {
            get
            {
                return 2 * Total;
            }
        }
    }

    public class ParcelCharge
    {
        public ParcelCharge(Parcel parcel)
        {
            Parcel = parcel;
        }
        public decimal TotalCharge
        {
            get
            {
                return OverweightCharge + SizeCharge;
            }
        }
        public decimal OverweightCharge { get; set; }
        public decimal SizeCharge { get; set; }
        public ParcelType Type { get; set; }
        public Parcel Parcel { get; }
    }

    public enum ParcelType
    {
        Small,
        Medium,
        Large,
        XL,
        Heavy,
    }
}