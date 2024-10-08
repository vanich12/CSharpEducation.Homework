﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HomeWork4
{
    
    /// <summary>
    /// Сотрудник компании с информацией о его должности, зарплате и контактах.
    /// </summary>
    public class Employee : Person, IEmployee
    {
        private static readonly Dictionary<Post, double> SalaryCoefficients = new Dictionary<Post, double>
        {
            { Post.Manager, 1.5 },
            { Post.Developer, 1.2 },
            { Post.Designer, 1.1 },
            { Post.Tester, 1.0 },
            { Post.Analyst, 1.3 },
            { Post.Architect, 1.8 },
            { Post.DevOpsEngineer, 1.4 },
            { Post.ProductOwner, 1.7 },
            { Post.ScrumMaster, 1.6 },
            { Post.HR, 1.0 },
            { Post.SalesManager, 1.2 },
            { Post.MarketingSpecialist, 1.1 },
            { Post.SupportEngineer, 1.0 }
        };

        #region Свойства

        /// <summary>
        /// Номер телефона сотрудника.
        /// </summary>
        public string PhoneNumber { get; set; }

        private const double BaseSalary = 30000.0;

        /// <summary>
        /// Должность сотрудника.
        /// </summary>
        public Post Post { get; set; }

        #endregion

        #region Методы

        /// <summary>
        /// Возвращает рассчитанную зарплату сотрудника на основе базовой ставки и коэффициента должности.
        /// </summary>
        /// <returns>Рассчитанная зарплата сотрудника.</returns>
        public double GetSalary()
        {
            return BaseSalary * SalaryCoefficients[Post];
        }

        #endregion

        #region Базовый класс

        /// <summary>
        /// Представляет информацию о сотруднике в виде строки.
        /// </summary>
        /// <returns>Строка с информацией о сотруднике.</returns>
        public override string ToString()
        {
            return $"Имя: {Name}\n" +
                   $"Номер телефона: {PhoneNumber}\n" +
                   $"Должность: {Post}\n" +
                   $"Зарплата: {GetSalary()}\n" +
                   $"Табельный номер: {Id}";
        }

        #endregion

        #region Конструкторы

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="post">Должность сотрудника.</param>
        /// <param name="phoneNumber">Номер телефона сотрудника.</param>
        /// <param name="name">Имя сотрудника.</param>
        /// <param name="id">Табельный номер сотрудника.</param>
        public Employee(Post post, string phoneNumber, string name, int id) : base(name, id)
        {
            this.PhoneNumber = phoneNumber;
            this.Post = post;
        }

        /// <summary>
        /// Создает экземпляр сотрудника с указанными должностью, номером телефона и именем.
        /// </summary>
        /// <param name="post">Должность сотрудника.</param>
        /// <param name="phoneNumber">Номер телефона сотрудника.</param>
        /// <param name="name">Имя сотрудника.</param>
        public Employee(Post post, string phoneNumber, string name) : base(name)
        {
            this.Post = post;
            this.PhoneNumber = phoneNumber;
        }

        #endregion
    }
}