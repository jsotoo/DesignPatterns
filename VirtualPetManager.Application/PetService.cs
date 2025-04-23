using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualPetManager.Application.Adapters;
using VirtualPetManager.Application.Builders;
using VirtualPetManager.Application.Commands;
using VirtualPetManager.Application.Decorators;
using VirtualPetManager.Application.Facades;
using VirtualPetManager.Application.Factories;
using VirtualPetManager.Application.Observers;
using VirtualPetManager.Application.Strategies;
using VirtualPetManager.Application.Utils;
using VirtualPetManager.Domain;

namespace VirtualPetManager.Application
{
    public class PetService : IPetService
    {
        private readonly PetCareFacade _petCareFacade = new();
        private readonly INotifier _notifier;
        private readonly PetMoodSubject _moodSubject = new();




        public PetService(INotifier notifier)
        {
            _notifier = notifier;
            _moodSubject.Attach(new LoggerObserver());
            _moodSubject.Attach(new NotifierObserver());
        }

        private static readonly List<Pet> _pets = new();

        public IEnumerable<Pet> GetAll() => _pets;

        public Pet? GetById(Guid id) => _pets.FirstOrDefault(p => p.Id == id);

        public void Create(Pet pet) => _pets.Add(pet);

        public void Feed(Guid id)
        {
            var pet = GetById(id);
            if (pet != null)
            {
                //pet.Feed();
                //ActionLogger.Instance.Log($"{pet.Name} fue alimentado.");
                //_notifier.Send($"{pet.Name} ahora está feliz porque fue alimentado.");

                var old = pet.Mood.ToString();
                pet.Feed();
                var current = pet.Mood.ToString();

                if (old != current)
                    _moodSubject.Notify(pet, old, current);


                ActionLogger.Instance.Log($"{pet.Name} fue alimentado.");
                _notifier.Send($"{pet.Name} ahora está feliz porque fue alimentado.");
            }

        }

        public void Clean(Guid id)
        {
            var pet = GetById(id);
            if (pet != null)
            {
                pet.Clean();
                ActionLogger.Instance.Log($"{pet.Name} se ha duchado.");
                _notifier.Send($"{pet.Name} ahora está feliz porque fue duchado.");
            }
        }

        public void Play(Guid id)
        {
            var pet = GetById(id);
            if (pet != null)
            {
                pet.Play();
                ActionLogger.Instance.Log($"{pet.Name} ha jugado con sus compañeros.");
                _notifier.Send($"{pet.Name} ahora está feliz porque jugó con sus compañeros.");
            }
        }

        public void Play(Guid id, string strategyType)
        {
            var pet = GetById(id);
            if (pet == null) return;

            IPlayStrategy strategy = strategyType.ToLower() switch
            {
                "ball" => new PlayWithBall(),
                "hide" => new PlayHideAndSeek(),
                "jump" => new PlayJump(),
                _ => throw new ArgumentException("Tipo de juego no válido")
            };

            strategy.Play(pet);
        }


        /*FACTORY METHOD*/
        public void CreateFromFactory(string name, int age, string type)
        {
            PetCreator creator = type.ToLower() switch
            {
                "perro" => new DogCreator(),
                "gato" => new CatCreator(),
                _ => throw new ArgumentException("Tipo de mascota no soportado")
            };

            var pet = creator.CreatePet(name, age);
            _pets.Add(pet);

            ActionLogger.Instance.Log($"Mascota creada con Factory: {pet.Name} ({type})");
        }


        public void CreateWithBuilder(string name, int age, string type)
        {
            var mood = type.ToLower() switch
            {
                "perro" => PetMood.Excited,
                "gato" => PetMood.Bored,
                _ => PetMood.Happy
            };

            var pet = new PetBuilder()
                .SetName(name)
                .SetType(type)
                .SetAge(age)
                .SetMood(mood)
                .Build();

            _pets.Add(pet);

            ActionLogger.Instance.Log($"Mascota creada con Builder: {pet.Name} ({type})");
        }

        public string GetDecoratedDescription(Guid id)
        {
            var pet = GetById(id);
            if (pet == null)
                return "Mascota no encontrada.";

            PetComponent component = new BasicPetComponent(pet);

            var decorators = new List<Func<PetComponent, PetComponent>>
            {
                c => new WithOutfit(c)
            };

            if (pet.Type.ToLower() == "perro")
            {
                decorators.Add(c => new WithTrick(c));
            }

            // Obtener nombres de decoradores aplicados
            var decoratorNames = decorators
                .Select(d => d(new BasicPetComponent(pet)).GetType().Name)
                .ToList();

            ActionLogger.Instance.Log(
                $"{pet.Name} recibió decoradores por ser {pet.Type}: {string.Join(", ", decoratorNames)}"
            );

         
            foreach (var apply in decorators)
            {
                component = apply(component);
            }

            return component.Describe();

        }
        public void TakeCare(Guid id)
        {
            var pet = GetById(id);
            if (pet != null)
            {
                _petCareFacade.TakeCare(pet);
            }
        }


        /*COMMAND PATRON*/
        public void TakeCare(Pet pet)
        {
            var invoker = new PetCommandInvoker();
            invoker.AddCommand(new FeedCommand(pet));
            invoker.AddCommand(new PlayCommand(pet));
            invoker.AddCommand(new CleanCommand(pet));
            invoker.ExecuteCommands();
        }

    }
}
