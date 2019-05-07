using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GladiatorApi.Dto
{
    public class GameRegisterPlayerRequestDto
    {
        public Guid BattleId { get; set; }
        public string Gladiator { get; set; }
    }
}
