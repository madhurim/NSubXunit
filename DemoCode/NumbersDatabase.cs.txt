using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoCode
{
    public class NumbersDatabase : IDatabase
    {
        public bool Connect(string type)
        {
            if ( type == "numbers")
            { return true;  }
            else return false;
        }
    }
}
