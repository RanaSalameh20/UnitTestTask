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

        public StringCalculatorProcessorTest()
        {
            calculator = new StringCalculatorProcessor();
        }

        [Theory]
        [InlineData("", 0)]
        [InlineData("1", 1)]
        [InlineData("1,2", 3)]
        [InlineData("1,2,5,2", 10)]
        [InlineData("4,4,4,4,4,4", 24)]
        [InlineData("1\n2,3", 6)]
        [InlineData("//;\n1;2", 3)]
        [InlineData("1,20000,5,2", 8)]

        public void Add_ValidInputStringOfNumbers_ReturnsCorrectSum(string numbers, int expectedSum)
        {

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
        public void Add_InvalidInputStringOfNumbers_ThrowsFormatException(string numbers)
        {

            //Act & Assert
            Assert.Throws<System.FormatException>(() => calculator.Add(numbers));

        }

        [Theory]
        [InlineData("1,4,-1" , "negatives not allowed: -1")]
        [InlineData("1,4,-1,-5", "negatives not allowed: -1,-5")]

        public void Add_WithNegativeNumbers_ThrowsExceptionWithNegatives(string numbers , string expectedMessage)
        {

            //Act 
            var actualMessage = Assert.Throws<Exception>(() => calculator.Add(numbers));

            //Assert
            Assert.Equal(expectedMessage, actualMessage.Message);

        }
    }
}
