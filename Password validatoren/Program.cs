using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Password_validatoren
{
    class Program
    {
        static string password;

        static void Main(string[] args)
        {
            // Calling methods.
            Program.Gui();

            // Only using a ReadLine so console does not close.
            Console.ReadLine();
        }

        static void Gui()
        {
            Console.WriteLine("Indtast dit passowrd for validering:");

            Program.Controller();

            // If we return a false in any of the bools we tell the user whats is wrong.
            if(!IsPasswordLengthValid())
            {
                Console.WriteLine("Dit password skal mindst 12 tegn langt og må maks være 64 tegn langt.");
                Program.Gui();
            }
            else if(!IsPasswordDigitValid())
            {
                Console.WriteLine("Dit password skal mindst have et tal.");
                Program.Gui();
            }
            else if (!IsPasswordLetterValid())
            {
                Console.WriteLine("Dit password skal mindst have et bogstav.");
                Program.Gui();
            }
            else if (!IsPasswordSymbolValid())
            {
                Console.WriteLine("Dit password skal mindst have et specialtegn.");
                Program.Gui();
            }
            else if (!IsPasswordUpperLowerValid())
            {
                Console.WriteLine("Dit password skal mindst have et Stort og lille bogstav.");
                Program.Gui();
            }
            // if all things are true then we go and check how strong the password is.
            else
            {
                if (IsPassword4InARow() && IsPasswordASequenceOfNumbers())
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Passwordet er ikke stærkt nok.");
                    Console.ResetColor();
                }
                else if (IsPassword4InARow() || IsPasswordASequenceOfNumbers())
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Passwordet er OK, men betragtes som svagt");
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Passwordet er OK.");
                    Console.ResetColor();
                }
            }
            
        }

        static void Module()
        {
            Program.password = Console.ReadLine();
        }

        static void Controller()
        {
            Program.Module();

            Program.IsPasswordLengthValid();
            Program.IsPasswordDigitValid();
            Program.IsPasswordLetterValid();
            Program.IsPasswordSymbolValid();
            Program.IsPasswordUpperLowerValid();
        }
        // Under here we validate our password and return a bool.
        static bool IsPasswordSymbolValid()
        {
            return password.Any(ch => !char.IsLetterOrDigit(ch));
        }
        static bool IsPasswordLengthValid()
        {
            return password.Length >= 12 && password.Length <= 64;
        }
        static bool IsPasswordDigitValid()
        {
            return
           password.Any(char.IsDigit);
        }
        static bool IsPasswordLetterValid()
        {
            return password.Any(char.IsLetter);
        }
        static bool IsPasswordUpperLowerValid()
        {
            return password.Any(char.IsUpper) && password.Any(char.IsLower);
        }
        static bool IsPassword4InARow()
        {
            // we loop through our string and check if that we dont have 4 chars that are the same next to eachother.
            for(int i = 0; i < password.Length-3; ++i)
            {
                if(password[i] == password[i + 1] && password[i] == password[i + 2] && password[i] == password[i + 3])
                {
                    return true;
                }
            }
            return false;
        }
        static bool IsPasswordASequenceOfNumbers()
        {
            char[] chararr = password.ToCharArray();
            int[] ints = new int[chararr.Length];
            int count = 0;

            // we loop through our array and check if that we dont have a Sequence of numbers (example: 1234).
            foreach (char ch in chararr)
            {
                if (char.IsDigit(ch))
                {
                    ints[count] = chararr[count];
                }
                else
                {
                    ints[count] = -2;
                }

                count++;
            }

            for (int i = 0; i < ints.Length - 3; i++)
            {
                if (ints[i]+1 == ints[i + 1] && ints[i+1]+1 == ints[i + 2] && ints[i+2]+1 == ints[i + 3])
                {
                    return true;
                }
            }

            return false;
        }
    }
}
