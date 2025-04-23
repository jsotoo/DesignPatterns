using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualPetManager.Domain;

namespace VirtualPetManager.Application.Strategies
{
    public interface IPlayStrategy
    {
        void Play(Pet pet);
    }
}
