using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarsAndClocksLibrary
{
    public class DialClock : IInit
    {
        private int _hours;
        private int _minutes;

        private static int _objectCount = 0;

        public int Hours
        {
            get => _hours;
            private set
            {
                _hours = ((value) % 24 + 24) % 24;
            }
        }
        public int Minutes
        {
            get => _minutes;
            private set
            {
                int intermediateCalculation = value % 60 + 60;
                Hours += value / 60 + intermediateCalculation / 60 - 1;
                _minutes = intermediateCalculation % 60;
            }
        }

        public static int ObjectCount
        {
            get => _objectCount;
            private set => _objectCount = value;
        }

        public DialClock() : this(0) { }

        public DialClock(int minutes)
        {
            Minutes = minutes;
            Hours = (minutes - Minutes) / 60;
            ObjectCount++;
        }

        public DialClock(int hours, int minutess)
        {
            Hours = hours;
            Minutes = minutess;
            ObjectCount++;
        }

        public static explicit operator bool(DialClock clock)
        {
            int checkNumber = (int)Math.Round(clock.CalculateClockHandsAngle() * 2);
            return checkNumber % 5 == 0;
        }
        public static implicit operator int(DialClock clock) => (clock.Hours % 12) * 60 + clock.Minutes;

        public static DialClock operator +(DialClock clock) => new DialClock(clock.Hours, clock.Minutes);

        public static DialClock operator -(DialClock clock) => new DialClock(-clock.Hours, -clock.Minutes);

        public static DialClock operator ++(DialClock clock) => new DialClock(clock.Hours, clock.Minutes + 1);

        public static DialClock operator --(DialClock clock) => new DialClock(clock.Hours, clock.Minutes - 1);

        public static DialClock operator +(DialClock clock, int minutes) => new DialClock(clock.Hours, clock.Minutes + minutes);

        public static DialClock operator +(int minutes, DialClock clock) => clock + minutes;

        public static DialClock operator -(DialClock clock, int minutes) => clock + (-minutes);

        public static DialClock operator -(int minutes, DialClock clock) => minutes + (-clock);
        public static bool operator >(DialClock a, DialClock b)
            => a.CalculateClockHandsAngle() > b.CalculateClockHandsAngle();

        public static bool operator <(DialClock a, DialClock b)
            => a.CalculateClockHandsAngle() < b.CalculateClockHandsAngle();

        public static bool operator >=(DialClock a, DialClock b)
            => a.CalculateClockHandsAngle() >= b.CalculateClockHandsAngle();

        public static bool operator <=(DialClock a, DialClock b)
            => a.CalculateClockHandsAngle() <= b.CalculateClockHandsAngle();

        public override bool Equals(object obj)
        {
            if (obj is null || !(obj is DialClock))
                return false;
            DialClock tempClock = (DialClock)obj;
            return tempClock.Hours == this.Hours && tempClock.Minutes == this.Minutes;
        }

        public override string ToString() => this.Hours.ToString("00", CultureInfo.CreateSpecificCulture("ru-RU"))
            + ":" + this.Minutes.ToString("00", CultureInfo.CreateSpecificCulture("ru-RU"));

        public double CalculateClockHandsAngle()
        {
            int minutAngle = Minutes * 12;
            int hourAngle = Hours * 60 + Minutes;
            int deltaAngle = Math.Abs(hourAngle - minutAngle) % 720;
            int shortestAngle = Math.Min(deltaAngle, 720 - deltaAngle);
            double returnAngle = (double)shortestAngle / 2.0;
            return returnAngle;
        }
        public static double CalculateClockHandsAngle(DialClock clock)
        {
            int minutAngle = clock.Minutes * 12;
            int hourAngle = clock.Hours * 60 + clock.Minutes;
            int deltaAngle = Math.Abs(hourAngle - minutAngle) % 720;
            int shortestAngle = Math.Min(deltaAngle, 720 - deltaAngle);
            double returnAngle = (double)shortestAngle / 2.0;
            return returnAngle;
        }

        public void Init()
        {
            InputOutput.Message("Введите информацию об объекте Часы:");
            InputOutput.MessageWithoutEndLine("Значения часа: ");
            Hours = InputOutput.GetIntNumber(0, 23);
            InputOutput.MessageWithoutEndLine("Значение минуты: ");
            Minutes = InputOutput.GetIntNumber(0, 59);
        }

        public void RandomInit()
        {
            Random random = new Random();
            InputOutput.Message("Инициализация объекта Часы с помощью ГСЧ.");
            Hours = random.Next(0, 24);
            Minutes = random.Next(0, 60);
        }
    }
}
