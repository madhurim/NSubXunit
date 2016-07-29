using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamoDBService
{
    public class DynamoView : IDynamoView
    {
        DisplayData _DisplayView;

        public DisplayData DisplayView
        {
            get { return _DisplayView;  }
            set { _DisplayView = value; }
        }

        public void Display(string val)
        {
           // if (DisplayView.Editable)
           //     val = val + " This is editable data ";    
            Console.WriteLine(val);
        }
    }
}
