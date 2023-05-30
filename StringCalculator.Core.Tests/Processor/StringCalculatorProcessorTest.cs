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

        [Theory]
        [InlineData("", 0)]
        [InlineData("1", 1)]
        [InlineData("1,2", 3)]
        [InlineData("1,2,5,2", 10)]
        [InlineData("4,4,4,4,4,4",24)]

        public void Add_ValidInputStringOfNumbers_ReturnsCorrectSum(String numbers, int expectedSum)
        {

            //Arange
            var calculator = new StringCalculatorProcessor();

            //Act
            var actualSum = calculator.Add(numbers);

            //Assert
            Assert.Equal(expectedSum, actualSum);
        }

    }
}
