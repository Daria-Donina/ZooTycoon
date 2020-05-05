using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Animals.Entities
{
    class AnimalInfo
    {
        public AnimalInfo(int index) => AnimalIndex = index;

        public int AnimalIndex { get; set; }

        public float Food { get; set; }

        public float Water { get; set; }

        public float Entertainment { get; set; }

        public float Inhabitancy { get; set; }

        public float Welfare { get; set; }
    }
}
