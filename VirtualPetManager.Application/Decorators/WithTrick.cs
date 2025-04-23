using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualPetManager.Application.Decorators
{
    public class WithTrick : PetComponent
    {
        private readonly PetComponent _base;

        public WithTrick(PetComponent baseComponent)
        {
            _base = baseComponent;
        }

        public override string Describe()
        {
            return _base.Describe() + " y sabe hacer trucos.";
        }
    }
}
