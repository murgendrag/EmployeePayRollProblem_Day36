using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePayRollThread
{
    public class AddEmployee
    {
        public List<EmployeeDetails> EmployeepayRollDetailsList = new List<EmployeeDetails>();

        public void Addemployeetolist(List<EmployeeDetails> employeedetails)
        {
            employeedetails.ForEach(employeeData =>
            {
                Console.WriteLine("employeebeing added:" +employeeData.EmployeeNumber);
                this.addEmployeePayRoll(employeeData);
                Console.WriteLine("Employeeadded :" +employeeData.EmployeeNumber);
            });
        }

        private void addEmployeePayRoll(EmployeeDetails emp)
        {
            EmployeepayRollDetailsList.Add(emp);
        }

        public void AddEmployeeTOListThread(List<EmployeeDetails> employeedetails)
        {
            employeedetails.ForEach(employeeData =>
            {
                Task thread = new Task(() =>
                {
                    Console.WriteLine("employeebeing added:" + employeeData.EmployeeNumber);
                    this.addEmployeePayRoll(employeeData);
                    Console.WriteLine("Employeeadded :" + employeeData.EmployeeNumber);
                });
                thread.Start();
            });
            Console.WriteLine(this.EmployeepayRollDetailsList);
        }
    }
}
