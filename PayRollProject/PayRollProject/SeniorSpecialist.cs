using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayRollProject
{
    /* Overrides the CalculatePay method*/
    class SeniorSpecialist : Staff
    {
        private const float seniorHourlyRate = 50f;

        public float overtimeBonusPay { get; private set; }

        public SeniorSpecialist(string name) : base(name,seniorHourlyRate)
        {
        }

        public override void CalculatePay()
        {
            //Call base CalculatePay method to get BasePay value.
            base.CalculatePay();

            //Senior specialist get time and a half bonus pay if they work more than 160 hours.
            float overtimeBonusPercentage = 1.5f;
            if (HoursWorked > 160)
            {
                int overtimeHours = HoursWorked - 160;
                overtimeBonusPay = overtimeHours * overtimeBonusPercentage * seniorHourlyRate;
                TotalPay = BasePay + overtimeBonusPay;
            }
        }

        public override string ToString()
        {
            return "seniorHourlyRate = " + seniorHourlyRate + "\n" +
                "overtimeBonusPay = " + overtimeBonusPay;
        }
    }
}
