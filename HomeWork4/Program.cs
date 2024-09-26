using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Выберите действие:");
                Console.WriteLine("0. Вывести работников");
                Console.WriteLine("1. Добавить работника");
                Console.WriteLine("2. Удалить работника");
                Console.WriteLine("3. Найти данные работника по табельному номеру");
                Console.WriteLine("4. Редактировать данные работника");
                Console.WriteLine("5. Выйти");

                var choice = Console.ReadLine();

                int id;

                try
                {
                    switch (choice)
                    {
                        case "0":
                            EmployeeManager.Instance.GetAllEmployees();
                            break;
                        case "1":
                            try
                            {
                                EmployeeManager.Instance.CreateEmployee();
                            }
                            catch (ArgumentException e)
                            {
                                Console.WriteLine("Ошибка при добавлении работника: " + e.Message);
                            }
                            break;

                        case "2":
                            Console.WriteLine("Введите табельный номер для удаления");
                            if (!int.TryParse(Console.ReadLine(), out id))
                            {
                                Console.WriteLine("Ошибка: Введено некорректное значение табельного номера.");
                                break;
                            }
                            try
                            {
                                var emp = EmployeeManager.Instance.GetEmployee(id);
                                EmployeeManager.Instance.RemoveEmployee(emp);
                                Console.WriteLine("Работник успешно удален.");
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine("Ошибка при удалении работника: " + e.Message);
                            }
                            break;

                        case "3":
                            Console.WriteLine("Введите табельный номер работника");
                            if (!int.TryParse(Console.ReadLine(), out id))
                            {
                                Console.WriteLine("Ошибка: Введено некорректное значение табельного номера.");
                                break;
                            }
                            try
                            {
                                Console.WriteLine(EmployeeManager.Instance.GetEmployee(id));
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine("Ошибка при поиске работника: " + e.Message);
                            }
                            break;

                        case "4":
                            Console.WriteLine("Введите табельный номер сотрудника, чьи данные вы хотите обновить");
                            if (!int.TryParse(Console.ReadLine(), out id))
                            {
                                Console.WriteLine("Ошибка: Введено некорректное значение табельного номера.");
                                break;
                            }
                            try
                            {
                                var em = EmployeeManager.Instance.GetEmployee(id);
                                EmployeeManager.Instance.UpdateData(em);
                                Console.WriteLine("Данные работника успешно обновлены.");
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine("Ошибка при обновлении данных работника: " + e.Message);
                            }
                            break;

                        case "5":
                            return;

                        default:
                            Console.WriteLine("Неверный выбор. Пожалуйста, выберите действие из списка.");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Произошла непредвиденная ошибка: " + ex.Message);
                }

                Console.WriteLine();
            }
        }
    }
}
