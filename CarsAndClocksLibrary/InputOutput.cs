using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarsAndClocksLibrary
{
    public class InputOutput
    {
        private static CultureInfo _culture = CultureInfo.CreateSpecificCulture("ru-Ru");
        private static string[] interpretedAsTrue = { "1", "Да", "да", "Правда", "правда", "Истина", "истина",
            "Верно", "верно", "Есть", "есть", "True", "true", "Right", "right", "Truth", "truth", "Correct", "correct" };
        private static string[] interpretedAsFalse = { "0", "Нет", "нет", "Неправда", "неправда", "Ложь", "ложь",
            "Неверно", "неверно", "Нету", "нету", "False", "false", "Wrong", "wrong", "Lie", "lie", "Incorrect", "incorrect" };

        private static CultureInfo Culture
        {
            get => _culture;
            set { }
        }

        public static string GetString()
        {
            string? result = "";
            bool isConvert = false;
            while (!isConvert)
            {
                try
                {
                    result = Console.ReadLine();
                }
                catch (IOException)
                {
                    Console.WriteLine("Возникла ошибка ввода-вывода.");
                    continue;
                }
                catch (OutOfMemoryException)
                {
                    Console.WriteLine("Недостаточно памяти для считывания строки.");
                    continue;
                }
                catch (ArgumentOutOfRangeException)
                {
                    Console.WriteLine("В строке слишком много символов.");
                    continue;
                }
                catch
                {
                    Console.WriteLine("Возникла непредвиденная ошибка.");
                    continue;
                }
                if (result == null)
                {
                    Console.WriteLine("Строка не может быть пустой.");
                    continue;
                }
                isConvert = true;
            }
            return result;
        }

        public static bool GetBool()
        {
            bool result = false;
            string? input;
            bool isConvert = false;
            while (!isConvert)
            {
                input = GetString();
                if (interpretedAsTrue.Contains(input))
                {
                    result = true;
                    isConvert = true;
                }
                else if (interpretedAsFalse.Contains(input))
                {
                    result = false;
                    isConvert = true;
                }
                else
                {
                    Console.WriteLine("Не получилось распознать ввод; используйте слова \"Да\" или \"Нет\" без кавычек.");
                }
            }
            return result;
        }

        public static long GetLongNumber(long minValue = Int64.MinValue, long maxValue = Int64.MaxValue)
        {
            long result = 0;
            bool isConvert = false;
            while (!isConvert)
            {
                try
                {
                    result = long.Parse(GetString(), Culture);
                }
                catch (ArgumentNullException)
                {
                    Console.WriteLine("Не получилось получит ввод.");
                    continue;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Ввод не является числом или число нецелое.");
                    continue;
                }
                catch (OverflowException)
                {
                    Console.WriteLine("В числе слишком много цифр.");
                    continue;
                }
                catch
                {
                    Console.WriteLine("Возникла непредвиденная ошибка.");
                    continue;
                }
                if (result < minValue)
                {
                    Console.WriteLine($"Число не входит в ОДЗ, оно меньше чем {minValue}.");
                    continue;
                }
                else if (result > maxValue)
                {
                    Console.WriteLine($"Число не входит в ОДЗ, оно больше чем {maxValue}.");
                    continue;
                }
                else
                {
                    isConvert = true;
                }
            }
            return result;
        }

        public static int GetIntNumber(int minValue = Int32.MinValue, int maxValue = Int32.MaxValue)
        {
            int result = 0;
            bool isConvert = false;
            while (!isConvert)
            {
                try
                {
                    result = int.Parse(GetString(), Culture);
                }
                catch (ArgumentNullException)
                {
                    Console.WriteLine("Не получилось получит ввод.");
                    continue;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Ввод не является числом или число нецелое.");
                    continue;
                }
                catch (OverflowException)
                {
                    Console.WriteLine("В числе слишком много цифр.");
                    continue;
                }
                catch
                {
                    Console.WriteLine("Возникла непредвиденная ошибка.");
                    continue;
                }
                if (result < minValue)
                {
                    Console.WriteLine($"Число не входит в ОДЗ, оно меньше чем {minValue}.");
                    continue;
                }
                else if (result > maxValue)
                {
                    Console.WriteLine($"Число не входит в ОДЗ, оно больше чем {maxValue}.");
                    continue;
                }
                else
                {
                    isConvert = true;
                }
            }
            return result;
        }

        public static void Message(params object[] args)
        {
            foreach (object obj in args)
            {
                Console.Write(obj.ToString());
            }
            Console.WriteLine();
        }

        public static void MessageWithoutEndLine(params object[] args)
        {
            foreach (object obj in args)
            {
                Console.Write(obj.ToString());
            }
        }
    }
}
