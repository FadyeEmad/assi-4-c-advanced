using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_05
{
    public class Department
    {
        public int DeptID { get; set; }
        public string DeptName { get; set; }

        List<Employee> Staff;

        public Department()
        {
            Staff = new List<Employee>();
        }

        public void AddStaff(Employee E)
        {

            ///Try Register for EmployeeLayOff Event Here

            if (E != null && !Staff.Contains(E))
            {
                Staff.Add(E);
                E.EmployeeLayOff += this.RemoveStaff;
            }

        }
        ///CallBackMethod
        public void RemoveStaff(object sender, EmployeeLayOffEventArgs e)
        {
            if (sender is Employee E && Staff.Contains(E))
            {
                Staff.Remove(E);
                Console.WriteLine($"{E} Has Been Removed From Department {this.DeptName}");
                Console.WriteLine($"The Reason For Laying Off is {e.Cause}");
            }

        }
    }
}