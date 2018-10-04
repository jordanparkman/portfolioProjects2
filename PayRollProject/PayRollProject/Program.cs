using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace PayRollProject
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Staff> listOfStaff = new List<Staff>();
            FileManager fr = new FileManager();
            int month = 0, year = 0;

            /* Continuously ask user for valid input.
             * If invalid, catch the exception and display a message
             * The loop will continue until year and month are given a value.
             */
            while (year == 0)
            {
                Console.WriteLine("\nEnter the payroll year: ");
                try
                {
                    year = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message + "Invalid. Year must be an integer.");
                }
            }

            while (month == 0)
            {
                Console.WriteLine("\nEnter the payroll month: ");

                try
                {
                    month = Convert.ToInt32(Console.ReadLine());
                    if (month < 1 || month > 12)
                    {
                        Console.WriteLine("Invalid. Month must be an integer inclusively between 1 and 12.");
                        month = 0;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message + "  Invalid. Please try again.");
                }
            }

            listOfStaff = fr.ReadFile();
            for (int i = 0; i<listOfStaff.Count; i++)
            {
                try
                {
                    Console.Write("\nEnter hours worked for {0} this month:", listOfStaff[i].StaffNames);
                    listOfStaff[i].HoursWorked = Convert.ToInt32(Console.ReadLine());
                    listOfStaff[i].CalculatePay();
                    Console.WriteLine(listOfStaff[i].ToString());

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    //Incase of an exception, stay on current iteration.
                    i--;
                }
            }
            PayStub ps = new PayStub(month, year);
            ps.GeneratePaySlip(listOfStaff);
            ps.GenerateSummary(listOfStaff);

            Console.Read();
        }
    }
}
