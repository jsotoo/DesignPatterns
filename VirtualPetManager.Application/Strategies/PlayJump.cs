using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualPetManager.Application.Utils;
using VirtualPetManager.Domain;

namespace VirtualPetManager.Application.Strategies
{
    public class PlayJump : IPlayStrategy
    {
        public void Play(Pet pet)
        {
            pet.Mood = PetMood.Tired;
            ActionLogger.Instance.Log($"{pet.Name} estuvo saltando y terminó cansado.");
        }
    }
}
