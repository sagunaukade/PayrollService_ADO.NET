using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePayrollService_ADO.NET
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Employee Payroll Service using ADO.NET");
            //UC-1
            EmployeeRepo.GetAllEmployees();
            //UC-2
            EmployeeRepo.GetAllEmployeesUsingDataAdapter();
            Console.ReadLine();
        }
    }
}
