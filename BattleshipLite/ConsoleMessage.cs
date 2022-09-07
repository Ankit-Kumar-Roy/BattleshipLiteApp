using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipLite
{
    public static class ConsoleMessage
    {
        public static void Display(string message)
        {
            Console.Write(message);
        }

        public static string UserInput(string message)
        {
            Console.Write(message);
            string output = Console.ReadLine();
            return output;
        }
    }
}