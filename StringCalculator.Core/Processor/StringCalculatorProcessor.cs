using System;
using System.Linq;

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

            var separator = FindSeparator(ref numbers);

            string[] numbersArray = numbers.Split(separator, '\n');

            CheckForNegativeNumbers(numbersArray);

            var sum = 0;
            foreach (var numberString in numbersArray)
            {
                var value = int.Parse(numberString);
                if (value <= 1000)
                {
                    sum += value;
                }
            }
            return sum;

        }

        private static void CheckForNegativeNumbers(string[] numbersArray)
        {
            var negativeNumbers = numbersArray.Where(c => int.Parse(c) < 0);
            if (negativeNumbers.Any())
            {
                throw new Exception("negatives not allowed: " + string.Join(",", negativeNumbers));
            }
        }

        private static char FindSeparator(ref string numbers)
        {
            var separator = ',';

            if (numbers.StartsWith("//"))
            {
                separator = numbers[2];
                numbers = numbers.Substring(numbers.IndexOf('\n') + 1);
            }

            return separator;
        }
    }
}