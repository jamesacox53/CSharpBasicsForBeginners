using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Section05Namespace
{
    internal class Exercises2
    {
        public static void Exercise1()
        {
            int count = 0;
            
            for (int i = 1; i <= 100; i++)
            {
                if ((i % 3) == 0)
                {
                    count++;
                }
            }

            Console.WriteLine($"The amount of numbers from 1 to 100 that are divisible by 3: {count}");
            Console.ReadKey();
        }

        public static void Exercise2()
        {
            double sum = 0;

            while(true)
            {
                Console.WriteLine("Please enter a number or type ok to quit");
                string userInput = Console.ReadLine();

                if (userInput == "ok")
                {
                    Console.WriteLine(sum);
                    Console.ReadKey();
                    return;
                }

                double value;

                bool isNumber = Double.TryParse(userInput, out value);

                if (!isNumber)
                {
                    Console.WriteLine("User input wasn't a valid number");
                }
                else
                {
                    sum += value;
                }
            }
        }

        public static void Exercise3()
        {
            Console.WriteLine("Please enter a number to factorial");
            
            int factorialNumber;
            int factorialRes = 1;
            
            try
            {
                factorialNumber = GetFactorialNumberInput();
            }
            catch (Exception ex)
            {
                HandleNumberInputError(ex);
                return;
            }

            for (int i = 1; i <= factorialNumber; i++)
            {
                factorialRes *= i;
            }

            Console.WriteLine(factorialRes);
            Console.ReadKey();
        }

        private static int GetFactorialNumberInput()
        {
            int val = GetIntAsInput();

            if (val < 1)
            {
                throw new Exception("Can't have a factorial of a negative integer");
            }

            return val;
        }

        private static int GetIntAsInput()
        {
            string input = Console.ReadLine();

            int value;

            bool isNumber = Int32.TryParse(input, out value);

            if (!isNumber)
            {
                throw new Exception("User input wasn't a valid Integer");
            }

            return value;
        }

        private static void HandleNumberInputError(Exception ex)
        {
            Console.WriteLine(ex.Message);
            Console.ReadKey();
        }

        public static void Exercise4()
        {
            Random random = new Random();

            int randomNumber = random.Next(1, 11);

            for(int i = 1; i <= 4; i++)
            {
                Console.WriteLine("Please guess the random number between 1 - 10");
                
                string input = Console.ReadLine();

                if (input == randomNumber.ToString())
                {
                    Console.WriteLine("You win!");
                    Console.ReadKey();
                    return;
                }
                else
                {
                    Console.WriteLine("Wrong guess");
                }
            }

            Console.WriteLine("You lost");
            Console.ReadKey();
        }

        public static void Exercise5()
        {
            Console.WriteLine("Please enter a comma separated list of numbers:");
            string input = Console.ReadLine();
            string[] elements = input.Split(',');

            int[] ints = getInts(elements);

            if(ints.Length == 0)
            {
                Console.WriteLine("Please input a valid integer");
                Console.ReadKey();
                return;
            }

            DisplayMax(ints);
            Console.ReadKey();
        }

        private static int[] getInts(string[] elements)
        {
            List<int> res = new List<int>();

            foreach(string element in elements)
            {
                int val;

                bool isInt = Int32.TryParse(element, out val);

                if (!isInt) continue;

                res.Add(val);
            }

            return res.ToArray();
        }

        private static void DisplayMax(int[] ints)
        {
            int currMax = ints[0];

            for (int i = 1; i < ints.Length; i++)
            {
                int elem = ints[i];

                if (elem > currMax)
                {
                    currMax = elem;
                }
            }

            Console.WriteLine($"The Max element is: {currMax}");
        }
    }
}
