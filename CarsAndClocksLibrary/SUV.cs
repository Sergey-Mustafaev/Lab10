using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarsAndClocksLibrary
{
    public class SUV : Car, IInit, ICloneable
    {
        public new const string defaultObjectName = "Внедорожник";
        public const bool isAllWheelDriveDefault = false;

        private protected static string[] trialOffRoadTypes = { "Песок", "Камни", "Грязь" };

        private protected new string? _objectName = defaultObjectName;
        private protected bool _isAllWheelDrive;
        private protected string? _offRoadType;

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

        public bool IsAllWheelDrive { get => _isAllWheelDrive; private protected set => _isAllWheelDrive = value; }

        public string? OffRoadType { get => _offRoadType; private protected set => _offRoadType = value; }

        public SUV(string? brand = null, int yearProduction = yearProductionMinValue,
            string? color = null, int costRuble = costRubleMinValue, int rideHeightMillimeters = yearProductionMinValue,
            bool isAllWheelDrive = isAllWheelDriveDefault, string? offRoadType = null)
            : base(brand, yearProduction, color, costRuble, rideHeightMillimeters)
        {
            IsAllWheelDrive = isAllWheelDrive;
            OffRoadType = offRoadType;
        }

        public SUV(SUV otherCar) : base(otherCar)
        {
            IsAllWheelDrive = otherCar.IsAllWheelDrive;
            OffRoadType = otherCar.OffRoadType;
        }

        private protected new string PrivateToString()
        {
            base.ObjectName = this.ObjectName;
            string result = base.PrivateToString();
            if (IsAllWheelDrive)
            {
                result += $"Полноприводный\n";
            }
            else
            {
                result += $"Неполноприводный\n";
            }
            if (OffRoadType != null)
            {
                result += $"Тип бездорожья: {OffRoadType}\n";
            }
            else
            {
                result += $"Тип бездорожья неопределён: {OffRoadType}\n";
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
            InputOutput.MessageWithoutEndLine("Есть полный привод: ");
            IsAllWheelDrive = InputOutput.GetBool();
            InputOutput.MessageWithoutEndLine("Тип бездорожья: ");
            OffRoadType = InputOutput.GetString();
        }

        public override void RandomInit()
        {
            base.ObjectName = this.ObjectName;
            base.RandomInit();
            IsAllWheelDrive = random.Next(2) == 0;
            OffRoadType = trialOffRoadTypes[random.Next(0, trialOffRoadTypes.Length)];
        }

        public override bool Equals(object? obj)
        {
            if (obj == null || !(obj is SUV))
                return false;
            SUV other = (SUV)obj;
            return base.Equals((Car)obj) && this.IsAllWheelDrive == other.IsAllWheelDrive
                && this.OffRoadType == other.OffRoadType;
        }

        public override int GetHashCode() => this.ToString().GetHashCode();

        public virtual object Clone()
        {
            SUV returnCar = new SUV(this);
            returnCar.IdNumber = this.IdNumber;
            return returnCar;
        }
    }
}
