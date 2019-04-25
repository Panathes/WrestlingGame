using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;

namespace ConsoleApp1
{

    public class Game
    {
        public Dictionary<Guid, Battle> BattleGroup = new Dictionary<Guid, Battle>();
        public Dictionary<Guid, PlayerActions> PlayerIdAndActionChoose = new Dictionary<Guid, PlayerActions>();

        public Gladiator PlayerChooseGladiator(string name)
        {
            switch (name)
            {
                case "Spartacus":
                {
                    return new Spartacus();
                }
                case "Crixus":
                {
                    return new Crixus();
                }
                case "Piscus":
                {
                    return new Piscus();
                }
                default:
                    return new Spartacus();
            }
        }

        public void ActionChooseByPlayers(Guid playerId, PlayerActions actionChooseByPlayer)
        {
            PlayerIdAndActionChoose.Add(playerId, actionChooseByPlayer);
        }

        public Guid StartBattle()
        {
            Battle battle = new Battle();
   
            BattleGroup.Add(battle.BattleID, battle);

            return battle.BattleID;

        }

//        public bool PlayerCanAttack = true;

        public void CheckIfPlayerCanAttack(Gladiator attackingPlayer, Gladiator defenderPlayer, PlayerActions actionFromPlayer)
        {

//            if (actionFromPlayer == PlayerActions.Weak && attackingPlayer.Stamina >= 20)
//            {
////                PlayerCanAttack = true;
//            }

            if (actionFromPlayer == PlayerActions.Weak && attackingPlayer.Stamina < 20)
            {
//                PlayerCanAttack = false;
                throw new PlayerFightLowStaminaException($"Stamina {attackingPlayer.Name} too low for {actionFromPlayer}");
            }

//            if (actionFromPlayer == PlayerActions.Strong && attackingPlayer.Stamina >= 50)
//            {
////                PlayerCanAttack = true;
//            }

            if (actionFromPlayer == PlayerActions.Strong && attackingPlayer.Stamina < 50)
            {
//                PlayerCanAttack = false;
                throw new PlayerFightLowStaminaException($"ouais ouais ouais");
            }

//            return PlayerCanAttack;
        }

        public void PlayerFightScenario(Gladiator player1, Gladiator player2, PlayerActions actionFromPlayer1, PlayerActions actionFromPlayer2, Guid battleId)
        {
            if (BattleGroup.ContainsKey(battleId) )
            {
                Battle battle = BattleGroup[battleId];

                    if (actionFromPlayer1 == PlayerActions.Weak)
                    {
                        battle.WeakActionPlayerScenario(player1, player2, actionFromPlayer1);
                    }

                    if (actionFromPlayer2 == PlayerActions.Weak)
                    {
                        battle.WeakActionPlayerScenario(player2, player1, actionFromPlayer2);
                    }

                    if (actionFromPlayer1 == PlayerActions.Strong)
                    {
                        battle.StrongActionPlayerScenario(player1, player2, actionFromPlayer1);
                    }

                    if (actionFromPlayer2 == PlayerActions.Strong)
                    {
                        battle.StrongActionPlayerScenario(player2, player1, actionFromPlayer2);
                    }

                    if (actionFromPlayer1 == PlayerActions.Parry)
                    {
                        battle.ParryActionPlayerScenario(player1, actionFromPlayer1);
                    }

                    if (actionFromPlayer2 == PlayerActions.Parry)
                    {
                        battle.ParryActionPlayerScenario(player2, actionFromPlayer2);
                    }              
            }
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