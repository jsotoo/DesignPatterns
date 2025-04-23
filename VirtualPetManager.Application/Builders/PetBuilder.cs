using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualPetManager.Domain;

namespace VirtualPetManager.Application.Builders
{
    public class PetBuilder
    {
        private readonly Pet _pet = new();

        public PetBuilder SetName(string name)
        {
            _pet.Name = name;
            return this;
        }

        public PetBuilder SetType(string type)
        {
            _pet.Type = type;
            return this;
        }

        public PetBuilder SetAge(int age)
        {
            _pet.Age = age;
            return this;
        }

        public PetBuilder SetMood(PetMood mood)
        {
            _pet.Mood = mood;
            return this;
        }

        public Pet Build()
        {
            return _pet;
        }
    }
}
