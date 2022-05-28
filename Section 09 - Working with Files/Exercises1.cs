using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Section09Namespace
{
    internal class Exercises1
    {
        static void Main(string[] args)
        {
            // Exercise1();
            Exercise2();
        }

        public static void Exercise1()
        {
            string testFilePath;

            try
            {
                testFilePath = GetTestFilePath();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadKey();
                return;
            }

            int numberOfWords = GetNumberOfWordsFromFile(testFilePath);

            Console.WriteLine("Number of words: " + numberOfWords);

            Console.ReadKey();
        }

        private static string GetTestFilePath()
        {
            string currentDirectory = Directory.GetCurrentDirectory();

            DirectoryInfo directoryInfo = new DirectoryInfo(currentDirectory);

            DirectoryInfo codeDirectory = directoryInfo.Parent.Parent;

            FileInfo[] files = codeDirectory.GetFiles("testFileRead.txt");

            if (files.Length == 0)
            {
                throw (new Exception("Doesn't exist"));
            }

            FileInfo testFileRead = files[0];

            string filePath = testFileRead.FullName;

            return filePath;
        }

        private static int GetNumberOfWordsFromFile(string filePath)
        {
            if (!File.Exists(filePath))
            {
                return 0;
            }

            string fileText = File.ReadAllText(filePath).Trim();

            if (fileText == "") return 0;

            string[] words = fileText.Split(' ');

            return words.Length;
        }

        public static void Exercise2()
        {
            string testFilePath;
            string longestWord;

            try
            {
                testFilePath = GetTestFilePath();
                longestWord = GetLongestWordFromFile(testFilePath);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadKey();
                return;
            }

            Console.WriteLine("Longest word: " + longestWord);

            Console.ReadKey();
        }

        private static string GetLongestWordFromFile(string filePath)
        {
            if (!File.Exists(filePath))
            {
                throw (new Exception("The file doesn't exist"));
            }

            string fileText = File.ReadAllText(filePath).Trim();

            if (fileText == "")
            {
                throw (new Exception("There are no words in the file"));
            }

            string[] words = fileText.Split(' ');

            if (words.Length == 0) 
            {
                throw (new Exception("There are no words in the file"));
            }

            string longestWord = words[0];

            for(int i = 1; i < words.Length; i++)
            {
                string word = words[i];

                if (word.Length > longestWord.Length)
                {
                    longestWord = word;
                }
            }

            return longestWord;
        }
    }
}
