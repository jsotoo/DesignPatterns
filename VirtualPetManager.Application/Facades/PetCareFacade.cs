using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualPetManager.Application.Utils;
using VirtualPetManager.Domain;

namespace VirtualPetManager.Application.Facades
{
    public class PetCareFacade
    {
        public void TakeCare(Pet pet)
        {
            pet.Feed();
            pet.Play();
            pet.Clean();

            ActionLogger.Instance.Log($"{pet.Name} fue cuidado completamente: alimentado, jugado y bañado.");
        }
    }
}
