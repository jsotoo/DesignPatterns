using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualPetManager.Domain;

namespace VirtualPetManager.Application.Factories
{
    public class CatCreator : PetCreator
    {
        public override Pet CreatePet(string name, int age)
        {
            return new Pet
            {
                Name = name,
                Age = age,
                Type = "Gato",
                Mood = PetMood.Bored
            };
        }
    }
}
