using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace HomeWork4
{
    /// <summary>
    /// Управление сотрудниками, предоставляющее функциональность для создания, редактирования, удаления и хранения данных сотрудников.
    /// </summary>
    public class EmployeeManager
    {
        #region Поля

        /// <summary>
        /// Синглтон
        /// </summary>
        private static EmployeeManager _instance;

        /// <summary>
        /// Путь до файла с данными
        /// </summary>
        private readonly string _filePath;

        /// <summary>
        /// Сотрудники
        /// </summary>
        private List<IEmployee> _employees;

        #endregion

        #region Свойства

        /// <summary>
        /// Получает единственный экземпляр менеджера сотрудников.
        /// </summary>
        public static EmployeeManager Instance => _instance ?? new EmployeeManager();

        #endregion


        #region Публичные методы

        /// <summary>
        /// Обновляет информацию о сотруднике.
        /// </summary>
        /// <param name="employee">Сотрудник, данные которого нужно обновить.</param>
        public void UpdateData(IEmployee employee)
        {
            Console.WriteLine("Что вы хотите поменять?");
            Console.WriteLine("1 - Номер телефона");
            Console.WriteLine("2 - Должность");

            if (int.TryParse(Console.ReadLine(), out int choice))
            {
                switch (choice)
                {
                    case 1:
                        UpdatePhoneNumber(employee);
                        break;
                    case 2:
                        UpdatePost(employee);
                        break;
                    default:
                        throw new ArgumentException("Некорректный выбор. Пожалуйста, выберите 1 или 2.");
                }
            }
            else
            {
                throw new FormatException("Ошибка: введено некорректное число.");
            }
        }

        /// <summary>
        /// Удаляет сотрудника из системы.
        /// </summary>
        /// <param name="employee">Сотрудник, которого нужно удалить.</param>
        public void RemoveEmployee(IEmployee employee)
        {
            if (!_employees.Remove(employee))
            {
                throw new ArgumentException($"Сотрудник с ID {employee.Id} не найден и не может быть удален.");
            }
            Console.WriteLine("Сотрудник успешно удален.");
        }

        /// <summary>
        /// Получает сотрудника по его идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор сотрудника.</param>
        /// <returns>Найденный сотрудник.</returns>
        public IEmployee GetEmployee(int id)
        {
            var employee = _employees.FirstOrDefault(x => x.Id == id);
            if (employee == null)
                throw new ArgumentException($"Сотрудник с ID {id} не найден.");

            return employee;
        }

        /// <summary>
        /// Создает нового сотрудника и добавляет его в систему.
        /// </summary>
        public void CreateEmployee()
        {
            string name = GetInput("Введите имя работника:");
            string phoneNumber = GetValidPhoneNumber();

            if (phoneNumber == null)
            {
                throw new ArgumentException("Ошибка при вводе номера телефона.");
            }

            Post? postSelected = ChoosePost();
            if (postSelected.HasValue)
            {
                var employee = new Employee(postSelected.Value, phoneNumber, name);

                Add(employee);
                Console.WriteLine("Работник успешно создан.");
            }
            else
            {
                throw new ArgumentException("Ошибка при выборе должности.");
            }
        }

        /// <summary>
        /// Добавляет сотрудника в список.
        /// </summary>
        /// <param name="employee">Сотрудник для добавления.</param>
        public void Add(Employee employee)
        {
            if (_employees.Contains(employee))
                throw new ArgumentException($"Работник с ID {employee.Id} уже существует.");

            _employees.Add(employee);
        }

        /// <summary>
        /// Выводит список всех сотрудников.
        /// </summary>
        public void GetAllEmployees()
        {
            if (_employees.Count > 0)
            {
                foreach (var employee in _employees)
                {
                    Console.WriteLine(employee);
                }
            }
            else
            {
                Console.WriteLine("Нет записей о сотрудниках.");
            }
        }

        #endregion

        #region Приватные методы

        /// <summary>
        /// Обновляет должность сотрудника.
        /// </summary>
        /// <param name="employee">Сотрудник, должность которого нужно обновить.</param>
        private void UpdatePost(IEmployee employee)
        {
            Console.WriteLine("Выберите новую должность");
            var post = ChoosePost();
            if (post != null)
            {
                employee.Post = post.Value;
                Console.WriteLine($"Должность успешно обновлена на {employee.Post}");
            }
            else
            {
                throw new ArgumentException("Ошибка при выборе новой должности.");
            }
        }

        /// <summary>
        /// Обновляет номер телефона сотрудника.
        /// </summary>
        /// <param name="employee">Сотрудник, чей номер нужно обновить.</param>
        private void UpdatePhoneNumber(IEmployee employee)
        {
            string newPhoneNumber = GetValidPhoneNumber();
            if (!string.IsNullOrEmpty(newPhoneNumber))
            {
                employee.PhoneNumber = newPhoneNumber;
                Console.WriteLine("Номер телефона успешно обновлен");
            }
            else
            {
                throw new ArgumentException("Ошибка: неверный номер телефона.");
            }
        }

        /// <summary>
        /// Получает валидный номер телефона от пользователя.
        /// </summary>
        /// <returns>Валидный номер телефона.</returns>
        private string GetValidPhoneNumber()
        {
            while (true)
            {
                string inputNum = GetInput("Введите номер телефона:");
                string patternPhone = @"^(\+7|7|8)?\s*\(?(\d{3})\)?[\s-]?(\d{3})[\s-]?(\d{2})[\s-]?(\d{2})$";

                if (Regex.IsMatch(inputNum, patternPhone))
                {
                    return inputNum;
                }

                Console.WriteLine("Номер телефона не валидный. Попробуйте снова.");
            }
        }

        /// <summary>
        /// Запрашивает у пользователя выбор должности.
        /// </summary>
        /// <returns>Выбранная должность.</returns>
        private Post? ChoosePost()
        {
            var posts = Enum.GetValues(typeof(Post));
            for (int i = 0; i < posts.Length; i++)
            {
                Console.WriteLine($"{i + 1} - {posts.GetValue(i)}");
            }

            if (int.TryParse(Console.ReadLine(), out int selectedIndex) && selectedIndex >= 1 &&
                selectedIndex <= posts.Length)
            {
                return (Post)posts.GetValue(selectedIndex - 1);
            }

            throw new ArgumentException("Неверный выбор должности.");
        }

        /// <summary>
        /// Получает ввод пользователя с указанным сообщением.
        /// </summary>
        /// <param name="prompt">Сообщение для пользователя.</param>
        /// <returns>Ввод пользователя.</returns>
        private string GetInput(string prompt)
        {
            Console.WriteLine(prompt);
            return Console.ReadLine();
        }

        /// <summary>
        /// Сериализует данные о сотрудниках в файл.
        /// </summary>
        private void SerializeData()
        {
            var fullpath = Path.Combine(_filePath, "Employee.txt");
            var strBuild = new StringBuilder();
            foreach (var employee in _employees)
            {
                strBuild.AppendLine($"{employee.Name}");
                strBuild.AppendLine($"Номер телефона: {employee.PhoneNumber}");
                strBuild.AppendLine($"Должность: {employee.Post}");
                strBuild.AppendLine($"Зарплата: {employee.GetSalary()}");
                strBuild.AppendLine($"Табельный номер: {employee.Id}");
                strBuild.AppendLine();
            }

            try
            {
                File.WriteAllText(fullpath, strBuild.ToString());
            }
            catch (IOException ex)
            {
                throw new IOException($"Ошибка при сохранении данных: {ex.Message}");
            }
        }

        /// <summary>
        /// Десериализует данные о сотрудниках из файла.
        /// </summary>
        /// <returns>Список сотрудников, загруженных из файла.</returns>
        private List<IEmployee> DeserializeData()
        {
            var fullpath = Path.Combine(_filePath, "Employee.txt");
            var employees = new List<IEmployee>();

            if (!File.Exists(fullpath))
            {
                File.Create(fullpath).Dispose();
                return employees;
            }

            var lines = File.ReadAllLines(fullpath);

            try
            {
                for (int i = 0; i < lines.Length;)
                {
                    string name = lines[i].Trim();
                    i++;
                    string phoneNumber = lines[i].Split(new[] { ": " }, StringSplitOptions.None)[1].Trim();
                    i++;
                    Post post = (Post)Enum.Parse(typeof(Post),
                        lines[i].Split(new[] { ": " }, StringSplitOptions.None)[1].Trim());
                    i++;
                    i++;
                    int id = int.Parse(lines[i].Split(new[] { ": " }, StringSplitOptions.None)[1].Trim());
                    i++;
                    i++;
                    var employee = new Employee(post, phoneNumber, name, id);
                    employees.Add(employee);
                }
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Ошибка при загрузке данных сотрудников: {ex.Message}");
            }

            return employees;
        }

        #endregion

        #region Конструкторы

        /// <summary>
        /// Инициализирует менеджера сотрудников и загружает данные из файла при старте.
        /// </summary>
        private EmployeeManager()
        {
            this._filePath = Directory.GetCurrentDirectory();
            this._employees = DeserializeData();
            AppDomain.CurrentDomain.ProcessExit += (s, e) => SerializeData();
        }

        #endregion
    }
}
