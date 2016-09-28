using NSubstituteCalculator;
using Xunit;

namespace NSubstituteCalculatorTest
{
    public class UnitTest2
    {
        [Fact]
        public void TestMethod4()
        {
            // Verifying the add functionality using mock assert
            // Creating a fake
            CalculatorMock mockCalc = new CalculatorMock();
            int ans = mockCalc.Multiply(1, 2);
            var result = false;
            if (ans == 2)
            {
                result = true;
            }
            // Using fake object's value as mock object
            Assert.Equal(result, true);
        }
    }
}
