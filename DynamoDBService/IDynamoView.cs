using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamoDBService
{
    public interface IDynamoView
    {
        DisplayData DisplayView { get; set; }

        void Display(string display);
    }
}
