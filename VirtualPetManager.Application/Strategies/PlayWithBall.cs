using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualPetManager.Application.Utils;
using VirtualPetManager.Domain;

namespace VirtualPetManager.Application.Strategies
{
    public class PlayWithBall : IPlayStrategy
    {
        public void Play(Pet pet)
        {
            pet.Mood = PetMood.Excited;
            ActionLogger.Instance.Log($"{pet.Name} jugó con una pelota y ahora está emocionado.");
        }
    }
}
