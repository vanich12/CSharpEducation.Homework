using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork3
{
    /// <summary>
    /// Абстрактный репозиторий
    /// </summary>
    public abstract class Repository<T> where T : Person
    {
        #region Поля и свойства

        /// <summary>
        /// Путь до файла
        /// </summary>
        private readonly string _filePath;

        /// <summary>
        /// Абоненты
        /// </summary>
        private List<T> _abonents = new List<T>();

        #endregion


        #region Методы

        /// <summary>
        /// Добавление человека в хранилище
        /// </summary>
        /// <param name="entry"></param>
        public abstract void AddPerson(T entry);

        /// <summary>
        /// Удаление человека из хранилище
        /// </summary>
        /// <param name="entry"></param>
        public abstract void RemovePerson(T entry);

        /// <summary>
        /// Получение человека из хранилища по параметру
        /// </summary>
        /// <param name="entry"></param>
        /// <returns></returns>
        public abstract T GetPerson2(string entry);

        /// <summary>
        /// Вывод на консоль все людей из хранилища
        /// </summary>
        public abstract void PrintPersons();

        /// <summary>
        /// Сериализация данных
        /// </summary>
        protected virtual void SerealizeData()
        {
            var fullpath = Path.GetFullPath(Path.Combine(_filePath, "Abonents.txt"));
            var strBuild = new StringBuilder();
            foreach (var abonent in _abonents)
            {
                if (abonent is Person person)
                {
                    strBuild.AppendLine($"{person.Name}");
                }
                else if (abonent is Abonent abonen)
                    strBuild.AppendLine($"{abonent.Name}:{abonen.PhoneNumber}");
            }

            File.WriteAllText(fullpath, strBuild.ToString());
        }

        /// <summary>
        /// Загрузка данных из хранилища в оперативную память
        /// </summary>
        /// <param name="abonents"></param>
        protected void LoadData(IEnumerable<T> abonents)
        {
            _abonents.AddRange(abonents);
        }

        #endregion

        #region Конструкторы

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="filePath"></param>
        public Repository(string filePath)
        {
            this._filePath = filePath;
        }

        #endregion
    }
}