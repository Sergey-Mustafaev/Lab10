using System;
using System.Drawing;
using PrimitiveInterfacesLibrary;

namespace CarsAndClocksLibrary
{
    public class Car : IInit, IComparable<Car>, ICloneable
    {
        public const string defaultObjectName = "Автомобиль";
        public const int yearProductionMinValue = 0;
        public const int yearProductionMaxValue = 100_000;
        public const int costRubleMinValue = 0;
        public const int costRubleMaxValue = 1_000_000_000;
        public const int rideHeightMillimetersMinValue = 0;
        public const int rideHeightMillimetersMaxValue = 100_000;

        private protected static Random random = new Random();
        private protected static string[] trialBrands = { "Jeep", "Nissan", "Volvo" };
        private protected static string[] trialColors = { "Чёрный", "Белый", "Красный" };

        private protected IdNumber _idNumber;
        private protected string? _objectName = defaultObjectName;
        private protected string? _brand;
        private protected int _yearProduction;
        private protected string? _color;
        private protected int _costRuble;
        private protected int _rideHeightMillimeters;

        public int IdNumber { get => _idNumber.Number; set => _idNumber.Number = value; }

        public string? ObjectName
        {
            get
            {
                string? returnValue = _objectName;
                _objectName = defaultObjectName;
                return returnValue;
            }
            private protected set => _objectName = value;
        }

        public string? Brand { get => _brand; private protected set => _brand = value; }

        public int YearProduction
        {
            get => _yearProduction;
            private protected set
            {
                value = Math.Max(yearProductionMinValue, value);
                value = Math.Min(yearProductionMaxValue, value);
                _yearProduction = value;
            }
        }

        public string? Color { get => _color; private protected set => _color = value; }

        public int CostRuble
        {
            get => _costRuble;
            private protected set
            {
                value = Math.Max(costRubleMinValue, value);
                value = Math.Min(costRubleMaxValue, value);
                _costRuble = value;
            }
        }

        public int RideHeightMillimeters
        {
            get => _rideHeightMillimeters;
            private protected set
            {
                value = Math.Max(rideHeightMillimetersMinValue, value);
                value = Math.Min(rideHeightMillimetersMaxValue, value);
                _rideHeightMillimeters = value;
            }
        }

        public Car(string? brand = null, int yearProduction = yearProductionMinValue,
            string? color = null, int costRuble = costRubleMinValue, int rideHeightMillimeters = yearProductionMinValue)
        {
            _idNumber = new IdNumber();
            Brand = brand;
            YearProduction = yearProduction;
            Color = color;
            CostRuble = costRuble;
            RideHeightMillimeters = rideHeightMillimeters;
        }

        public Car(Car otherCar)
        {
            _idNumber = new IdNumber();
            Brand = otherCar.Brand;
            YearProduction = otherCar.YearProduction;
            Color = otherCar.Color;
            CostRuble = otherCar.CostRuble;
            RideHeightMillimeters = otherCar.RideHeightMillimeters;
        }

        public Car()
        {
            _idNumber = new IdNumber();
            Brand = null;
            YearProduction = yearProductionMinValue;
            Color = null;
            CostRuble = costRubleMinValue;
            RideHeightMillimeters = yearProductionMinValue;
        }

        private protected string PrivateToString()
        {
            string result = $"Информация об объекте {ObjectName}:\n";
            if (Brand != null)
            {
                result += $"Бренд: {Brand}\n";
            }
            else
            {
                result += $"Бренд неопределён\n";
            }
            if (YearProduction != yearProductionMinValue)
            {
                result += $"Год выпуска: {YearProduction}\n";
            }
            else
            {
                result += $"Значение года выпуска подозрительно: {YearProduction}\n";
            }
            if (Color != null)
            {
                result += $"Цвет: {Color}\n";
            }
            else
            {
                result += $"Цвет неопределён\n";
            }
            if (CostRuble != costRubleMinValue)
            {
                result += $"Стоимость в рублях: {CostRuble}\n";
            }
            else
            {
                result += $"Значение стоимости в рублях подозрительно: {CostRuble}\n";
            }
            if (RideHeightMillimeters != rideHeightMillimetersMinValue)
            {
                result += $"Высота дорожного просвета в миллиметрах: {RideHeightMillimeters}\n";
            }
            else
            {
                result += $"Значение высоты дорожного просвета в миллиметрах подозрительно: {RideHeightMillimeters}\n";
            }
            return result;
        }

        public override string ToString() => PrivateToString();

        public void NoVirtualShow() => InputOutput
            .MessageWithoutEndLine(this.PrivateToString(), $"Идентификационный номер: {IdNumber}\n");

        public virtual void Show() => InputOutput
            .MessageWithoutEndLine(this.PrivateToString(), $"Идентификационный номер: {IdNumber}\n");

        public virtual void Init()
        {
            InputOutput.Message($"Введите информацию об объекте {ObjectName}:");
            InputOutput.MessageWithoutEndLine("Бренд: ");
            Brand = InputOutput.GetString();
            InputOutput.MessageWithoutEndLine("Год выпуска: ");
            YearProduction = InputOutput.GetIntNumber(rideHeightMillimetersMinValue, rideHeightMillimetersMaxValue);
            InputOutput.MessageWithoutEndLine("Цвет: ");
            Color = InputOutput.GetString();
            InputOutput.MessageWithoutEndLine("Стоимость в рублях: ");
            CostRuble = InputOutput.GetIntNumber(costRubleMinValue, costRubleMaxValue);
            InputOutput.MessageWithoutEndLine("Высота дорожного просвета: ");
            RideHeightMillimeters = InputOutput.GetIntNumber(rideHeightMillimetersMinValue, rideHeightMillimetersMaxValue);
        }

        public virtual void RandomInit()
        {
            Brand = trialBrands[random.Next(0, trialBrands.Length)];
            YearProduction = random.Next(yearProductionMinValue + 1, yearProductionMaxValue + 1);
            Color = trialColors[random.Next(0, trialColors.Length)];
            CostRuble = random.Next(costRubleMinValue + 1, costRubleMaxValue + 1);
            RideHeightMillimeters = random.Next(rideHeightMillimetersMinValue + 1, rideHeightMillimetersMaxValue + 1);
        }

        public override bool Equals(object? obj)
        {
            if (obj is null || !(obj is Car))
                return false;
            Car other = (Car)obj;
            return this.Brand == other.Brand && this.YearProduction == other.YearProduction
                && this.Color == other.Color && this.CostRuble == other.CostRuble
                && this.RideHeightMillimeters == other.RideHeightMillimeters;
        }

        public override int GetHashCode() => this.ToString().GetHashCode();

        public virtual int CompareTo(Car? other)
        {
            if (!(other is null))
                return this.CostRuble.CompareTo(other.CostRuble);
            return 0;
        }

        public virtual object Clone()
        {
            Car returnCar = new Car(this);
            returnCar.IdNumber = this.IdNumber;
            return returnCar;
        }

        public virtual object ShallowCopy() => MemberwiseClone();

        public Car GetBase() => new Car(this);
    }
}
