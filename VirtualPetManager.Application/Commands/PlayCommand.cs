using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualPetManager.Domain;

namespace VirtualPetManager.Application.Commands
{
    public class PlayCommand : IPetCommand
    {
        private readonly Pet _pet;

        public PlayCommand(Pet pet)
        {
            _pet = pet;
        }

        public void Execute()
        {
            _pet.Play();
        }
    }
}
