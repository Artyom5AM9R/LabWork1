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
        /// Метод для вывода в консоль текста в синем цвете
        /// </summary>
        /// <param name="text">Текст для вывода в консоль</param>
        public static void BlueTextOutput(string text)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
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
                PersonList ListOne = new PersonList();
                PersonList ListTwo = new PersonList();

                //3.a
                BlueTextOutput("Создание 2-х списков с записями о людях\n");
                Console.ReadKey();
                for (int i = 0; i < 3; i++)
                {
                    ListOne.Add(Person.GetRandomPerson());
                    ListTwo.Add(Person.GetRandomPerson());
                }

                //3.b
                ListOne.ShowList("1-й список:");
                ListTwo.ShowList("2-й список:");

                //3.c
                Console.ReadKey();
                BlueTextOutput("\nДобавление записи в 1-й список\n");
                Person Human = new Person();
                ListOne.Add(Human.InputPerson());
                ListOne.ShowList("\n1-й список:");
                ListTwo.ShowList("2-й список:");

                //3.d
                Console.ReadKey();
                BlueTextOutput("\nКопирование записи о втором человеке из 1-го списка в " +
                    "конец 2-го списка\n");
                ListTwo.Add(ListOne.Find(2));
                ListOne.ShowList("1-й список:");
                ListTwo.ShowList("2-й список:");

                //3.e
                Console.ReadKey();
                BlueTextOutput("\nУдаление записи о втором человеке из 1-го списка\n");
                ListOne.RemoveByIndex(2);
                ListOne.ShowList("1-й список:");
                ListTwo.ShowList("2-й список:");

                //3.f
                Console.ReadKey();
                BlueTextOutput("\nОчистка 2-го списка\n");
                ListTwo.Clear();
                Console.WriteLine("Количество записей в 1-м списке - " + ListOne.Count());
                Console.WriteLine("Количество записей в 2-м списке - " + ListTwo.Count());
                
                BlueTextOutput("\nДля выхода из программы нажмите клавишу Esc\n");
                if (Console.ReadKey().Key == ConsoleKey.Escape)
                {
                    break;
                }
                else 
                {
                    Console.WriteLine();
                }
            }
        }
    }
}
