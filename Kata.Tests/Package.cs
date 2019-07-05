using System.Linq;

namespace UnitTestProject1
{
    public class Package
    {
        public int Height { get; set; }

        public int Width { get; set; }

        public int Depth { get; set; }

        public Package()
        {
        }

        public int LargestDimension
        {
            get
            {
                return Enumerable.Max(new []{ Height, Width, Depth });
            }
        }
    }

    public class Result
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