using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NSubstituteCalculator
{
    public class CalculatorMock : ICalculatorMock
    {
        public int Multiply(int a, int b)
        {
            return (a * b);
        }
    }
}