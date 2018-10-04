using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayRollProject
{
    /* This class contains data on the staff of the company.
     * This class will also calculate the pay for the staff.
     */
    class Staff
    {
        private float _hourlyRate;
        private int _hoursWorked;

        public Staff(string name, float rateOfPay)
        {
            _hourlyRate = rateOfPay;
            StaffNames = name;
        }

        public float TotalPay { get; protected set; }
        public float BasePay { get; private set; }
        public string StaffNames { get; private set; }

        //Setter than ensures you can't print negative work hours.
        public int HoursWorked {
            get { return _hoursWorked; }
            set { if (value > 0)
                    _hoursWorked = value;
                else
                    _hoursWorked = 0;
            }
        }

        /* This method calculates the pay for a normal employee.
         * It's virtual so other types of staff that get bonuses,
         * can do their own calculations.
         */
        public virtual void CalculatePay()
        {
            Console.WriteLine("Calculating Payment...");
            BasePay = _hoursWorked * _hourlyRate;
            TotalPay = BasePay;

        }

        public override string ToString()
        {
            return "Name of Staff = " + StaffNames +
                " ,hourlyRate = " + _hourlyRate + " ,_hoursWorked = " + _hoursWorked;
        }
    }
}
