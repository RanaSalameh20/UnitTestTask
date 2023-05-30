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

            int sum = 0;
            foreach (var numberString in numbersArray)
            {
                sum += int.Parse(numberString);
            }
            return sum;

        }
    }
}