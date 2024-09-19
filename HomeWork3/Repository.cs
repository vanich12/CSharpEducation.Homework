using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork3
{
    /// <summary>
    /// Представляет репозиторий для управления коллекцией объектов типа <typeparamref name="T"/>.
    /// Класс предназначен для реализации операций добавления, удаления, получения и отображения объектов в хранилище.
    /// </summary>
    /// <typeparam name="T">Тип объектов, которые будут храниться в репозитории. Должен быть наследником класса <see cref="Person"/>.</typeparam>
    public abstract class Repository<T> where T : Person
    {
        #region Поля и свойства

        /// <summary>
        /// Путь к файлу, используемому для хранения данных.
        /// </summary>
        private readonly string _filePath;

        /// <summary>
        /// Список объектов, хранящихся в репозитории.
        /// </summary>
        private List<T> _abonents = new List<T>();

        #endregion

        #region Конструкторы

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="Repository{T}"/> с заданным путем для хранения данных.
        /// </summary>
        /// <param name="filePath">Путь к файлу, в котором будут храниться данные.</param>
        public Repository(string filePath)
        {
            this._filePath = filePath;
        }

        #endregion

        #region Методы

        /// <summary>
        /// Добавляет объект в хранилище.
        /// </summary>
        /// <param name="entry">Объект, который нужно добавить в хранилище.</param>
        public abstract void AddPerson(T entry);

        /// <summary>
        /// Удаляет объект из хранилища.
        /// </summary>
        /// <param name="entry">Объект, который нужно удалить из хранилища.</param>
        public abstract void RemovePerson(T entry);

        /// <summary>
        /// Получает объект из хранилища по параметру.
        /// </summary>
        /// <param name="entry">Параметр для поиска объекта.</param>
        /// <returns>Найденный объект типа <typeparamref name="T"/>.</returns>
        public abstract T GetPerson2(string entry);

        /// <summary>
        /// Выводит все объекты из хранилища на консоль.
        /// </summary>
        public abstract void PrintPersons();

        /// <summary>
        /// Сериализует данные объектов в файл.
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
                {
                    strBuild.AppendLine($"{abonent.Name}:{abonen.PhoneNumber}");
                }
            }
            File.WriteAllText(fullpath, strBuild.ToString());
        }

        /// <summary>
        /// Загружает данные в хранилище из предоставленного перечисления объектов.
        /// </summary>
        /// <param name="abonents">Перечисление объектов для загрузки в хранилище.</param>
        protected void LoadData(IEnumerable<T> abonents)
        {
            _abonents.AddRange(abonents);
        }

        #endregion
    }
}
