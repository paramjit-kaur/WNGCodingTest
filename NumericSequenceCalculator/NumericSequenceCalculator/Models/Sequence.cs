using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NumericSequenceCalculator.Models
{
    public class Sequence : ISequence
    {
        /// <summary>
        /// Identify if the number sign(positive/negative).
        /// </summary>
        /// <param name="number"></param>
        /// <returns>-1 if negative, 0 if zero, 1 if positive number</returns>
        public int IdentifyNumber(int number)
        {
            return Math.Sign(number);
        }

        /// <summary>
        /// Generate series for all the numbers.
        /// </summary>
        /// <param name="number"></param>
        /// <returns>List of all numbers</returns>
        public List<string> GetAllNumbers(int number)
        {
            List<string> AllNumberSequence = new List<string>();
            string multiplesText = string.Empty;
            if (IdentifyNumber(number) == 1)
            {
                for (int i = 0; i <= number; i++)
                {
                    if (i != 0)             //check for not to replace value for 0.
                        multiplesText = MultiplesOfThreeAndFive(i);//replace number value according to mulltiples.

                    if (!string.IsNullOrEmpty(multiplesText))
                        AllNumberSequence.Add(multiplesText); 
                    else
                        AllNumberSequence.Add(i.ToString());
                }
            }
            return AllNumberSequence;
        }

        /// <summary>
        /// Identifies multiples of three and five.
        /// </summary>
        /// <param name="number"></param>
        /// <returns>string</returns>
        public string MultiplesOfThreeAndFive(int number)
        {
            string multiplesText = string.Empty;
            if (number % 3 == 0)//check for multiple of 3
                multiplesText = "C";
            else if (number % 5 == 0)//check for multiple of 5
                multiplesText = "E";
            if ((number % 3 == 0) && (number % 5 == 0))//check for multiple of 3 and 5
                multiplesText = "Z";
            return multiplesText;
        }

        /// <summary>
        /// Generates sequence for Even numbers.
        /// </summary>
        /// <param name="number"></param>
        /// <returns>List of even numbers</returns>
        public List<string> GetEvenNumbers(int number)
        {
            List<string> EvenNumberSequence = new List<string>();

            if (IdentifyNumber(number) == 1)
            {
                for (int i = 1; i <= number; i++)
                {
                    if (i % 2 == 0)//check for even numbers
                    {
                        EvenNumberSequence.Add(i.ToString());
                    }
                }
            }
            return EvenNumberSequence;
        }

        /// <summary>
        /// Generates sequence of odd numbers.
        /// </summary>
        /// <param name="number"></param>
        /// <returns>List of odd numbers</returns>
        public List<string> GetOddNumbers(int number)
        {
            List<string> OddNumberSequence = new List<string>();

            if (IdentifyNumber(number) == 1)
            {
                for (int i = 1; i <= number; i++)
                {
                    if (i % 2 != 0)//check for odd numbers
                    {
                        OddNumberSequence.Add(i.ToString());
                    }
                }
            }
            return OddNumberSequence;
        }

        /// <summary>
        /// Generates Fibonacci series
        /// </summary>
        /// <param name="number"></param>
        /// <returns>List of fibonacci series</returns>
        public List<string> GetFibonacciNumbers(int number)
        {
            List<string> FibonacciNumberSequence = new List<string>();

            if (IdentifyNumber(number) == 1)
            {
                int a = 0, b = 1, c = 0;

                FibonacciNumberSequence.Add(a.ToString());
                FibonacciNumberSequence.Add(b.ToString());

                for (int i = 2; i < number; i++)
                {
                    c = a + b;

                    if (c <= number)
                    {
                        FibonacciNumberSequence.Add(c.ToString());
                        a = b;
                        b = c;
                    }
                    else
                        break;

                }
            }

            return FibonacciNumberSequence;
        }
    }

    public interface ISequence
    {
        int IdentifyNumber(int number);
        List<string> GetAllNumbers(int number);
        List<string> GetEvenNumbers(int number);
        List<string> GetOddNumbers(int number);
        List<string> GetFibonacciNumbers(int number);
        string MultiplesOfThreeAndFive(int number);
    }
}