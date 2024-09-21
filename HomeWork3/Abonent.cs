using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork3
{
    /// <summary>
    /// Класс, описывающий абонента с именем и номером телефона.
    /// </summary>
    internal class Abonent : Person
    {
        #region Поля и свойства

        /// <summary>
        /// Номер телефона абонента.
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Имя абонента.
        /// </summary>
        public new string Name { get; set; }

        #endregion

        #region Конструкторы

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="Abonent"/> с указанными именем и номером телефона.
        /// </summary>
        /// <param name="name">Имя абонента.</param>
        /// <param name="phoneNumber">Номер телефона абонента.</param>
        public Abonent(string name, string phoneNumber) : base(name)
        {
            this.Name = name;
            this.PhoneNumber = phoneNumber;
        }

        #endregion

        #region Базовый класс

        /// <summary>
        /// Определяет, равен ли текущий объект другому объекту.
        /// </summary>
        /// <param name="obj">Другой объект для сравнения.</param>
        /// <returns>Значение <see langword="true"/>, если объекты равны; в противном случае <see langword="false"/>.</returns>
        public override bool Equals(object obj)
        {
            if (obj is Abonent abonent)
            {
                return base.Equals(abonent) && abonent.PhoneNumber == this.PhoneNumber;
            }

            return base.Equals(obj);
        }

        /// <summary>
        /// Возвращает хэш-код для текущего объекта.
        /// </summary>
        /// <returns>Хэш-код имени и номера телефона абонента.</returns>
        public override int GetHashCode()
        {
            return this.Name.GetHashCode() + this.PhoneNumber.GetHashCode();
        }

        #endregion
    }
}
