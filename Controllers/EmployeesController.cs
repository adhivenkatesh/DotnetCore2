using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotnetCore2.DBL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DotnetCore2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private IEmployeesService _IEmployeesService;
        public EmployeesController(IEmployeesService IEmployeeservice)
        {
            _IEmployeesService = IEmployeeservice;
        }

        //[HttpGet]
        //public IActionResult Create()
        //{
        //    return View();
        //}

        //[HttpPost]

        //public IActionResult Create(Employees _Employees)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        Employees newMobile = _IEmployeesService.add(_Employees);
        //    }

        //    return View();
        //}
    }
}
