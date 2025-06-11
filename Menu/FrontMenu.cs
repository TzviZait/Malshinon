using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Org.BouncyCastle.Pqc.Crypto.Utilities;

namespace Malshinon.Menu
{
    public class FrontMenu
    {
        public static void StartShow()
        {
            Console.Clear();
            Console.WriteLine("Welcome to Malshinon System");
            Console.WriteLine("1. Meneger");
            Console.WriteLine("2. Agent");
            Console.WriteLine("3. Exit");
            Console.Write("Please select an option: ");

            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    Login.L();
                    break;
                case "2":
                    Register.R();
                    break;
                case "3":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid choice, please try again.");
                    StartShow();
                    break;
            }
        }

        public static void AgentShow()
        {
            Console.WriteLine("What do you want to do:");
            Console.WriteLine("1. Add Report");
            Console.WriteLine("2. Add details agent");
            Console.WriteLine("3. Exit");
            Console.Write("Please select an option: ");
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    Console.WriteLine("Enter your ID.");
                    //int agentId;
                    int.TryParse(Console.ReadLine(),out int agentId);
                    AgentReportService.AddReports(1, 2, "Test message");
                    Console.WriteLine("Report added successfully.");
                    AgentShow();
                    break;
            }
            }
    }
}
