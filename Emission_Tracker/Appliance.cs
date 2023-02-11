using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emission_Tracker
{
    class Appliance
    {
        public string name = "";
        public int consumption = 0;
        public int usage = 0;
        public static int count = -1;
        public Appliance(string aname, int aconsumption, int ausage) {
            name = aname;
            consumption = aconsumption;
            usage = ausage;
            count++;
        }
    }
}
