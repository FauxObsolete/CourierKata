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
}