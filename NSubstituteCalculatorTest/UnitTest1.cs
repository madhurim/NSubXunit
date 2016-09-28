using System;
using NSubstituteCalculator;
using NSubstitute;
using System.Text.RegularExpressions;
using Xunit;

namespace NSubstituteCalculatorTest
{
    public class UnitTest1
    {
        [Fact]
        public void TestMethod1()
        {
            // Verifying the add functionality using assert
            var calculator = Substitute.For<Calculator>();
            int sum = calculator.Add(1, 2);
            var result = false;
            Assert.Equal("Testing Calculator", "Testing Calculator");
            if(sum == 3)
            {
                result = true;
            }
            Assert.Equal(result, true);
        }

        [Fact]
        public void TestMethod2()
        {
            // For checking whether variable is integer or alphabet before doing calculation as validationo part
            var calculator = Substitute.For<Calculator>();
            var number1 = "5";
            var number2 = "a";
            bool result1 = Regex.IsMatch(number1, @"^\d+$");
            bool result2 = Regex.IsMatch(number2, @"^\d+$");
            Assert.Equal(result1, true);
            Assert.Equal(result2, false);        // if true than return false as the var is not int
        }

        [Fact]
        public void TestMethod3()
        {
            // Writing the final result to a file
            // If path provided is correct -> it will write otherwise not
            var calculator = Substitute.For<Calculator>();
            var sum = calculator.Add(1, 2);
            var result = true;
            if (sum == 3)
            {
                result = true;
            }
            string[] finalText = { Convert.ToString(result), Convert.ToString(sum) };
            try
            {
                System.IO.File.WriteAllLines(@"C:\Users\ntrivedi\Desktop\", finalText);
            }
            catch
            {
                result = false;
            }
            Assert.Equal(result, false);
        }

    }
}
