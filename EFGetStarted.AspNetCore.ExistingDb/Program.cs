using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace EFGetStarted.AspNetCore.ExistingDb
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            int result = -1;
            while (result != 9)
            {
                result = MainMenu();
            }
        }

        static int MainMenu()
        {
            int result = -1;
            ConsoleKeyInfo cki;
            bool cont = false;
            do
            {
                Console.Clear();
                WriteHeader("Welcome to Newbie Data Systems");
                WriteHeader("Main Menu");
                Console.WriteLine("\r\nPlease select from the list below for what you would like to do today");
                Console.WriteLine("1. List All Machines in Inventory");
                Console.WriteLine("2. List All Operating Systems");
                Console.WriteLine("3. Data Entry Menu");
                Console.WriteLine("9. Exit");
                cki = Console.ReadKey();
                try
                {
                    result = Convert.ToInt16(cki.KeyChar.ToString());
                    if (result == 1)
                    {
                        //DisplayAllMachines();
                    }
                    else if (result == 2)
                    {
                        //DisplayOperatingSystems();
                    }
                    else if (result == 3)
                    {
                        DataEntryMenu();
                    }
                    else if (result == 9)
                    {
                        // We are exiting so nothing to do
                        cont = true;
                    }
                }
                catch (System.FormatException)
                {
                    // a key that wasn't a number
                }

            } while (!cont);

            return result;
        }

        static void DataEntryMenu()
        {
            ConsoleKeyInfo cki;
            int result = -1;
            bool cont = false;
            do
            {
                Console.Clear();
                WriteHeader("Data Entry Menu");
                Console.WriteLine("\r\nPlease select from the list below for what you would like to do today");
                Console.WriteLine("1. Add a New Machine");
                Console.WriteLine("2. Add a New Operating System");
                Console.WriteLine("3. Add a New Warranty Provider");
                Console.WriteLine("9. Exit Menu");
                cki = Console.ReadKey();
                try
                {
                    result = Convert.ToInt16(cki.KeyChar.ToString());
                    if (result == 1)
                    {
                        //AddMachine();
                    }
                    else if (result == 2)
                    {
                        AddOperatingSystem();
                    }
                    else if (result == 3)
                    {
                        //AddNewWarrantyProvider();
                    }
                    else if (result == 9)
                    {
                        // We are exiting so nothing to do
                        cont = true;
                    }
                }
                catch (System.FormatException)
                {
                    // a key that wasn't a number
                }
            } while (!cont);
        }

        static void WriteHeader(string headerText)
        {
            Console.WriteLine(string.Format("{0," + ((Console.WindowWidth / 2) +
                                                     headerText.Length / 2) + "}", headerText));
        }

        static bool ValidateYorN(string entry)
        {
            bool result = false;
            if (entry.ToLower() == "y" || entry.ToLower() == "n")
            {
                result = true;
            }

            return result;
        }

        static bool CheckForExistingOS(string osName)
        {
            bool exists = false;
            using (var context = new MachineContext())
            {
                var os = context.OperatingSys.Where(o => o.Name == osName);
                if (os.Count() > 0)
                {
                    exists = true;
                }
            }

            return exists;
        }

    }
}

