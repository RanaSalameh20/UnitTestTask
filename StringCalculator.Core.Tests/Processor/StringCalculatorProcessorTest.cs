using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using StringCalculator;

namespace StringCalculator.Core.Processor
{
    public class StringCalculatorProcessorTest
    {
        private StringCalculatorProcessor calculator;

        [Theory]
        [InlineData("", 0)]
        [InlineData("1", 1)]
        [InlineData("1,2", 3)]
        [InlineData("1,2,5,2", 10)]
        [InlineData("4,4,4,4,4,4",24)]
        [InlineData("1\n2,3", 6)]
        [InlineData("//;\n1;2" , 3)]

        public void Add_ValidInputStringOfNumbers_ReturnsCorrectSum(String numbers, int expectedSum)
        {

            //Arange
            calculator = new StringCalculatorProcessor();

            //Act
            var actualSum = calculator.Add(numbers);

            //Assert
            Assert.Equal(expectedSum, actualSum);
        }

        [Theory]
        [InlineData("1\n2,\n")]
        [InlineData("\n,1\n2,\n")]
        [InlineData("\n,1\n\n2,\n")]
        [InlineData("\n,1\n\n2,\n\n")]
        public void Add_InvalidInputStringOfNumbers_ThrowsFormatException(String numbers)
        {

            //Arange
            calculator = new StringCalculatorProcessor();


            //Act & Assert
            Assert.Throws<System.FormatException>(() => calculator.Add(numbers));

        }



    }
}
