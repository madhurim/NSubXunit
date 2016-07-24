using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoCode
{
    public class CalculatorView : IView
    {
        int _Sum = 0;
        public int Sum { 
                  get { return _Sum; } 
                  set { _Sum = value; }  
                }

        public void DisplaySum(int addition)
        {
            if (_Sum > 0)
                Console.WriteLine(_Sum);
            
        }
    }
}
