using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Emission_Tracker
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            string[] names = new string[20];

            int option = getOptions();

            switch (option)
            {
                case 0:
                    Console.WriteLine("Selected Create Appliance");
                    createAppliance(names);
                    break;
            }

            Console.ReadLine(); 
        }

        static dynamic getOptions()
        {
            bool optionSuccess = false;
            int option = 0;

            Console.WriteLine("Welcome to the emission tracker!");
            Console.WriteLine();
            while (!optionSuccess)
            {
                Console.WriteLine("Here are the options:");
                Console.WriteLine("Option 0: Create an appliance");
                Console.Write("Enter an option: ");
                try
                {
                    option = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Invalid input");
                    continue;
                }
                optionSuccess = true;

            }
            return option;
        }

        static Appliance createAppliance(string[] names)
        {
            string name = "";
            int consumption = 0; // In watts
            int usage = 0; // In hours
            bool createSuccess = false;

            Appliance appliance;

            while (!createSuccess)
            {
                try
                {
                    Console.Write("Enter Appliance Name: ");
                    name = Console.ReadLine();
                    Console.Write("Enter appliance consumption (in Watts): ");
                    consumption = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Enter appliance usage (in hours per year): ");
                    usage = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Invalid response");
                    continue;
                }
                if (Array.IndexOf(names, name) != -1)
                {
                    continue;
                }
                names.Append(name);
                createSuccess = true;

            }
            appliance = new Appliance(name, consumption, usage);

            Console.WriteLine("You entered: " + name + " " + consumption + " " + usage);

            return appliance;
        }
    }
}
        