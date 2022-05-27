using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Section08Namespace
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
            Console.WriteLine("Please enter a hyphen (-) separated list of numbers:");
            
            List<int> ints;

            try
            {
                string[] elements = GetHyphenSeparatedListFromUser();

                ints = GetInts(elements);
            }
            catch (Exception)
            {
                Console.WriteLine("Please enter a hyphen (-) separated list of numbers");
                Console.ReadKey();
                return;
            }

            if (IsAscending(ints) || IsDescending(ints))
            {
                Console.WriteLine("Consecutive");
            }
            else
            {
                Console.WriteLine("Not Consecutive");
            }

            Console.ReadKey();
        }

        private static string[] GetHyphenSeparatedListFromUser()
        {
            string input = Console.ReadLine();

            if (input == null || input.Trim() == "")
            {
                throw (new Exception("Invalid input"));
            }

            return input.Split('-');
        }

        private static List<int> GetInts(string[] elements)
        {
            List<int> res = new List<int>();

            foreach (string element in elements)
            {
                int val;

                bool isInt = int.TryParse(element, out val);

                if (!isInt) throw (new Exception("Element wasn't an integer"));  

                res.Add(val);
            }

            return res;
        }

        private static bool IsAscending(List<int> ints)
        {
            int previousElem = ints[0];

            for (int i = 1; i < ints.Count; i++)
            {
                int elem = ints[i];
                
                if (elem != (previousElem + 1)) return false;
                
                previousElem = elem;
            }
            
            return true;
        }

        private static bool IsDescending(List<int> ints)
        {
            int previousElem = ints[0];

            for (int i = 1; i < ints.Count; i++)
            {
                int elem = ints[i];

                if (elem != (previousElem - 1)) return false;

                previousElem = elem;
            }

            return true;
        }

        public static void Exercise2()
        {
            Console.WriteLine("Please enter a hyphen (-) separated list of numbers:");

            List<int> ints;

            try
            {
                string[] elements = GetHyphenSeparatedListFromUser();

                ints = GetInts(elements);
            }
            catch (Exception)
            {
                Console.WriteLine("Please enter a hyphen (-) separated list of numbers");
                Console.ReadKey();
                return;
            }

            if (DoesListHaveDuplicates(ints))
            {
                Console.WriteLine("Duplicate");
            }
            else
            {
                Console.WriteLine("No Duplicates");
            }

            Console.ReadKey();
        }

        private static bool DoesListHaveDuplicates(List<int> ints)
        {
            for (int i = 0; i < ints.Count; i++)
            {
                int elem = ints[i]; 

                for (int j = i + 1; j < ints.Count; j++)
                {
                    int otherElem = ints[j];

                    if(elem == otherElem) return true;
                }
            }
            
            return false;
        }

        public static void Exercise3()
        {
            Console.WriteLine("Enter a time in the 24-hour time format HH:mm:");
            string input = Console.ReadLine();

            if (input == null || input == "")
            {
                InvalidTime();
                return;
            }

            string[] timeComponents = input.Split(':');

            if (timeComponents.Length != 2)
            {
                InvalidTime();
                return;
            }

            if (IsHour(timeComponents[0]) && IsMinutes(timeComponents[1]))
            {
                Console.WriteLine("Ok");
                Console.ReadKey();
            }
            else
            {
                InvalidTime();
            }
        }

        private static bool IsHour(string hour)
        {
            int val;

            bool isInt = int.TryParse(hour, out val);

            if (!isInt) return false;

            return (val >= 0 && val <= 24);
        }

        private static bool IsMinutes(string minutes)
        {
            int val;

            bool isInt = int.TryParse(minutes, out val);

            if (!isInt) return false;

            return (val >= 0 && val <= 60);
        }

        private static void InvalidTime()
        {
            Console.WriteLine("Invalid Time");
            Console.ReadKey();
        }

        public static void Exercise4()
        {
            Console.WriteLine("Enter a sentance to convert to Pascal Case:");
            string input = Console.ReadLine();

            if (input == null || input == "")
            {
                Console.ReadKey();
                return;
            }

            string[] words = input.Trim().ToLower().Split(' ');

            List<string> ret = new List<string>();

            foreach (string word in words)
            {
                if (word.Trim() == "") continue;
                
                ret.Add(word[0].ToString().ToUpper() + word.Substring(1));
            }

            string pascalCase = string.Join("", ret.ToArray());

            Console.WriteLine(pascalCase);
            Console.ReadKey();
        }

        public static void Exercise5()
        {
            Console.WriteLine("Enter a sentance to count the number of vowels:");
            string input = Console.ReadLine();

            char[] vowels = new char[5] { 'a', 'e', 'i', 'o', 'u' };

            int numberOfVowels = 0;

            foreach(char character in input)
            {
                if (vowels.Contains(character)) numberOfVowels++;
            }

            Console.WriteLine(numberOfVowels);
            Console.ReadKey();
        }
    }
}
