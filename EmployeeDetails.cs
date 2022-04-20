using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePayRollThread
{
    public class EmployeeDetails
    {
         
            public int  ID { get; set; }
            public string EmployeeNumber { get; set; }
            public string PhoneNumber { get; set; }
            public string Address { get; set; }
            public string Department { get; set; } 

            public EmployeeDetails(int ID,string EmployeeNumber,
                string PhoneNumber,string Address,string Department)
            {
            this.ID = ID;
            this.EmployeeNumber=EmployeeNumber;
            this.PhoneNumber = PhoneNumber;
            this.Address = Address;
            this.Department = Department;

            }
       
    }
}
