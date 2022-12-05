using SampleMVcApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SampleMVcApp.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public string Index()
        {
            var model = "Hello Asp.Net MVC";
            return model;
        }
        public string AnotherIndex() => "Test Another action";
        public Employee GetEmployee() => new Employee
        {
            EmpID = 123,
            EmpName = "Navatha",
            EmpAddress = "Andhra Pradesh",
            EmpSalary = 12334
        };
        public ViewResult CurrentEmployee()
        {
            var model = new Employee
            {
                EmpAddress = "Andhra Pradesh",
                EmpID = 123,
                EmpName="Navatha",
                EmpSalary=1234
                
            };
            return View(model);
        }
        
    }
}