using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_05
{
    internal class Club
    {
        public int ClubID { get; set; }
        public String ClubName { get; set; }
        List<Employee> Members;

        public Club()
        {
            Members = new List<Employee>();
        }

        public void AddMember(Employee E)
        {

            ///Try Register for EmployeeLayOff Event Here

            if (E != null && !Members.Contains(E))
            {
                E.EmployeeLayOff += this.RemoveMember;
                Members.Add(E);
            }

        }
        ///CallBackMethod
        public void RemoveMember(object sender, EmployeeLayOffEventArgs e)
        {

            ///Employee Will not be removed from the Club if Age>60
            ///Employee will be removed from Club if Vacation Stock < 0

            if (sender is Employee Emp && Members.Contains(Emp) && e.Cause == LayOffCause.VactionStock)
            {
                Console.WriteLine($"{Emp} Has Been Removed FromCompany Club");
                Console.WriteLine($"The Reason For Laying Off is {e.Cause}");
                Members.Remove(Emp);
            }

        }
    }
}