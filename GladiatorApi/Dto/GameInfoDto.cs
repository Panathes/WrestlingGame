using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GladiatorLibrary;

namespace GladiatorApi.Dto
{
    public class GameInfoDto
    {
        public List<PlayerInfoDto> Gladiators { get; set; }
        public bool IsBattleFinish { get; set; }
        public Guid GladiatorId { get; set; }
    }
}
