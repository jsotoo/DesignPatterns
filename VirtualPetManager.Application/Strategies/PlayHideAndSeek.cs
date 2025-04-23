using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualPetManager.Application.Utils;
using VirtualPetManager.Domain;

namespace VirtualPetManager.Application.Strategies
{
    public class PlayHideAndSeek : IPlayStrategy
    {
        public void Play(Pet pet)
        {
            pet.Mood = PetMood.Happy;
            ActionLogger.Instance.Log($"{pet.Name} jugó a las escondidas y está feliz.");
        }
    }
}
