using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualPetManager.Domain.Dtos
{
    public class PetRequestByType
    {
        public string Name { get; set; } = string.Empty;
        public int Age { get; set; }
        public string Type { get; set; } = string.Empty;
    }
}
