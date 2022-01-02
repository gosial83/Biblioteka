using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex3.Models
{
    public static class Menu
    {
        
        public static void PrintHeading(string heading)
        {
            Console.Clear();
            Console.WriteLine("____________________________________");
            Console.WriteLine(heading);
            Console.WriteLine("____________________________________\n");
        }

        public static void BackToMainMenu()
        {
            Console.Write("\nPress any key to back to the menu:");
            Console.ReadKey();
        }
    }





}
