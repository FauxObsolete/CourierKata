using System.Collections.Generic;
using System.Linq;

namespace UnitTestProject1
{
    public class Parcel
    {
        public Parcel(int height, int width, int length)
        {
            Height = height;
            Width = width;
            Length = length;
        }

        public int Height { get; }

        public int Width { get; }

        public int Length { get; }

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
        public CalcResult(IEnumerable<PackageCharge> charges)
        {
            Charges = charges;
        }
        public decimal Total
        {
            get
            {
                return Charges.Sum(x => x.Cost);
            }
        }

        public IEnumerable<PackageCharge> Charges { get; }

        public decimal SpeedyTotal
        {
            get
            {
                return 2 * Total;
            }
        }
    }

    public class PackageCharge
    {
        public decimal Cost { get; set; }
        public PackageSize Size { get; set; }
    }

    public enum PackageSize
    {
        Small,
        Medium,
        Large,
        XL
    }
}