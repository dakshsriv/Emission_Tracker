using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Emission_Tracker
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Appliance[] appliances = new Appliance[20];
            string[] names = new string[20];
            int rate = 0;
            int num = 0;

            Console.WriteLine("Welcome to the emission tracker!");
            Console.WriteLine();
            while (true)
            {
                int option = getOptions();

                switch (option)
                {
                    case 0:
                        Console.WriteLine("Selected Create Appliance");
                        Appliance newAppliance = createAppliance(appliances, names);
                        appliances[Appliance.count] = newAppliance;
                        num++;
                        break;
                    case 1:
                        Console.WriteLine("Selected List Appliances");
                        listAppliances(appliances);
                        break;
                    case 2:
                        Console.WriteLine("Selected Update Appliance");
                        Console.Write("What is the name of the appliance you want to change: ");
                        string name = Console.ReadLine();

                        if (Array.IndexOf(names, name) == -1)
                        {
                            Console.WriteLine("Invalid name");
                            break;
                        }
                        int x = Array.IndexOf(names, name);
                        Appliance updatedAppliance = updateAppliance(appliances, names, name, x);
                        names[x] = updatedAppliance.name;
                        appliances[x] = updatedAppliance;
                        break;
                    case 3:
                        Console.WriteLine("Selected Delete Appliance");
                        Console.Write("What is the name of the appliance you want to delete: ");
                        string deleteName = Console.ReadLine();

                        if (Array.IndexOf(names, deleteName) == -1)
                        {
                            Console.WriteLine("Invalid name");
                            break;
                        }
                        int y = Array.IndexOf(names, deleteName);
                        names[y] = "";
                        appliances[y] = null;
                        break;
                    case 4:
                        Console.WriteLine("Selected set carbon emission rates");
                        Console.Write("What is the carbon emission rate (in CO2e per kWh): ");
                        rate = Convert.ToInt32(Console.ReadLine());
                        break;
                    case 5:
                        Console.WriteLine("Selected calculate carbon emissions");
                        calculate(appliances, rate, num);
                        break;
                }
            }
        }

        static void calculate(Appliance[] appliances, int rate, int num)
        {
            int emissions = 0;
            for (int x = 0; x < num; x++)
            {
                
                Appliance appl = appliances[x];
                
                emissions += appl.consumption * appl.usage;
            }
            emissions *= 1000 * rate;
            Console.WriteLine("Each year, you emit " + emissions + " tonnes of CO2e.");
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
                Console.WriteLine("Option 2: Update an appliance");
                Console.WriteLine("Option 3: Delete an appliance");
                Console.WriteLine("Option 4: Set carbon emission rates");
                Console.WriteLine("Option 5: Calculate carbon emissions");

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
                    Console.WriteLine("Appliance " + appliances[x].name + " consumes " + appliances[x].consumption + " Watts, and is used for " + appliances[x].usage + " hours each year. It has a priority of " + appliances[x].Priority);
                }
                catch
                {
                    continue;
                }
            }
        }


        static Appliance updateAppliance(Appliance[] appliances, string[] names, string name, int x)
        {
            string newName = "";
            int newConsumption = 0; // In watts
            int newUsage = 0; // In hours
            bool newUpdateSuccess = false;

            Appliance newAppliance;
            int applianceIndex = 0;


            newName = appliances[x].name;
            newConsumption = appliances[x].consumption;
            newUsage = appliances[x].usage;
            applianceIndex = x;

            int priority = 4;
                    
            while (!newUpdateSuccess)
            {
                try
                {
                    Console.Write("Enter Appliance Name: ");
                    newName = Console.ReadLine();
                    Console.Write("Enter appliance consumption (in Watts): ");
                    newConsumption = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Enter appliance usage (in hours per year): ");
                    newUsage = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Enter appliance priority: ");
                    priority = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Invalid response");
                    continue;
                }
                if (Array.IndexOf(names, newName) != -1)
                {
                    continue;
                }
                names[applianceIndex] = name;
                newUpdateSuccess = true;

            }
            newAppliance = new Appliance(newName, newConsumption, newUsage, priority);

            Console.WriteLine("You entered: " + newAppliance.name + " " + newAppliance.consumption + " " + newAppliance.usage);

            return newAppliance;
        }

        static Appliance createAppliance(Appliance[] appliances, string[] names)
        {
            string name = "";
            int consumption = 0; // In watts
            int usage = 0; // In hours
            bool createSuccess = false;

            int priority = 4;

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
                    Console.Write("Enter appliance priority: ");
                    priority = Convert.ToInt32(Console.ReadLine());
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
            appliance = new Appliance(name, consumption, usage, priority);

            Console.WriteLine("You entered: " + appliance.name + " " + appliance.consumption + " " + appliance.usage);

            return appliance;
        }
    }
}
        