using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GladiatorLibrary;

namespace GladiatorApi.Dto
{
    public class PlayerChooseActionRequestDto
    {
        public Guid PlayerId { get; set; }
        public PlayerActions Action { get; set; }
    }
}
