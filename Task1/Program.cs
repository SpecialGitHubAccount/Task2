using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Task2;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            bool isExit = false;
            while(!isExit)
            {
                Console.WriteLine("1 - show task1");
                Console.WriteLine("2 - show task2");
                Console.WriteLine("\"exit\" - exit");
                string input = Console.ReadLine();

                if (input == "1")
                {
                    Task1();
                }
                if (input == "2")
                {
                    Task2();
                }
                if (input.ToLower() == "exit")
                {
                    isExit = true;
                }
            }
            
        }

        static void Task1()
        {            
            char firstLetter = '\0';

            do
            {
                Console.WriteLine("Enter a string.");
                bool isFailed = false;
                input = Console.ReadLine();
                try
                {
                    firstLetter = input.GetFirstChar();
                }
                catch (ArgumentNullException)
                {
                    Console.WriteLine("Error: you inputted empty string.");
                    isFailed = true;
                }
                finally
                {
                    if (!isFailed)
                    {
                        Console.WriteLine(firstLetter);
                    }
                    else
                    {
                        isExit = true;
                    }
                }
            }
            while (!isExit);
        }

        static void Task2()
        {
            do
            {
                Console.WriteLine("Enter a string.");
                input = Console.ReadLine();
                int integer = 0;
                bool isFailed = false;
                try
                {
                    integer = MyConverter.Utoi(input);
                }
                catch (ArgumentNullException)
                {
                    Console.WriteLine("Error: you inputted empty string.");
                    isFailed = true;
                }
                catch (OverflowException)
                {
                    Console.WriteLine("Error: too big value.");
                    isFailed = true;
                }
                catch (UtoiConvertException e)
                {
                    DisplayError(e.TokenIndex);
                    if (e.InnerException != null)
                    {
                        Console.WriteLine(e.InnerException.Message);
                    }
                    isFailed = true;
                }

                finally
                {
                    if (!isFailed)
                    {
                        Console.WriteLine(integer);
                    }
                    else
                    {
                        isExit = true;
                    }
                }
            }
            while (!isExit);
        }

        static void DisplayError(int errorIndex)
        {
            Console.Write(input.Substring(0, errorIndex));
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(input.Substring(errorIndex, 1));
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(input.Substring(errorIndex + 1, input.Length - errorIndex - 1));
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        static bool isExit = false;
        static string input = string.Empty;
    }
}
