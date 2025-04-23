using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualPetManager.Domain
{
    public enum PetMood
    {
        Happy,
        Sad,
        Hungry,
        Dirty,
        Bored,
        Tired,
        Excited,
        Clean
    }
    public class Pet
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty; 
        public int Age { get; set; }
        public PetMood Mood { get; set; } = PetMood.Happy;

        public void Feed() => Mood = PetMood.Happy;
        public void Clean() => Mood = PetMood.Happy;
        public void Play() => Mood = PetMood.Excited;
        public void Dirty() => Mood = PetMood.Dirty;


    }
}
