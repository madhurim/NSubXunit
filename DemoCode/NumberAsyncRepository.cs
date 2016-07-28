using System;
using System.Threading.Tasks;

namespace DemoCode
{
    public class NumberAsyncRepository
    {
        IDatabase _db;
        public NumberAsyncRepository(IDatabase db)
        {
            _db = db;
        }

        public async Task<int[]> GetNumbers()
        {
            await Task.Delay(100);
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
