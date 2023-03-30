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
        private int priority = 0;
        public Appliance(string aname, int aconsumption, int ausage, int apriority) {
            name = aname;
            consumption = aconsumption;
            usage = ausage;
            Priority = apriority;
            count++;
        }

        public int Priority
        {
            get { return priority; }
            set {
                if (value == 1 || value == 2 || value == 3 || value == 4)
                {
                    priority = value;
                }
                else
                {
                    priority = 4;
                }
            }
        }
    }
}
