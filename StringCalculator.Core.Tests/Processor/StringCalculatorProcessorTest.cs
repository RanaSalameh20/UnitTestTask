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
        //private readonly calculator = new StringCalculatorProcessor();

        [Theory]
        [InlineData("", 0)]
        [InlineData("1", 1)]
        [InlineData("1,2", 3)]
        public void Add_ValidInputStringOfNumbers_ReturnsCorrectSum(String numbers, int expectedSum)
        {

            //Arange
            var calculator = new StringCalculatorProcessor();

            //Act
            var actualSum = calculator.Add(numbers);

            //Assert
            Assert.Equal(expectedSum, actualSum);
        }

        [Theory]
        [InlineData("1,2,3")]
        [InlineData("1,2,3,4,5")]
        public void Add_InvalidInputString_ThrowsArgumentException(string numbers)
        {
            //Arange
            var calculator = new StringCalculatorProcessor();

            //Assert
            Assert.Throws<System.ArgumentException>(() => { calculator.Add(numbers); });

        }
    }
}
