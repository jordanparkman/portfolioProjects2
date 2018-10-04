using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace PayRollProject
{
    /* This class reads from a text file to create a list
     * of the Staff. */
    class FileManager
    {
        //Read from a text file that contains the names and positions of staff.
        public List<Staff> ReadFile()
        {
            List<Staff> myStaff = new List<Staff>();
            string[] result = new string[2];
            string path = "staff.txt";
            string[] separator = { ", " };

            if (File.Exists(path))
            {
                //Used to read text file line by line.
                using (StreamReader sr = new StreamReader(path))
                {
                    while (!sr.EndOfStream)
                    {
                        /* Each time we read a line, use the split method to split the line into two parts
                         * and store the result in the results array. */
                        result = sr.ReadLine().Split(separator, StringSplitOptions.RemoveEmptyEntries);
                        if (result[1] == "SeniorSpecialist")
                            myStaff.Add(new SeniorSpecialist(result[0]));
                        else if (result[1] == "Administrator")
                            myStaff.Add(new Administrator(result[0]));
                        else if (result[1] == "Specialist")
                            myStaff.Add(new Specialist(result[0]));
                    }
                    sr.Close();
                }
            } else
            {
                Console.WriteLine("Error: File does not exist");
            }
            return myStaff;
        }
    }
}
