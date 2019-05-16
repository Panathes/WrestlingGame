using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GladiatorApi.Dto
{
    public class PlayerInfoDto
    {
        public Guid PlayerId { get; set; }
        public string Name { get; set; }
        public int Pv { get; set; }
        public int Stamina { get; set; }

    }
}
