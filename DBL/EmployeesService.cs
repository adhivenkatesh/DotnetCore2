using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotnetCore2.DBL
{
    public class EmployeesService : IEmployeesService
    {
        private List<Employees> _EmployeesList;
        public EmployeesService()
        {
            _EmployeesList = new List<Employees>() {

               new Employees() {id=1,name="shri sankara"},
               new Employees() {id=2,name="shri aadhi"},
               new Employees() {id=3,name="shri lakshmi"},
            };
        }
        public Employees add(Employees _employees)
        {
            _employees.id = _EmployeesList.Max(e => e.id) + 1;
            _EmployeesList.Add(_employees);

            return _employees;
        }

        public IEnumerable<Employees> GetAll()
        {
            return _EmployeesList;
        }
    }
}
