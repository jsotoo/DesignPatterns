using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualPetManager.Domain;

namespace VirtualPetManager.Application.Decorators
{
    public class BasicPetComponent : PetComponent
    {
        private readonly Pet _pet;

        public BasicPetComponent(Pet pet)
        {
            _pet = pet;
        }
        public override string Describe()
        {
            return $"{_pet.Name}, un {_pet.Type} de {_pet.Age} años. Estado: {_pet.Mood}";
        }
    }
}
