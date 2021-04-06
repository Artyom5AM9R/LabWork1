using System;

using PersonLibrary;

namespace LabWork1
{
    /// <summary>
    /// Класс, реализующий функционал библиотеки PersonLibrary
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Метод для ввода имени или фамилии человека
        /// </summary>
        /// <param name="value">Значение для ввода</param>
        private static string InputNameOrSurname(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new Exception("Пустой ввод не допускается!");
            }

            return value;
        }

        /// <summary>
        /// Метод для ввода возраста человека из консоли и проверки введённого значения
        /// </summary>
        /// <param name="value">Значение для ввода</param>
        private static int InputAge(string value)
        {
            int age;

            try
            {
                age = int.Parse(value);
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }

            return age;
        }

        /// <summary>
        /// Метод для ввода пола человека из консоли и проверки введённого значения
        /// </summary>
        /// <param name="genderString">Значение для ввода</param>
        private static GenderType InputGender(string value)
        {
            switch (value.ToLower())
            {
                case "м":
                    return GenderType.Male;
                case "ж":
                    return GenderType.Female;
                default:
                    throw new Exception("Пол был указан некорректно.");
            }
        }

        /// <summary>
        /// Метод для ввода данных о человеке
        /// </summary>
        /// <returns>Значение типа Person</returns>
        public static Person InputPerson()
        {
            var man = new Person();

            while (true)
            {
                SafeReadFromConsole("Введите имя - ", input => man.Name = InputNameOrSurname(input));
                SafeReadFromConsole("Введите фамилию - ", input => man.Surname = InputNameOrSurname(input));

                try
                {
                    man.CheckOneLanguageInPerson();
                    break;
                }
                catch (Exception exception)
                {
                    ColorTextInConsole($"\n{exception.Message} Повторите ввод.\n",
                        ConsoleColor.Red);
                    man = new Person();
                }
            }

            SafeReadFromConsole("Введите возраст - ", input => man.Age = InputAge(input));
            SafeReadFromConsole("Введите пол (м/ж) - ", input => man.Gender = InputGender(input));

            return man;
        }

        /// <summary>
        /// Метод для повтора действий по считыванию значения из консоли до момента получения
        /// корректного значения и последующего совершения действия с ним
        /// </summary>
        /// <param name="outputLine">Строка для вывода в консоль</param>
        /// <param name="onRead">Действие, которое необходимо сделать</param>
        public static void SafeReadFromConsole(string outputLine, Action<string> onRead)
        {
            while (true)
            {
                try
                {
                    Console.Write(outputLine);
                    onRead(Console.ReadLine());
                    return;
                }
                catch (Exception exception)
                {
                    ColorTextInConsole($"\n{exception.Message} Повторите ввод.\n",
                        ConsoleColor.Red);
                }
            }
        }

        /// <summary>
        /// Метод для вывода в консоль текста в заданном цвете
        /// </summary>
        /// <param name="text">Текст для вывода</param>
        /// <param name="color">Цвет текста</param>
        public static void ColorTextInConsole(string text, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(text);
            Console.ResetColor();
        }

        /// <summary>
        /// Точка входа в программу
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            while (true)
            {
                try
                {
                    PersonList listOne = new PersonList();
                    PersonList listTwo = new PersonList();

                    //3.a
                    ColorTextInConsole("Создание 2-х списков с записями о людях\n",
                        ConsoleColor.Blue);
                    Console.ReadKey();
                    for (int i = 0; i < 3; i++)
                    {
                        listOne.Add(RandomPerson.GetRandomPerson());
                        listTwo.Add(RandomPerson.GetRandomPerson());
                    }

                    //3.b
                    listOne.ShowList("1-й список:");
                    listTwo.ShowList("2-й список:");

                    //3.c
                    Console.ReadKey();
                    ColorTextInConsole("\nДобавление записи в 1-й список\n",
                        ConsoleColor.Blue);
                    var man = InputPerson();
                    listOne.Add(man);
                    listOne.ShowList("\n1-й список:");
                    listTwo.ShowList("2-й список:");

                    //3.d
                    Console.ReadKey();
                    ColorTextInConsole("\nКопирование записи о втором человеке из 1-го списка" +
                        "в конец 2-го списка\n", ConsoleColor.Blue);
                    listTwo.Add(listOne.Find(2));
                    listOne.ShowList("1-й список:");
                    listTwo.ShowList("2-й список:");

                    //ListOne.Clear();

                    //3.e
                    Console.ReadKey();
                    ColorTextInConsole("\nУдаление записи о втором человеке из 1-го списка\n",
                        ConsoleColor.Blue);
                    listOne.RemoveByIndex(2);
                    listOne.ShowList("1-й список:");
                    listTwo.ShowList("2-й список:");

                    //3.f
                    Console.ReadKey();
                    ColorTextInConsole("\nОчистка 2-го списка\n", ConsoleColor.Blue);
                    listTwo.Clear();
                    Console.WriteLine("Количество записей в 1-м списке - " + listOne.Count());
                    Console.WriteLine("Количество записей в 2-м списке - " + listTwo.Count());

                    ColorTextInConsole("\nДля выхода из программы нажмите клавишу Esc\n",
                        ConsoleColor.Blue);
                    if (Console.ReadKey().Key == ConsoleKey.Escape)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine();
                    }
                }
                catch (Exception exception)
                {
                    ColorTextInConsole($"{exception.Message}\n", ConsoleColor.Red);
                    ColorTextInConsole("Работа программы будет остановлена после нажатия любой клавиши",
                        ConsoleColor.Red);
                    Console.ReadKey();
                    break;
                }
            }
        }
    }
}
