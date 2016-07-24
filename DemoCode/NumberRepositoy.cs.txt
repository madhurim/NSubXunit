using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoCode
{
    public class NumberRepository : IRepository
    {
        IDatabase _db;
        public NumberRepository(IDatabase db)
        {
            _db = db;
        }

        public int[] GetNumbers()
        {
            return new int[] { 1, 2, 3 };
        }
        public int[] GetNumbersFromDatabase(string type)
        {
            if (_db.Connect(type))
            { return new int[] { 1, 2, 3 }; }
            else 
                throw new Exception("Could not connect to the numbers database");
        }
    }
}
