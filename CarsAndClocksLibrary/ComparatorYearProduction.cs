using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarsAndClocksLibrary
{
    public class ComparatorYearProduction : IComparer<Car>
    {
        public int Compare(Car? x, Car? y)
        {
            if (x is null || y is null) return 0;
            return x.YearProduction.CompareTo(y.YearProduction);
        }
    }
}
