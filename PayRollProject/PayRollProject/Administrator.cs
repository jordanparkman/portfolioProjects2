using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayRollProject
{
    /* Overrides the CalculatePay method*/
    class Administrator : Staff
    {
        private const float _overtimeRate = 25.75f;
        private const float adminHourlyRate = 40f;

        public float Overtime { get; private set; }

        public Administrator(string name) : base(name, adminHourlyRate)
        {
            //Call base constructor to pass name and adminHourlyRate.
        }

        public override void CalculatePay()
        {
            //Call base CalculatePay method to get TotalPay value.
            base.CalculatePay();
            //Admins get overtime pay if they work more than 160 hours.
            if (HoursWorked > 160)
            {
                Overtime = _overtimeRate * (HoursWorked - 160);
                TotalPay += Overtime;
            }
        }

        public override string ToString()
        {
            return "_overtimeRate = " + _overtimeRate + "\n"+
                "adminHourlyRate = " + adminHourlyRate + "\n" +
                "Overtime = " + Overtime;
        }

    }
}
