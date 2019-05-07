using System;

namespace GladiatorLibrary
{
    public interface IGame
    {
        void ChooseAction(Guid playerId, PlayerActions action, Guid battleId);
        Guid StartBattle();
        Guid RegisterPlayerInBattle(Guid battleId, String name);
        bool RunBattle(Guid battleId);
        string FinishBattle(Guid battleId);
    }
}