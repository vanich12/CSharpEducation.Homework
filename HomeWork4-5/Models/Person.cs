using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork4
{
    /// <summary>
    /// Представляет базовую сущность для людей с уникальным идентификатором и именем.
    /// </summary>
    public class Person : IPerson
    {
        #region Поля

        /// <summary>
        /// Содержит все существующие идентификаторы, чтобы обеспечить их уникальность.
        /// </summary>
        protected static HashSet<int> existingIds = new HashSet<int>();

        #endregion

        #region Свойства

        /// <summary>
        /// Уникальный идентификатор.
        /// </summary>
        public int Id { get; private set; }

        /// <summary>
        /// Имя персоны.
        /// </summary>
        public string Name { get; set; }

        #endregion


        #region Приватные методы

        /// <summary>
        /// Генерирует уникальный идентификатор.
        /// </summary>
        /// <returns>Уникальный идентификатор.</returns>
        private static int GenerateId()
        {
            Random random = new Random();
            int newId = random.Next(1, Int32.MaxValue);

            if (existingIds.Contains(newId))
            {
                return GenerateId();
            }

            existingIds.Add(newId);
            return newId;
        }

        #endregion

        #region Переопределенные методы

        /// <summary>
        /// Проверяет, равна ли текущая персона другой на основе идентификатора.
        /// </summary>
        /// <param name="obj">Объект для сравнения.</param>
        /// <returns>Возвращает true, если идентификаторы равны; иначе false.</returns>
        public override bool Equals(object obj)
        {
            if (obj is Person person)
            {
                return person.Id == this.Id;
            }

            return base.Equals(obj);
        }

        #endregion

        #region Конструкторы

        /// <summary>
        /// Инициализирует новую персону с указанным именем и идентификатором.
        /// </summary>
        /// <param name="name">Имя персоны.</param>
        /// <param name="id">Уникальный идентификатор персоны.</param>
        public Person(string name, int id)
        {
            this.Name = name;
            this.Id = id;
        }

        /// <summary>
        /// Инициализирует новую персону с указанным именем и автоматически генерирует уникальный идентификатор.
        /// </summary>
        /// <param name="name">Имя персоны.</param>
        public Person(string name) : this(name, GenerateId())
        {
        }

        #endregion
    }
}
