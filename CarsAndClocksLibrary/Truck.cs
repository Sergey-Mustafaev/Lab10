using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarsAndClocksLibrary
{
    public class Truck : Car
    {
        public new const string defaultObjectName = "Грузовой автомобиль";
        public const int loadCapacityTonsMinValue = 0;
        public const int loadCapacityTonsMaxValue = 10_000;

        private protected new string? _objectName = defaultObjectName;
        private protected int _loadCapacityTons;

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

        public int LoadCapacityTons
        {
            get => _loadCapacityTons;
            private protected set
            {
                value = Math.Max(loadCapacityTonsMinValue, value);
                value = Math.Min(loadCapacityTonsMaxValue, value);
                _loadCapacityTons = value;
            }
        }

        public Truck(string? brand = null, int yearProduction = yearProductionMinValue,
            string? color = null, int costRuble = costRubleMinValue, int rideHeightMillimeters = yearProductionMinValue,
            int loadCapacityTons = loadCapacityTonsMinValue)
            : base(brand, yearProduction, color, costRuble, rideHeightMillimeters)
        {

            LoadCapacityTons = loadCapacityTons;
        }

        public Truck(Truck otherCar) : base(otherCar)
        {
            LoadCapacityTons = otherCar.LoadCapacityTons;
        }

        public Truck() : base()
        {
            LoadCapacityTons = loadCapacityTonsMinValue;
        }

        private protected new string PrivateToString()
        {
            base.ObjectName = this.ObjectName;
            string result = base.PrivateToString();
            if (LoadCapacityTons != loadCapacityTonsMinValue)
            {
                result += $"Грузоподъёмность в тоннах: {LoadCapacityTons}\n";
            }
            else
            {
                result += $"Значение грузоподъёмности в тоннах подозрительно: {LoadCapacityTons}\n";
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
            InputOutput.MessageWithoutEndLine("Грузоподъёмность в тоннах мест: ");
            LoadCapacityTons = InputOutput.GetIntNumber(loadCapacityTonsMinValue, loadCapacityTonsMaxValue);
        }

        public override void RandomInit()
        {
            base.ObjectName = this.ObjectName;
            base.RandomInit();
            LoadCapacityTons = random.Next(loadCapacityTonsMinValue + 1, loadCapacityTonsMaxValue + 1);
        }

        public override bool Equals(object? obj)
        {
            if (obj == null || !(obj is Truck))
                return false;
            Truck other = (Truck)obj;
            return base.Equals((Car)obj) && this.LoadCapacityTons == other.LoadCapacityTons;
        }

        public override int GetHashCode() => this.ToString().GetHashCode();

        public override object Clone()
        {
            Truck returnCar = new Truck(this);
            returnCar.IdNumber = this.IdNumber;
            return returnCar;
        }
    }
}
