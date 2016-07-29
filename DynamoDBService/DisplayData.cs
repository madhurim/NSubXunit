using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamoDBService
{
    public class DisplayData
    {
        string _DisplayView = String.Empty;
        bool _Editable = false;

        public string DisplayView
        {
            get { return _DisplayView; }
            set { _DisplayView = value; }
        }
        public bool Editable
        {
            get { return _Editable; }
            set { _Editable = value; }

        }
    }
}
