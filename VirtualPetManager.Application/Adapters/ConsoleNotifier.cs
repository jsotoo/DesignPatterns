using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualPetManager.Application.Adapters
{
    public class ConsoleNotifier : INotifier
    {
        public void Send(string message)
        {
            Console.WriteLine($"[NOTIFICACIÓN]: {message}");
        }
    }
}
