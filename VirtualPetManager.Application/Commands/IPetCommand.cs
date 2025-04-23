using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualPetManager.Application.Commands
{
    public interface IPetCommand
    {
        void Execute();
    }
}
