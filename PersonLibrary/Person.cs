using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace PersonLibrary
{
    /// <summary>
    /// Класс для описания человека
    /// </summary>
    public class Person
    {
        /// <summary>
        /// Имя человека
        /// </summary>
        private string _name;

        /// <summary>
        /// Фамилия человека
        /// </summary>
        private string _surname;

        /// <summary>
        /// Возраст человека
        /// </summary>
        private int _age;

        /// <summary>
        /// Пол человека
        /// </summary>
        private GenderType _gender;

        /// <summary>
        /// Тип данных, содержащий возможные варианты пола человека
        /// </summary>
        public enum GenderType
        {
            мужской,
            женский
        }

        /// <summary>
        /// Минимальный возраст человека
        /// </summary>
        const int MinAge = 1;

        /// <summary>
        /// Максимальный возраст человека
        /// </summary>
        const int MaxAge = 117;

        /// <summary>
        /// Свойство для обращения к переменной _name
        /// </summary>
        public string Name
        {
            get
            {
                return _name;
            }
            private set
            {
                _name = NameOrSurnameVerification(value, 0);
            }
        }

        /// <summary>
        /// Свойство для обращения к переменной _surname
        /// </summary>
        public string Surname 
        {
            get
            {
                return _surname;
            }
            private set
            {
                _surname = NameOrSurnameVerification(value, 1);
            }
        }

        /// <summary>
        /// Свойство для обращения к переменной _age
        /// </summary>
        public int Age
        {
            get
            {
                return _age;
            }
            private set 
            {
                while (true)
                {
                    if (value < MinAge)
                    {
                        RedTextOutput($"Возраст не может быть меньше {MinAge}!\n");
                        value = InputAge();
                    }
                    else if (value > MaxAge)
                    {
                        RedTextOutput($"Возраст не может быть больше {MaxAge}!\n");
                        value = InputAge();
                    }
                    else
                    {
                        _age = value;
                        break;
                    }
                }
            }   
        }

        /// <summary>
        /// Свойство для обращения к переменной _gender
        /// </summary>
        public GenderType Gender
        {
            get
            {
                return _gender;
            }
            private set
            {
                _gender = value;
            }
        }
        
        /// <summary>
        /// Пуской конструктор класса Person
        /// </summary>
        public Person()
        {
        }

        /// <summary>
        /// Конструктор с параметрами для класса Person
        /// </summary>
        /// <returns>Значение формата Person</returns>
        public Person(string name, string surname, int age, GenderType gender)
        {
            Name = name;
            Surname = surname;
            Age = age;
            Gender = gender;
        }

        /// <summary>
        /// Функция для получении информации о человеке
        /// </summary>
        /// <returns>Значение формата string</returns>
        public string Info()
        {
            return $"Имя и фамилия - {Name} {Surname}; " +
                $"возраст - {Age}; пол - {Gender}";
        }

        /// <summary>
        /// Метод для вывода в консоль текста в красном цвете
        /// </summary>
        /// <param name="text">Текст для вывода в консоль</param>
        public static void RedTextOutput(string text)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(text);
            Console.ResetColor();
        }

        /// <summary>
        /// Функция для ручного создания записи о человеке
        /// </summary>
        /// <returns>Значение формата Person</returns>
        public Person InputPerson()
        {
            Name = InputNameOrSurname(0);
            Surname = InputNameOrSurname(1);
            Age = InputAge();            
            Gender = InputGender();

            return new Person(Name, Surname, Age, Gender);
        }

        /// <summary>
        /// Функция возрата случайных значений
        /// </summary>
        public static Random Randomize = new Random();

        /// <summary>
        /// Функция для получения данных о человеке со случайными параметрами
        /// </summary>
        /// <returns>Значение формата Person</returns>
        public static Person GetRandomPerson()
        {
            string name;
            string surname;

            List<string> _maleNames = new List<string>()
            {
                "Артём", "Сергей", "Алексей", "Александр", "Павел",
                    "Роман", "Тимур", "Пётр", "Дмитрий", "Геннадий"
            };
            List<string> _femaleNames = new List<string>()
            {
                "Анна", "Виктория", "Елизавета", "Полина", "Валентина",
                    "Дарья", "Екатерина", "Лилия", "Карина", "Вероника"
            };
            List<string> _maleSurnames = new List<string>()
            {
                "Андропов", "Троцкий", "Поляков", "Иванов", "Харламов",
                    "Гаврилов", "Астахов", "Жданов", "Емельянов", "Виноградов"
            };
            List<string> _femaleSurnames = new List<string>()
            {
                "Гагарина", "Агапова", "Воронова", "Дубровина", "Борисова",
                    "Высоцкая", "Глебова", "Журавлёва", "Громова", "Казакова"
            };
            GenderType gender = (GenderType)Randomize.Next(0, Enum.GetNames
                (typeof(GenderType)).Length);
            if (gender == 0)
            {
                name = _maleNames[Randomize.Next(_maleNames.Count)];
                surname = _maleSurnames[Randomize.Next(_maleSurnames.Count)];
            }
            else
            {
                name = _femaleNames[Randomize.Next(_femaleNames.Count)];
                surname = _femaleSurnames[Randomize.Next(_femaleSurnames.Count)];
            }
            int age = Randomize.Next(MinAge, MaxAge);
            return new Person(name, surname, age, gender);
        }

        /// <summary>
        /// Функция для ввода имени или фамилии из консоли
        /// </summary>
        /// <param name="identifier"></param>
        /// <returns>Значение формата string</returns>
        public string InputNameOrSurname(int identifier)
        {
            string input = "";
            if (identifier == 0)
            {
                Console.Write("Введите имя - ");
                input = Console.ReadLine();
            }
            else if (identifier == 1)
            {
                Console.Write("Введите фамилию - ");
                input = Console.ReadLine();
            }
            return input;
        }

        /// <summary>
        /// Функция для проверки введённых имени или фамилии человека
        /// </summary>
        /// <param name="nameForCheck">Имя или фамилия, которые подлежат проверке</param>
        /// <param name="identifier">Идентификатор имени (0) или фамилии (1)</param>
        /// <returns>Значение формата string</returns>
        public string NameOrSurnameVerification(string nameForCheck, int identifier)
        {
            string name;

            while (true)
            {
                nameForCheck = nameForCheck.ToLower();
                if (nameForCheck == "")
                {
                    RedTextOutput("\nОшибка ввода! Пустой ввод не допускается!\n");
                    nameForCheck = InputNameOrSurname(identifier);

                }
                else if (!nameForCheck.Contains("-"))
                {
                    int Number = nameForCheck.Length;
                    Regex RegexWithoutDash = new Regex(@"[а-яё]{" + Number + "}|" +
                        "[a-z]{" + Number + "}");
                    if (RegexWithoutDash.IsMatch(nameForCheck))
                    {
                        name = nameForCheck;
                        break;
                    }
                    else
                    {
                        RedTextOutput("\nОшибка ввода! Нельзя использовать символы или цифры!\n" +
                            "Допускается использовать дефис при вводе двойного имени или фамилии.\n" +
                            "Все буквы слова должным быть одного языка.\n");
                        nameForCheck = InputNameOrSurname(identifier);
                    }
                }
                else if (nameForCheck.Contains("-"))
                {
                    int NumberBeforeDash = nameForCheck.Substring(0, nameForCheck.IndexOf("-")).Length + 1;
                    int NumberAfterDash = nameForCheck.Substring(nameForCheck.IndexOf("-") + 1).Length + 1;
                    Regex RegexWithDash = new Regex(@"([а-яё]{1," + NumberBeforeDash + "}-" +
                        "[а-яё]{1," + NumberAfterDash + "})|([a-z]{1," + NumberBeforeDash + "}-" +
                        "[a-z]{1," + NumberAfterDash + "})");
                    if (RegexWithDash.IsMatch(nameForCheck))
                    {
                        name = nameForCheck;
                        break;
                    }
                    else
                    {
                        RedTextOutput("\nОшибка ввода! Нельзя использовать символы или цифры!\n" +
                            "Допускается использовать дефис при вводе двойного имени или фамилии.\n" +
                            "При таком вводе слова перед дефисом и после него должны быть написаны на одном языке.\n");
                        nameForCheck = InputNameOrSurname(identifier);
                    }
                }
            }

            if (name.Contains("-"))
            {
                return name.Substring(0, 1).ToUpper() + name.Substring(1, name.IndexOf("-")) +
                       name.Substring(name.IndexOf("-") + 1, 1).ToUpper() + 
                       name.Substring(name.IndexOf("-") + 2);
            }
            else
            {
                return name.Substring(0, 1).ToUpper() + name.Substring(1, name.Length - 1);
            }
        }

        /// <summary>
        /// Функция для ввода возраста человека из консоли
        /// </summary>
        /// <returns>Значение формата int</returns>
        public int InputAge()
        {
            while (true)
            {
                try
                {
                    Console.Write("Введите возраст - ");
                    string inputLine = Console.ReadLine();
                    return int.Parse(inputLine);
                }
                catch (FormatException)
                {
                    RedTextOutput("\nВозраст должен задаваться числом!\n");
                }
            }
        }

        /// <summary>
        /// Фукнция для ввода пола человека из консоли и проверки его на корректность
        /// </summary>
        /// <returns>Значение формата typeGender</returns>
        public GenderType InputGender()
        {
            GenderType gender;
            string genderString;

            while (true)
            {
                Console.Write("Введите пол - ");
                genderString = Console.ReadLine().ToLower();
                if (genderString == "мужской" || genderString == "м" || genderString == "v" ||
                    genderString == "муж" || genderString == "men" || genderString == "m" ||
                    genderString == "ve;crjq" || genderString == "ve;")
                {
                    gender = (GenderType)0;
                    break;
                }
                else if (genderString == "женский" || genderString == "жен" || genderString == "ж" ||
                         genderString == ";" || genderString == ":" || genderString == ";tycrbq" ||
                         genderString == "woman" || genderString == "w" || genderString == ";ty")
                {
                    gender = (GenderType)1;
                    break;
                }
                else
                {
                    RedTextOutput("\nПол указан неверно!\n");
                }
            }
            return gender;
        }
    }
}
