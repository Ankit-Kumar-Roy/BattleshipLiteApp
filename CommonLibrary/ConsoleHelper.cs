using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLibrary
{
    public static class ConsoleHelper
    {
        public static string RequestInput(string message)
        {
            Console.Write(message);
            return Console.ReadLine();
        }

        public static void DisplayMessage(string message)
        {
            Console.Write(message);
        }

        public static void Display(string message)
        {
            Console.WriteLine(message);
        }
    }
}
