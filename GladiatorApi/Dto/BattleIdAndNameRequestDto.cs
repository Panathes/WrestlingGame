using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GladiatorApi.Dto
{
    public class BattleIdAndNameRequestDto
    {
        public Guid BattleId { get; set; }
        public string BattleName { get; set; }
    }
}
