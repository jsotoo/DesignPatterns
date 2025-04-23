using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualPetManager.Application.Utils;
using VirtualPetManager.Domain;

namespace VirtualPetManager.Application.Observers
{
    public class LoggerObserver : IPetObserver
    {
        public void OnMoodChanged(Pet pet, string oldMood, string newMood)
        {
            ActionLogger.Instance.Log($"Mood de {pet.Name} cambió de {oldMood} a {newMood}");
        }
    }
}
