using CarsAndClocksLibrary;

namespace DemonstrationProgram
{
    public class Program
    {
        static int FindMostExpensiveSUV(ref Car[] cars)
        {
            int index = -1;
            long cost = -1;
            for (int i = 0; i < cars.Length; i++)
            {
                if (cars[i] is SUV)
                {
                    if (cars[i].CostRuble > cost)
                    {
                        index = i;
                        cost = cars[i].CostRuble;
                    }
                }
            }
            return index;
        }

        static double CountAverageSpeedPassengerCars(ref Car[] cars)
        {
            long summ = 0;
            long count = 0;
            double ret;
            foreach (Car car in cars)
            {
                if (car.GetType() == typeof(PassengerCar))
                {
                    summ += (car as PassengerCar).MaximumSpeedKilometersPerHour;
                    count++;
                }
            }
            if (count == 0)
                return -1;
            ret = (double)summ / (double)count;
            return ret;
        }

        static void ShowTrucksWithLoadCapacityExceedingSpecified(ref Car[] cars, int specifiedLoadCapacity)
        {
            foreach (Car car in cars)
            {
                if (car.GetType() == typeof(Truck))
                {
                    if ((car as Truck).LoadCapacityTons > specifiedLoadCapacity)
                        car.Show();
                }
            }
            return;
        }

        static void Main(string[] args)
        {
            Car[] cars = new Car[20];
            int index, tons;
            double retValue;
            for (int i = 0; i < 5; i++)
            {
                cars[i] = new Car();
                cars[i].RandomInit();
            }
            for (int i = 5; i < 10; i++)
            {
                cars[i] = new PassengerCar();
                cars[i].RandomInit();
            }
            for (int i = 10; i < 15; i++)
            {
                cars[i] = new SUV();
                cars[i].RandomInit();
            }
            for (int i = 15; i < 20; i++)
            {
                cars[i] = new Truck();
                cars[i].RandomInit();
            }
            for (int i = 0; i < 20; i++)
                cars[i].NoVirtualShow();
            for (int i = 0; i < 20; i++)
                cars[i].Show();
            index = FindMostExpensiveSUV(ref cars);
            if (index == -1)
            {
                InputOutput.Message("Не найдено");
            }
            else
            {
                cars[index].Show();
            }
            retValue = CountAverageSpeedPassengerCars(ref cars);
            if (retValue < 0)
            {
                InputOutput.Message("Не легковых автомобилей");
            }
            else
            {
                InputOutput.Message($"Средняя скорость легковых автомобилей: {retValue}");
            }
            InputOutput.MessageWithoutEndLine("Грузоподъёмность в тоннах, которую должны привышать грузовые автомобили: ");
            tons = InputOutput.GetIntNumber(0, 10_000);
            ShowTrucksWithLoadCapacityExceedingSpecified(ref cars, tons);
            object[] objects = new object[25];
            for (int i = 0; i < 5; i++)
            {
                objects[i] = new Car();
                (objects[i] as Car).RandomInit();
            }
            for (int i = 5; i < 10; i++)
            {
                objects[i] = new PassengerCar();
                (objects[i] as PassengerCar).RandomInit();
            }
            for (int i = 10; i < 15; i++)
            {
                objects[i] = new SUV();
                (objects[i] as SUV).RandomInit();
            }
            for (int i = 15; i < 20; i++)
            {
                objects[i] = new Truck();
                (objects[i] as Truck).RandomInit();
            }
            for (int i = 20; i < 25; i++)
            {
                objects[i] = new DialClock();
                (objects[i] as DialClock).RandomInit();
            }
            int countCar = 0, countPassengerCar = 0, countSUV = 0, countTruck = 0, countDialClock = 0;
            foreach (object obj in objects)
            {
                if (obj.GetType() == typeof(Car))
                {
                    countCar++;
                }
                else if (obj.GetType() == typeof(PassengerCar))
                {
                    countPassengerCar++;
                }
                else if (obj.GetType() == typeof(SUV))
                {
                    countSUV++;
                }
                else if (obj.GetType() == typeof(Truck))
                {
                    countTruck++;
                }
                else if (obj.GetType() == typeof(DialClock))
                {
                    countDialClock++;
                }
            }
            InputOutput.Message($"{countCar} {countPassengerCar} {countSUV} {countTruck} {countDialClock}");
            int inputValue;
            Array.Sort(cars);
            for (int i = 0; i < 20; i++)
                cars[i].Show();
            InputOutput.MessageWithoutEndLine("\nВведите индекс: ");
            inputValue = InputOutput.GetIntNumber(0, 19);
            index = Array.BinarySearch(cars, cars[inputValue]);
            if (index < 0)
            {
                InputOutput.Message("Не найдено");
            }
            else
            {
                cars[index].Show();
            }
            Array.Sort(cars, new ComparatorYearProduction());
            for (int i = 0; i < 20; i++)
                cars[i].Show();
            InputOutput.MessageWithoutEndLine("\nВведите индекс: ");
            inputValue = InputOutput.GetIntNumber(0, 19);
            index = Array.BinarySearch(cars, cars[inputValue], new ComparatorYearProduction());
            if (index < 0)
            {
                InputOutput.Message("Не найдено");
            }
            else
            {
                cars[index].Show();
            }
            Car originCar = new Car();
            originCar.Init();
            object shallowCopyCar = originCar.ShallowCopy();
            object DeepCopyCar = originCar.Clone();
            originCar.IdNumber = 123456789;
            (shallowCopyCar as Car).Show();
            (DeepCopyCar as Car).Show();
            return;
        }
    }
}
