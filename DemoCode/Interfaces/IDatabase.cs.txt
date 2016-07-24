using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoCode
{
    public interface IDatabase
    {
        bool Connect(string type);
    }
}
