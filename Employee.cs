using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_05
{
    public enum LayOffCause
    {
        VactionStock = 1,
        Age = 2,
        TargetFailed = 3,
        Resigned = 4
    }

    public class EmployeeLayOffEventArgs : EventArgs
    {
        public LayOffCause Cause { get; set; }
    }
    public class Employee
    {
        public event EventHandler<EmployeeLayOffEventArgs> EmployeeLayOff;
        protected virtual void OnEmployeeLayOff(EmployeeLayOffEventArgs e)
        {
            EmployeeLayOff?.Invoke(this, e);
        }
        public int EmployeeID { get; set; }
        public string Name { get; set; }
        DateTime birthDate;
        public DateTime BirthDate
        {
            get => birthDate;
            set
            {
                if (DateTime.Now.Year - value.Year >= 60)
                    OnEmployeeLayOff(new EmployeeLayOffEventArgs() { Cause = LayOffCause.Age });
                birthDate = value;
            }

        }
        int vacationStock;
        public virtual int VacationStock
        {
            get => vacationStock;
            set
            {
                if (value < 0)
                    OnEmployeeLayOff(new EmployeeLayOffEventArgs() { Cause = LayOffCause.VactionStock });
                vacationStock = value;

            }
        }
        public bool RequestVacation(DateTime From, DateTime To)
        {
            if (To.Day - From.Day > vacationStock)
            {
                OnEmployeeLayOff(new EmployeeLayOffEventArgs() { Cause = LayOffCause.VactionStock });
                return false;

            }
            vacationStock -= (To.Day - From.Day);
            return true;
        }
        public void EndOfYearOperation()
        {
            if (DateTime.Now.Year - birthDate.Year >= 60)
            {
                OnEmployeeLayOff(new EmployeeLayOffEventArgs() { Cause = LayOffCause.Age });
                Console.WriteLine($"Employee ID: {EmployeeID}, Name: {Name}, has Been Layed Off");
            }
            else
                Console.WriteLine($"Employee ID: {EmployeeID}, Name: {Name}");

        }
        public override string ToString()
        {
            return $"Employee ID: {EmployeeID}, Name: {Name}";
        }

    }
}