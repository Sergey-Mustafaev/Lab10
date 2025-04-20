using System.Runtime.ConstrainedExecution;

namespace CarsAndClocksLibrary
{
    public class PassengerCar : Car
    {
        public new const string defaultObjectName = "Легковой автомобиль";
        public const int seatsNumberMinValue = 0;
        public const int seatsNumberMaxValue = 100;
        public const int maximumSpeedKilometersPerHourMinValue = 0;
        public const int maximumSpeedKilometersPerHourMaxValue = 10_000;

        private protected new string? _objectName = defaultObjectName;
        private protected int _seatsNumber;
        private protected int _maximumSpeedKilometersPerHour;

        public new string? ObjectName
        {
            get
            {
                string? returnValue = _objectName;
                _objectName = defaultObjectName;
                return returnValue;
            }
            private protected set => _objectName = value;
        }

        public int SeatsNumber
        {
            get => _seatsNumber;
            private protected set
            {
                value = Math.Max(seatsNumberMinValue, value);
                value = Math.Min(seatsNumberMaxValue, value);
                _seatsNumber = value;
            }
        }

        public int MaximumSpeedKilometersPerHour
        {
            get => _maximumSpeedKilometersPerHour;
            private protected set
            {
                value = Math.Max(maximumSpeedKilometersPerHourMinValue, value);
                value = Math.Min(maximumSpeedKilometersPerHourMaxValue, value);
                _maximumSpeedKilometersPerHour = value;
            }
        }

        public PassengerCar(string? brand = null, int yearProduction = yearProductionMinValue,
            string? color = null, int costRuble = costRubleMinValue, int rideHeightMillimeters = yearProductionMinValue,
            int seatsNumber = seatsNumberMinValue, int maximumSpeedKilometersPerHour = maximumSpeedKilometersPerHourMinValue)
            : base(brand, yearProduction, color, costRuble, rideHeightMillimeters)
        {

            SeatsNumber = seatsNumber;
            MaximumSpeedKilometersPerHour = maximumSpeedKilometersPerHour;
        }

        public PassengerCar(PassengerCar otherCar) : base(otherCar)
        {
            SeatsNumber = otherCar.SeatsNumber;
            MaximumSpeedKilometersPerHour = otherCar.MaximumSpeedKilometersPerHour;
        }

        public PassengerCar() : base()
        {
            SeatsNumber = seatsNumberMinValue;
            MaximumSpeedKilometersPerHour = maximumSpeedKilometersPerHourMinValue;
        }

        private protected new string PrivateToString()
        {
            base.ObjectName = this.ObjectName;
            string result = base.PrivateToString();
            if (SeatsNumber != seatsNumberMinValue)
            {
                result += $"Количество мест: {SeatsNumber}\n";
            }
            else
            {
                result += $"Значение количества мест подозрительно: {SeatsNumber}\n";
            }
            if (MaximumSpeedKilometersPerHour != maximumSpeedKilometersPerHourMinValue)
            {
                result += $"Максимальная скорость: {MaximumSpeedKilometersPerHour}\n";
            }
            else
            {
                result += $"Значение максимальной скорости подозрительно: {MaximumSpeedKilometersPerHour}\n";
            }
            return result;
        }

        public override string ToString() => PrivateToString();

        public new void NoVirtualShow() => InputOutput
            .MessageWithoutEndLine(this.PrivateToString(), $"Идентификационный номер: {IdNumber}\n");

        public override void Show() => InputOutput
            .MessageWithoutEndLine(this.PrivateToString(), $"Идентификационный номер: {IdNumber}\n");

        public override void Init()
        {
            base.ObjectName = this.ObjectName;
            base.Init();
            InputOutput.MessageWithoutEndLine("Количество мест: ");
            SeatsNumber = InputOutput.GetIntNumber(seatsNumberMinValue, seatsNumberMaxValue);
            InputOutput.MessageWithoutEndLine("Максимальная скорость: ");
            MaximumSpeedKilometersPerHour = InputOutput
                .GetIntNumber(maximumSpeedKilometersPerHourMinValue, maximumSpeedKilometersPerHourMaxValue);
        }

        public override void RandomInit()
        {
            base.ObjectName = this.ObjectName;
            base.RandomInit();
            SeatsNumber = random.Next(seatsNumberMinValue + 1, seatsNumberMaxValue + 1);
            MaximumSpeedKilometersPerHour = random.Next(maximumSpeedKilometersPerHourMinValue + 1,
                maximumSpeedKilometersPerHourMaxValue + 1);
        }

        public override bool Equals(object? obj)
        {
            if (obj == null || !(obj is PassengerCar))
                return false;
            PassengerCar other = (PassengerCar)obj;
            return base.Equals((Car)obj) && this.SeatsNumber == other.SeatsNumber
                && this.MaximumSpeedKilometersPerHour == other.MaximumSpeedKilometersPerHour;
        }

        public override int GetHashCode() => this.ToString().GetHashCode();

        public override object Clone()
        {
            PassengerCar returnCar = new PassengerCar(this);
            returnCar.IdNumber = this.IdNumber;
            return returnCar;
        }
    }
}