using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualPetManager.Domain;

namespace VirtualPetManager.Application
{
    public interface IPetService
    {
        IEnumerable<Pet> GetAll();
        Pet? GetById(Guid id);
        void Create(Pet pet);
        void Feed(Guid id);
        void Clean(Guid id);
        void Play(Guid id);

        /* Patron Strategy */
        void Play(Guid id, string strategyType);


        void CreateFromFactory(string name, int age, string type);
        void CreateWithBuilder(string name, int age, string type);
        string GetDecoratedDescription(Guid id);
        void TakeCare(Guid id);

        /* Patron Command */
        void TakeCare(Pet pet);
    }
}
