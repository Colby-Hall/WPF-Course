using CSharpPractice.Classes;
using CSharpPractice.Interfaces;
using System;

namespace CSharpPractice
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            double[] numbs = new double[] { 1, 2, 3, 4, 55, 8 };
            var result = SimpleMath.Add(numbs);
            Console.WriteLine(result);

            BankAccount bankAccount = new BankAccount(1000);
            bankAccount.AddToBalance(100);
            Console.WriteLine(bankAccount.Balance);

            // inherets BankAccount class
            ChildBankAccount childBankAccount = new ChildBankAccount();
            childBankAccount.AddToBalance(25);
            Console.WriteLine(childBankAccount.Balance);

            Console.ReadLine();
            */

            BankAccount bankAccount = new BankAccount(1000);
            bankAccount.AddToBalance(100);

            SimpleMath simpleMath = new SimpleMath();

            Console.WriteLine(Information(bankAccount));
            Console.WriteLine(Information(simpleMath));

            Console.ReadLine();


        }

        // don't care about type of object passed into Information, only that it implements IInformation
        private static string Information(IInformation info)
        {
            return info.GetInformation();
        }
    }

    class SimpleMath : IInformation
    {
        public static double Add(double firstNumber, double secondNumber)
        {
            return firstNumber + secondNumber;
        }

        // method overloading
        public static double Add(double[] numbers)
        {
            double result = 0;
            foreach(double d in numbers)
            {
                result += d;
            }
            return result;
        }

        // implementing IInforation interface
        public string GetInformation()
        {
            return "Class that solves simple math.";
        }
    }
}

/*
 * Console example code
 * Console.WriteLine("Hello");
 * Console.ReadLine();
 * 
 * int numberOne = 23;
 * Console.WriteLine(numberOne);
 * var message = Console.ReadLine();
 * Console.WriteLine(message);
 * Console.ReadLine();
 * 
 * 
 * 
 * 
 */
