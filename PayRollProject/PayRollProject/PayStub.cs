using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace PayRollProject
{
    class PayStub
    {
        private int month;
        private int year;
        enum MonthsOfYear
        { JAN=1, FEB, MAR, APR, MAY, JUN, JUL, AUG, SEP, OCT, NOV, DEC }

        public PayStub(int payMonth, int payYear)
        {
            month = payMonth;
            year = payYear;
        }

        /* Pay stubs are stored in the PayRollProject/bin/debug folder*/
        public void GeneratePaySlip(List<Staff> myStaff)
        {
            string path;
            //Loop through the elements of myStaff
            foreach (Staff firstName in myStaff)
            {
                path = firstName.StaffNames + ".txt";
                using (StreamWriter sw = new StreamWriter(path))
                {
                    //Generate the Employee's PayStub in the text file.
                    sw.WriteLine("PAYSTUB FOR {0} {1}", (MonthsOfYear)month, year);
                    sw.WriteLine("--------------------");
                    sw.WriteLine("Staff Name: {0}", firstName.StaffNames);
                    sw.WriteLine("Hours Worked: {0}", firstName.HoursWorked);
                    sw.WriteLine("");
                    sw.WriteLine("Base Pay: {0:C}", firstName.BasePay);
                    //Setter mines the runtime type of the object.
                    if (firstName.GetType() == typeof(SeniorSpecialist))
                        sw.WriteLine("Overtime Pay: {0:C}", ((SeniorSpecialist)firstName).overtimeBonusPay);
                    else if (firstName.GetType() == typeof(Administrator))
                        sw.WriteLine("Overtime Pay: {0:C}", ((Administrator)firstName).Overtime);

                    sw.WriteLine("");
                    sw.WriteLine("--------------------");
                    sw.WriteLine("Final Pay: {0:C}", firstName.TotalPay);
                    sw.WriteLine("--------------------");
                    sw.Close();

                }
            }
        }
        public void GenerateSummary(List<Staff> myStaff)
        {
            //Find staff that worked less than 160 hours.
            var result =
                from firstName in myStaff
                where firstName.HoursWorked < 160
                orderby firstName.StaffNames ascending
                select new { firstName.StaffNames, firstName.HoursWorked };

            string path = "summary.txt";

            using (StreamWriter sw = new StreamWriter(path))
            {
                sw.WriteLine("All Staff that worked less than 160 working hours");
                sw.WriteLine("");

                foreach (var firstName in result)
                    sw.WriteLine("Staff Member: {0}, Worked only for: {1} hours", firstName.StaffNames, firstName.HoursWorked);

                sw.Close();
            }
        }

        public override string ToString()
        {
            return "month = " + month + "year = " + year;
        }
    }
}
