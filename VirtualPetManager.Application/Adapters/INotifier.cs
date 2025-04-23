using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualPetManager.Application.Adapters
{
    public interface INotifier
    {
        void Send(string message);
    }
}
