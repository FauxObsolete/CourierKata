using System.Collections.Generic;
using System.Linq;

namespace UnitTestProject1
{
    public class CalcResult
    {
        public CalcResult(IEnumerable<ParcelCharge> charges)
        {
            Charges = charges;
        }
        public decimal StandardShippingTotal
        {
            get
            {
                return Charges.Sum(x => x.TotalCharge);
            }
        }

        public IEnumerable<ParcelCharge> Charges { get; }

        public decimal SpeedyShippingTotal
        {
            get
            {
                return 2 * StandardShippingTotal;
            }
        }
    }
}