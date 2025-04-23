using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualPetManager.Domain;

namespace VirtualPetManager.Application.Observers
{
    public class PetMoodSubject
    {
        private readonly List<IPetObserver> _observers = new();

        public void Attach(IPetObserver observer)
        {
            _observers.Add(observer);
        }

        public void Detach(IPetObserver observer)
        {
            _observers.Remove(observer);
        }

        public void Notify(Pet pet, string oldMood, string newMood)
        {
            foreach (var observer in _observers)
            {
                observer.OnMoodChanged(pet, oldMood, newMood);
            }
        }
    }
}
