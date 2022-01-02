using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Ex3.Models
{
    public static class GetData
    {
        public static string GetText()
        {
            string text;
            bool isCorrectText;

            do
            {
                isCorrectText = true;
                text = Console.ReadLine();
                
                foreach (char sign in text)
                {
                    if (Char.IsNumber(sign))
                    {
                        isCorrectText = false;
                        Console.Write($"Wrong value. Type again without numbers: ");
                        break;
                    }
                }
                if (text.Length < 2)
                {
                    isCorrectText = false;
                    Console.Write($"Wrong value. Only one char is not enought: ");
                }
            } while (!isCorrectText);
            return text;
        }

        public static int  GetAge()
        {
            int age;
            bool isCorrect;

            do
            {
                isCorrect = true;
                
                if (!int.TryParse( Console.ReadLine(), out age))
                {
                    isCorrect = false;
                    Console.Write($"Wrong value. Only numbers: ");
                }
                else if(age<18 || age>99)
                {
                    isCorrect = false;
                    Console.Write($"Wrong value. Type age beetwen 18 - 99: ");
                }

            } while (!isCorrect);

            return age;
        }

        public static int GetNumberValuBeetwen(int min, int max )
        {
            bool isCorrect;
            int choosenOption;

            do
            {
                isCorrect = true;

                if (!int.TryParse(Console.ReadLine(), out choosenOption))
                {
                    isCorrect = false;
                    Console.Write($"Wrong value. Type menu option again: ");
                }
                else if (choosenOption < min || choosenOption > max)
                {
                    isCorrect = false;
                    Console.Write($"Wrong value. Type menu option again: ");
                }
            } while (!isCorrect);
            return choosenOption;
        }
    }
}
