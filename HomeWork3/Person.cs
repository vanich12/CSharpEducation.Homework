using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork3
{
    /// <summary>
    /// Представляет сущность человека с именем.
    /// </summary>
    public class Person
    {
        #region Поля и свойства

        public string Name { get; }

        #endregion

        #region Конструкторы

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="Person"/> с указанным именем.
        /// </summary>
        /// <param name="name">Имя человека.</param>
        public Person(string name)
        {
            this.Name = name;
        }

        #endregion

        #region Методы

        /// <summary>
        /// Определяет, равен ли текущий объект другому объекту.
        /// </summary>
        /// <param name="obj">Другой объект для сравнения.</param>
        /// <returns>Значение <see langword="true"/>, если объекты равны; в противном случае <see langword="false"/>.</returns>
        public override bool Equals(object obj)
        {
            if (obj is Person person)
            {
                return person.Name == this.Name;
            }

            return base.Equals(obj);
        }

        /// <summary>
        /// Возвращает хэш-код для текущего объекта.
        /// </summary>
        /// <returns>Хэш-код имени человека.</returns>
        public override int GetHashCode()
        {
            return this.Name.GetHashCode();
        }

        #endregion
    }
}
