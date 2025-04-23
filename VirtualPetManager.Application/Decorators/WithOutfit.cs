using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualPetManager.Application.Decorators
{
    public class WithOutfit : PetComponent
    {
        private readonly PetComponent _base;

        public WithOutfit(PetComponent baseComponent)
        {
            _base = baseComponent;
        }

        public override string Describe()
        {
            return _base.Describe() + " con ropa elegante.";
        }
    }
}
