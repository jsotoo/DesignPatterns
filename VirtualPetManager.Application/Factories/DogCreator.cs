using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualPetManager.Domain;

namespace VirtualPetManager.Application.Factories
{
    internal class DogCreator : PetCreator
    {
        public override Pet CreatePet(string name, int age)
        {
            return new Pet
            {
                Name = name,
                Age = age,
                Type = "Perro",
                Mood = PetMood.Excited
            };
        }
    }
}
