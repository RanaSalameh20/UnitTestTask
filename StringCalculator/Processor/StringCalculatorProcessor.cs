using System;

namespace StringCalculator.Core.Processor
{
    public  class StringCalculatorProcessor
    {
        public StringCalculatorProcessor()
        {
        }

        public  int Add(string numbers)
        {
            if (numbers.Equals(""))
                return 0;

            string[] numbersArray = numbers.Split(',');

            if (numbersArray.Length > 2)
                throw new System.ArgumentException("Invalid input: More than 2 numbers are not allowed.");

            int sum = 0;
            foreach (var numberString in numbersArray)
            {
                sum += int.Parse(numberString);
            }
            return sum;

        }
    }
}