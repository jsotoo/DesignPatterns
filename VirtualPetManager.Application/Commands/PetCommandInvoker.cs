using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualPetManager.Application.Commands
{
    public class PetCommandInvoker
    {
        private readonly List<IPetCommand> _commands = new();

        public void AddCommand(IPetCommand command)
        {
            _commands.Add(command);
        }

        public void ExecuteCommands()
        {
            foreach (var command in _commands)
            {
                command.Execute();
            }
            _commands.Clear();
        }
    }
}
