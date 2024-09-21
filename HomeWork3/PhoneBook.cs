using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork3
{
    internal class PhoneBook : Repository<Abonent>
    {
        #region Поля и свойства

        /// <summary>
        /// Путь к файлу, в котором хранится информация об абонентах.
        /// </summary>
        private readonly string _filePath;

        /// <summary>
        /// Список абонентов, хранящихся в телефонной книжке.
        /// </summary>
        private readonly List<Abonent> _abonents = new List<Abonent>();

        #endregion

        #region Конструкторы

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="PhoneBook"/> с использованием текущей директории для хранения данных.
        /// </summary>
        public PhoneBook() : this(Directory.GetCurrentDirectory())
        {
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="PhoneBook"/> с заданным путем для хранения данных.
        /// </summary>
        /// <param name="filePath">Путь к файлу данных.</param>
        public PhoneBook(string filePath) : base(filePath)
        {
            this._filePath = filePath;
            DeserealizeData();

            // Подписка на событие завершения работы приложения
            AppDomain.CurrentDomain.ProcessExit += (s, e) => SerealizeData();
        }

        #endregion

        #region Методы

        /// <summary>
        /// Добавляет абонента в телефонную книжку, если абонент с таким же именем и номером телефона еще не существует.
        /// </summary>
        /// <param name="abonent">Абонент, которого нужно добавить.</param>
        public override void AddPerson(Abonent abonent)
        {
            if (!this._abonents.Any(x => x == abonent))
            {
                this._abonents.Add(abonent);
            }
        }

        /// <summary>
        /// Удаляет абонента из телефонной книжки.
        /// </summary>
        /// <param name="abonent">Абонент, которого нужно удалить.</param>
        public override void RemovePerson(Abonent abonent)
        {
            this._abonents.Remove(abonent);
        }

        /// <summary>
        /// Находит и возвращает абонента по имени или номеру телефона.
        /// </summary>
        /// <param name="entry">Имя или номер телефона абонента.</param>
        /// <returns>Найденный абонент.</returns>
        /// <exception cref="InvalidDataException">Выбрасывается, если абонент не найден или данные введены неверно.</exception>
        public override Abonent GetPerson2(string entry)
        {
            var abonent = this._abonents.Find(x => x.Name == entry || x.PhoneNumber == entry);
            if (abonent == null)
            {
                throw new InvalidDataException("Данные введены в неправильном формате");
            }

            return abonent;
        }

        /// <summary>
        /// Находит и выводит в консоль имя абонента по его номеру телефона.
        /// </summary>
        /// <param name="phoneNumber">Номер телефона абонента.</param>
        public void GetAbonentFromNumber(string phoneNumber)
        {
            var currentAbonents = GetPerson2(phoneNumber);
            Console.WriteLine("Имена по телефону:");
            Console.WriteLine($"{currentAbonents.Name}");
        }

        /// <summary>
        /// Находит и выводит в консоль номер телефона абонента по его имени.
        /// </summary>
        /// <param name="name">Имя абонента.</param>
        public void GetAbonentFromName(string name)
        {
            var currentAbonents = GetPerson2(name);
            Console.WriteLine("Телефоны по имени:");
            Console.WriteLine($"{currentAbonents.PhoneNumber}");
        }

        /// <summary>
        /// Выводит всех абонентов в консоль. Если список пуст, выводит сообщение об отсутствии записей.
        /// </summary>
        public override void PrintPersons()
        {
            if (this._abonents.Count > 0)
            {
                foreach (var abonent in this._abonents)
                {
                    Console.WriteLine($"{abonent.Name}:{abonent.PhoneNumber}");
                }
            }
            else
            {
                Console.WriteLine("Нету записей");
            }
        }

        /// <summary>
        /// Десериализует данные абонентов из файла.
        /// </summary>
        private void DeserealizeData()
        {
            var fullPath = Path.GetFullPath(Path.Combine(_filePath, "Abonents.txt"));
            if (File.Exists(fullPath))
            {
                var abonentsZips = File.ReadAllLines(fullPath);

                foreach (var line in abonentsZips)
                {
                    var parts = line.Split(':');
                    this._abonents.Add(new Abonent(parts[0], parts[1]));
                }
            }
        }

        /// <summary>
        /// Сериализует данные абонентов в файл.
        /// </summary>
        private void SerealizeData()
        {
            var fullpath = Path.GetFullPath(Path.Combine(_filePath, "Abonents.txt"));
            var strBuild = new StringBuilder();
            foreach (var abonent in _abonents)
            {
                strBuild.AppendLine($"{abonent.Name}:{abonent.PhoneNumber}");
            }

            File.WriteAllText(fullpath, strBuild.ToString());
        }

        #endregion
    }
}
