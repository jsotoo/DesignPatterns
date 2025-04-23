using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualPetManager.Domain;

namespace VirtualPetManager.Application.Factories
{
    public abstract class PetCreator
    {
        public abstract Pet CreatePet(string name, int age);
    }
}
