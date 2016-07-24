using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoCode.Interfaces
{
    public interface IAsyncRepository
    {
        Task<int[]> GetNumbers();
        int[] GetNumbersFromDatabase(string type);
    }
}
