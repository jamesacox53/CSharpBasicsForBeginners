using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Section05Namespace
{
    internal class Exercises1
    {
        public static void Exercise1()
        {
            Console.WriteLine("Please enter a number between 1 and 10");
            string input = Console.ReadLine();

            int value;

            bool isNumber = Int32.TryParse(input, out value);

            if(!isNumber)
            {
                Console.WriteLine("Invalid");
            }
            else if (value >= 1 && value <= 10)
            {
                Console.WriteLine("Valid");
            }
            else 
            {
                Console.WriteLine("Invalid");
            }

            Console.ReadKey();
        }

        public static void Exercise2()
        {
            double number1;
            double number2;

            try
            {
                number1 = AskUserForNumber();
                number2 = AskUserForNumber();
            } 
            catch (Exception ex)
            {
                HandleNumberInputError(ex);
                return;
            }

            PrintBiggerNumber(number1, number2);
            
            Console.ReadKey();
        }

        private static double AskUserForNumber()
        {
            Console.WriteLine("Please enter a number");

            return GetNumberAsInput();
        }

        private static double GetNumberAsInput()
        {
            string input = Console.ReadLine();

            double value;

            bool isNumber = Double.TryParse(input, out value);

            if (!isNumber)
            {
                throw new Exception("User input wasn't a valid number");
            }

            return value;
        }

        private static void PrintBiggerNumber(double number1, double number2)
        {
            if (number1 > number2)
            {
                Console.WriteLine(number1);
            }
            else
            {
                Console.WriteLine(number2);
            }
        }

        private static void HandleNumberInputError(Exception ex)
        {
            Console.WriteLine(ex.Message);
            Console.ReadKey();
        }

        public static void Exercise3()
        {
            double width;
            double height;

            try
            {
                width = AskUserForWidth();
                height = AskUserForHeight();
            }
            catch (Exception ex)
            {
                HandleNumberInputError(ex);
                return;
            }

            PrintImageType(width, height);

            Console.ReadKey();
        }

        private static double AskUserForWidth()
        {
            Console.WriteLine("Please enter the width of the image");

            return GetNumberAsInput();
        }

        private static double AskUserForHeight()
        {
            Console.WriteLine("Please enter the height of the image");

            return GetNumberAsInput();
        }

        private static void PrintImageType(double width, double height)
        {
            if (width > height)
            {
                Console.WriteLine("The image is landscape");
            }
            else
            {
                Console.WriteLine("The image is portrait");
            }
        }

        public static void Exercise4()
        {
            double speedLimit;
            double speedOfCar;

            try
            {
                speedLimit = AskUserForSpeedLimit();
                speedOfCar = AskUserForSpeedOfCar();
            }
            catch (Exception ex)
            {
                HandleNumberInputError(ex);
                return;
            }

            PrintSpeedMessage(speedLimit, speedOfCar);

            Console.ReadKey();
        }

        private static double AskUserForSpeedLimit()
        {
            Console.WriteLine("Please enter the speed limit");

            return GetNumberAsInput();
        }

        private static double AskUserForSpeedOfCar()
        {
            Console.WriteLine("Please enter the speed of the car");

            return GetNumberAsInput();
        }

        private static void PrintSpeedMessage(double speedLimit, double speedOfCar)
        {
            if (speedOfCar <= speedLimit)
            {
                Console.WriteLine("Ok");
                return;
            }

            double amountOverSpeedLimit = speedOfCar - speedLimit;

            int numberOfDemeritPoints = (int) (amountOverSpeedLimit / 5);
            
            if (numberOfDemeritPoints >= 12)
            {
                Console.WriteLine("License suspended");
            }
            else
            {
                Console.WriteLine(GetStringForDemeritPoints(numberOfDemeritPoints));
            }
        }

        private static string GetStringForDemeritPoints(int numberOfDemeritPoints)
        {
            bool isPlural = numberOfDemeritPoints > 1;
            
            return $"Your License has been given {numberOfDemeritPoints} Demerit {(isPlural ? "points" : "point")}";
        }
    }
}
