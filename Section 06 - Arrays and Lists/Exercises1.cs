using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Section06Namespace
{
    internal class Exercises1
    {
        static void Main(string[] args)
        {
            // Exercise1();
            // Exercise2();
            // Exercise3();
            // Exercise4();
            Exercise5();
        }

        public static void Exercise1()
        {
            List<string> friends = new List<string>();
            
            while(true)
            {
                Console.WriteLine("Please enter a Friend's name:");

                string input = Console.ReadLine();

                if (input == "") break;
                
                friends.Add(input);
            }

            PrintFriends(friends);
            Console.ReadKey();
        }

        private static void PrintFriends(List<string> friends)
        {
            if (friends.Count() == 0) return;

            string printString = "";

            if (friends.Count() == 1) 
            {
                printString = friends[0] + " likes your post.";
            }
            else if (friends.Count() == 2)
            {
                printString = friends[0] + " and " + friends[1] + " like your post.";
            }
            else
            {
                printString = friends[0] + ", " + friends[1] + " and " + (friends.Count() - 2) + 
                    " others like your post.";
            }

            Console.WriteLine(printString);
        }

        public static void Exercise2()
        {
            Console.WriteLine("Please enter your name:");
            string input = Console.ReadLine();

            char[] chars = input.ToCharArray();

            Array.Reverse(chars);

            string reversedInput = new string(chars);

            Console.WriteLine(reversedInput);
            Console.ReadKey();
        }

        public static void Exercise3()
        {
            List<double> enteredNumbers = new List<double>();
            int i = 1;
            while (i <= 5)
            {
                Console.WriteLine("Please enter a number:");
                string input = Console.ReadLine();

                double num;

                bool isDouble = Double.TryParse(input, out num);

                if (!isDouble)
                {
                    Console.WriteLine("That was not a valid number");
                    continue;
                }
                
                if (enteredNumbers.Contains(num))
                {
                    Console.WriteLine("This number has already been entered, please enter a unique one");
                    continue;
                }

                enteredNumbers.Add(num);
                i++;
            }

            enteredNumbers.Sort();

            Console.WriteLine(string.Join(",", enteredNumbers));
            Console.ReadKey();
        }

        public static void Exercise4()
        {
            List<double> uniqueEnteredNumbers = new List<double>();
            while (true)
            {
                Console.WriteLine("Please enter a number or type Quit:");
                string input = Console.ReadLine();

                if (input == "Quit") break;
                
                double num;

                bool isDouble = Double.TryParse(input, out num);

                if (!isDouble)
                {
                    Console.WriteLine("That was not a valid number or Quit");
                    continue;
                }

                if (!uniqueEnteredNumbers.Contains(num))
                {
                    uniqueEnteredNumbers.Add(num);
                }
            }

            Console.WriteLine(string.Join(",", uniqueEnteredNumbers));
            Console.ReadKey();
        }

        public static void Exercise5()
        {
            while (true)
            {
                Console.WriteLine("Please enter a comma separated list of numbers:");
                string input = Console.ReadLine();
                string[] elements = input.Split(',');

                List<double> doubles = GetDoubles(elements);

                if (doubles.Count() < 5)
                {
                    Console.WriteLine("Invalid List, please try again");
                    continue;
                }

                doubles.Sort();

                double[] smallest3Doubles = new double[3];

                Array.Copy(doubles.ToArray(), smallest3Doubles, smallest3Doubles.Length);

                Console.WriteLine(string.Join(",", smallest3Doubles));
                Console.ReadKey();
                return;
            }
        }

        private static List<double> GetDoubles(string[] elements)
        {
            List<double> res = new List<double>();
            
            foreach (string element in elements)
            {
                double val;

                bool isDouble = Double.TryParse(element, out val);

                if (!isDouble) continue;

                res.Add(val);
            }

            return res;
        }

    }
}
