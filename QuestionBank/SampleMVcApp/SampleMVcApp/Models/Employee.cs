using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SampleMVcApp.Models
{
    public class Employee
    {
        public int EmpID { get; set; }
        public string EmpName { get; set; }
        public string EmpAddress { get; set; }
        public double EmpSalary { get; set; }
        public override string ToString()
        {
            return $"<h1>{EmpName}<h1><hr/>address:{EmpAddress}<p>Salary:{EmpSalary}";
        }

    }
}