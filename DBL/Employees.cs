using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotnetCore2.DBL
{
    public class Employees
    {
        public int id { get; set; }
        public string name { get; set; }
    }

    public interface IEmployeesService
    {
        IEnumerable<Employees> GetAll();
        Employees add(Employees _employees);

    }
}
