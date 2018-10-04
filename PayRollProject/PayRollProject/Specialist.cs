using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayRollProject
{
    class Specialist : Staff
    {
        private const float _specialistRate = 20f; 

        public Specialist(string name) : base(name, _specialistRate)
        {
        }

        public override string ToString()
        {
            return "_specialistRate = " + _specialistRate;                  
        }

    }
}
