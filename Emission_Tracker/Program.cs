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
            Appliance[] appliances = new Appliance[20];
            string[] names = new string[20];

            Console.WriteLine("Welcome to the emission tracker!");
            Console.WriteLine();
            while (true)
            {
                int option = getOptions();

                switch (option)
                {
                    case 0:
                        Console.WriteLine("Selected Create Appliance");
                        Appliance newAppliance = createAppliance(names);
                        appliances[Appliance.count] = newAppliance;
                        break;
                    case 1:
                        Console.WriteLine("Selected Create Appliance");
                        listAppliances(appliances);
                        
                        break;
                }
            }
        }

        static dynamic getOptions()
        {
            bool optionSuccess = false;
            int option = 0;

            
            while (!optionSuccess)
            {
                Console.WriteLine("Here are the options:");
                Console.WriteLine("Option 0: Create an appliance");
                Console.WriteLine("Option 1: View all appliances");
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

        static void listAppliances(Appliance[] appliances)
        {
            Console.WriteLine("Listing appliances: ");
            for (int x = 0; x < appliances.Length-1; x++)
            {
                try
                {
                    Console.WriteLine("Appliance " + appliances[x].name + " consumes " + appliances[x].consumption + " Watts, and is used for " + appliances[x].usage + " hours each year.");
                }
                catch
                {
                    continue;
                }
            }
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
                names[Appliance.count+1] = name;
                createSuccess = true;

            }
            appliance = new Appliance(name, consumption, usage);

            Console.WriteLine("You entered: " + appliance.name + " " + appliance.consumption + " " + appliance.usage);

            return appliance;
        }
    }
}
        