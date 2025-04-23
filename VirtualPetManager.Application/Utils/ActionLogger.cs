using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualPetManager.Application.Utils
{
    public class ActionLogger
    {
        private static readonly ActionLogger _instance = new();
        private readonly List<string> _logs = new();

        private ActionLogger() { }

        public static ActionLogger Instance => _instance;

        public void Log(string message)
        {
            var log = $"[{DateTime.Now:HH:mm:ss}] {message}";
            _logs.Add(log);
            Console.WriteLine(log); 
        }

        public IEnumerable<string> GetLogs() => _logs.AsReadOnly();
    }
}
