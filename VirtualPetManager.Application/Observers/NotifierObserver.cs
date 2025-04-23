using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualPetManager.Domain;

namespace VirtualPetManager.Application.Observers
{
    public class NotifierObserver : IPetObserver
    {
        public void OnMoodChanged(Pet pet, string oldMood, string newMood)
        {
            Console.WriteLine($"[NOTIFICACIÓN] {pet.Name} ahora está {newMood}.");
        }
    }
}
