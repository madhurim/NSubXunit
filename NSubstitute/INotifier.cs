using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSubstitute.Code
{
    public interface INotifier
    {
        int Notify(User user);
    }
}
