using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PhoneBook phoneBook = new PhoneBook();

            while (true)
            {
                Console.WriteLine("Выберите действие:");
                Console.WriteLine("0. Вывести абонента");
                Console.WriteLine("1. Добавить абонента");
                Console.WriteLine("2. Удалить абонента");
                Console.WriteLine("3. Найти абонента по номеру телефона");
                Console.WriteLine("4. Найти абонента по имени");
                Console.WriteLine("5. Выйти");

                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "0":
                        phoneBook.PrintPersons();
                        break;
                    case "1":
                        Console.WriteLine("Введите имя:");
                        var name = Console.ReadLine();
                        Console.WriteLine("Введите номер телефона:");
                        var phoneNumber = Console.ReadLine();
                        var fabonent = new Abonent(name, phoneNumber);
                        phoneBook.AddPerson(fabonent);
                        break;

                    case "2":
                        Console.WriteLine("Введите имя абонента для удаления:");
                        var nameToDelete = Console.ReadLine();
                        var sabonent = phoneBook.GetPerson2(nameToDelete);
                        phoneBook.RemovePerson(sabonent);
                        break;

                    case "3":
                        Console.WriteLine("Введите номер телефона:");
                        var numberToSearch = Console.ReadLine();
                        phoneBook.GetAbonentFromNumber(numberToSearch);
                        break;

                    case "4":
                        Console.WriteLine("Введите имя:");
                        var nameToSearch = Console.ReadLine();
                        phoneBook.GetAbonentFromName(nameToSearch);
                        break;

                    case "5":
                        return;

                    default:
                        Console.WriteLine("Неверный выбор. Пожалуйста, выберите действие из списка.");
                        break;
                }

                Console.WriteLine();
            }
        }
    }
}
