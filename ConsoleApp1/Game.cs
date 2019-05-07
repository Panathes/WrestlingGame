using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;

namespace ConsoleApp1
{

    public class Game
    {
        public Dictionary<Guid, Battle> BattleGroup = new Dictionary<Guid, Battle>();

        public void ChooseAction(Guid playerId, PlayerActions action, Guid battleId)
        {
            if (BattleGroup.ContainsKey(battleId))
            {
                Battle battle = BattleGroup[battleId];
                battle.SetAction(playerId, action);
            }
        }


        public Guid StartBattle()
        {
            Battle battle = new Battle();

            BattleGroup.Add(battle.BattleID, battle);

            return battle.BattleID;

        }

        public Guid RegisterPlayerInBattle(Guid battleId, String name)
        {

            if (BattleGroup.ContainsKey(battleId))
            {
                Gladiator choosedGladiator = null;
                switch (name)
                {
                    case "Spartacus":
                        {
                            choosedGladiator = new Spartacus();
                            break;
                        }
                    case "Crixus":
                        {
                            choosedGladiator = new Crixus();
                            break;
                        }
                    case "Piscus":
                        {
                            choosedGladiator = new Piscus();
                            break;
                        }
                    default:
                        choosedGladiator = new Spartacus();
                        break;

                }

                BattleGroup[battleId].Players.Add(choosedGladiator.GladiatorId, choosedGladiator);
                return choosedGladiator.GladiatorId;
            }

            return Guid.Empty;

        }

        public bool RunBattle(Guid battleId)
        {
            if (BattleGroup.ContainsKey(battleId))
            {
                Battle battle = BattleGroup[battleId];
                battle.ExecuteBattle();
                return battle.IsBattleFinish();
            }
            throw new Exception("Battle not found");
        }

        public string FinishBattle(Guid battleId)
        {
            if (BattleGroup.ContainsKey(battleId))
            {
                Battle battle = BattleGroup[battleId];
                return battle.PlayerWinner();
            }
            throw new Exception("Battle not found");
        }

        //            Battle[] battles = new Battle[10];
        //
        //            Dictionary<string, Gladiator> g = new Dictionary<string, Gladiator>();
        //            g.Add("fdsfsdf", g);
        //
        //            HashSet<string> names = new HashSet<string>();
        //            names.Add("jerome");
        //            names.Add("steven");
        //            names.Add("jerome");
    }
}