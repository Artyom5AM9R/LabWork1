using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonLibrary
{
    /// <summary>
    /// Класс, описывающий абстракцию списка, содержащего объекты класса Person
    /// </summary>
    public class PersonList
    {
        /// <summary>
        /// Массив для хранения списка записей о людях
        /// </summary>
        private Person[] _list = new Person[0];

        /// <summary>
        /// Метод для вывода списка людей на экран
        /// </summary>
        /// <param name="heading">Заголовок перед списком</param>
        public void ShowList(string heading)
        {
            Console.WriteLine(heading);
            foreach (Person man in _list)
            {
                Console.WriteLine(man.Info);
            }
            Console.WriteLine();
        }

        /// <summary>
        /// Метод для добавления записи о человеке в список людей
        /// </summary>
        /// <param name="person">Объект класса Person</param>
        public void Add(Person person)
        {
            Array.Resize(ref _list, _list.Length + 1);
            _list[_list.Length - 1] = person;
        }

        /// <summary>
        /// Метод для удаления последней записи из списка людей
        /// </summary>
        public void RemoveLastPerson()
        {
            try
            {
                if (_list.Length > 0)
                {
                    Array.Resize(ref _list, _list.Length - 1);
                }
            }
            catch
            {
                throw new Exception("Спиcок пуст, нет записей для удаления.");
            }
        }

        /// <summary>
        /// Метод для удаления записи в списке людей по её индексу
        /// </summary>
        public void RemoveByIndex(int index)
        {
            try
            {
                Array.Clear(_list, index - 1, 1);
                _list = _list.Where(x => x != null).ToArray();
            }
            catch
            {
                switch (_list.Length)
                {
                    case 0:
                        throw new Exception("Спиcок пуст, нет записей для удаления.");
                    default:
                        throw new Exception("Указан некорректный индекс для поиска записи.");
                }
            }            
        }

        /// <summary>
        /// Метод для поиска записи о человеке в списке людей по её индексу
        /// </summary>
        /// <returns>Значение формата Person</returns>
        public Person Find(int index)
        {
            try
            {
                return _list[index - 1];
            }
            catch
            {
                throw new Exception("Указан некорректный индекс для поиска записи.");
            }
        }

        /// <summary>
        /// Метод для поиска индекса записи в списке людей по её параметрам
        /// </summary>
        /// <param name="name">Имя человека</param>
        /// <param name="surname">Фамилия человека</param>
        /// <param name="age">Возраст человека</param>
        /// <returns>Индекс записи в списке людей, либо -1, если запись не найдена</returns>
        public int FindIndex(string name, string surname, int age)
        {
            foreach (Person human in _list)
            {
                if (human.Name == name && human.Surname == surname && human.Age == age)
                {
                    return Array.IndexOf(_list, human) + 1;
                }
            }

            return -1;
        }

        /// <summary>
        /// Метод для очистки записей в списке людей
        /// </summary>
        public void Clear()
        {
            Array.Resize(ref _list, 0);
        }

        /// <summary>
        /// Метод для опряделения количества записей в списке людей
        /// </summary>
        /// <returns>Число типа int</returns>
        public int Count()
        {
            return _list.Length;
        }
    }
}
