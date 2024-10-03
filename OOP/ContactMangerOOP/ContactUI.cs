using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactMangerOOP
{
    internal class ContactUI
    {
        public static void ShowMenu()
        {
           
            Console.WriteLine("Welcome to Contact Manager");
            Console.WriteLine("1 - Add New Contact");
            Console.WriteLine("2 - Edit Contact");
            Console.WriteLine("3 - Remove Contact");
            Console.WriteLine("4 - View Contacts");
            Console.WriteLine("5 - Search Contact");
            Console.WriteLine("6 - Exit");
            Console.Write("Your choice: ");
        }

        public static string GetUserChoice()
        {
            return Console.ReadLine();
        }
    }
}
