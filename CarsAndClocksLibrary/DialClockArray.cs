using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarsAndClocksLibrary
{
    public class DialClockArray
    {
        private DialClock[] _dialClockList;
        private int _length;

        private static int _objectCount = 0;

        public DialClock[] DialClockList
        {
            get => _dialClockList;
            private set => _dialClockList = value;
        }

        public DialClock this[int indexer]
        {
            get
            {
                if (indexer < 0 || indexer >= Length)
                    throw new IndexOutOfRangeException();
                return new DialClock(_dialClockList[indexer].Hours, _dialClockList[indexer].Minutes);
            }
            set
            {
                if (indexer >= 0 && indexer < Length)
                    _dialClockList[indexer] = new DialClock(value.Hours, value.Minutes);
            }
        }

        public int Length
        {
            get => _length;
            private set => _length = value;
        }

        public static int ObjectCount
        {
            get => _objectCount;
            private set => _objectCount = value;
        }

        public DialClockArray(int length)
        {
            if (length < 0)
                throw new ArgumentOutOfRangeException();
            Random random = new Random();
            Length = length;
            DialClockList = new DialClock[Length];
            for (int i = 0; i < Length; i++)
                DialClockList[i] = new DialClock(random.Next(1440));
            ObjectCount++;
        }

        public DialClockArray() : this(1) { }

        public DialClockArray(DialClockArray inputArray)
        {
            Length = inputArray.Length;
            DialClockList = new DialClock[Length];
            for (int i = 0; i < Length; i++)
                DialClockList[i] = inputArray[i];
            ObjectCount++;
        }

        public override bool Equals(object obj)
        {
            if (obj is null || !(obj is DialClockArray))
                return false;
            DialClockArray tempArray = (DialClockArray)obj;
            if (this.Length != tempArray.Length)
                return false;
            for (int i = 0; i < Length; i++)
            {
                if (!tempArray[i].Equals(this[i]))
                    return false;
            }
            return true;
        }

        public override string ToString()
        {
            if (Length <= 0)
                return "";
            string outputString = DialClockList[0].ToString();
            for (int i = 1; i < Length; i++)
                outputString += ", " + DialClockList[i].ToString();
            return outputString;
        }
    }
}
