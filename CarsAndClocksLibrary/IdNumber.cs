using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarsAndClocksLibrary
{
    public class IdNumber
    {
        private protected static int _countNumbers = 0;

        private protected int _number;

        public int Number
        {
            get => _number;
            internal set
            {
                value = Math.Max(0, value);
                _number = value;
            }
        }

        public int CountNumbers
        {
            get => _countNumbers;
            private protected set
            {
                value = Math.Max(0, value);
                _countNumbers = value;
            }
        }

        public IdNumber()
        {
            Number = CountNumbers;
            CountNumbers++;
        }

        public override string ToString() => this.Number.ToString();

        public override bool Equals(object? obj)
        {
            if (obj is null || !(obj is IdNumber))
                return false;
            IdNumber other = (IdNumber)obj;
            return other.Number == this.Number;
        }

        public override int GetHashCode() => Number;
    }
}
