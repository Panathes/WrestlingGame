using System.Collections.Generic;

namespace Gladiator
{
    public class PlayerAction
    {
        public Player PlayerTarget { get; set; }
        public PlayerSourceAction Action { get; set; }
    }

    public enum PlayerSourceAction
    {
        WeakAttack,
        StrongAttack,
        Parry
    }
}