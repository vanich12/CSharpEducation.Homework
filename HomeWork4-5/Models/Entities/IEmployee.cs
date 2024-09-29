using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork4
{
    /// <summary>
    /// работник, наследуется от персоны
    /// </summary>
    public interface IEmployee: IPerson
    {
        double GetSalary();
        Post Post { get; set; }
        string PhoneNumber { get; set; }
    }
}
