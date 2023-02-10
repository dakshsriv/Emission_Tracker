using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emission_Tracker
{
    internal class Appliance
    {
        string name = "";
        int consumption = 0;
        int usage = 0;
        public Appliance(string aname, int aconsumption, int ausage) {
            name = aname;
            consumption = aconsumption;
            usage = ausage;
        }
    }
}
