using System;
using System.Collections.Generic;
using System.IO;

namespace ConsoleApp1
{
    public class Battle
    {
        public string Winner { get; set; }
        public int Score { get; set; }
        public Guid BattleID { get; set; }

        public Battle()
        {
            BattleID = Guid.NewGuid();
        }


        //        List<PlayerActions> playerActions = new List<PlayerActions>();
        public Dictionary<Guid, PlayerActions> PlayerIdAndActions = new Dictionary<Guid, PlayerActions>();

        public void AttackFromAttackingPlayer(Gladiator attackingPlayer, Gladiator defenderPlayer, PlayerActions playeraction)
        {
            if (playeraction == PlayerActions.Weak)
            {
                defenderPlayer.Pv = defenderPlayer.Pv - attackingPlayer.WeakAtt;
                attackingPlayer.ReduceStamina();
            }

            if (playeraction == PlayerActions.Strong)
            {
                defenderPlayer.Pv = defenderPlayer.Pv - attackingPlayer.StrongAtt;
                attackingPlayer.BigReduceStamina();
            }
        }

        public PlayerActions TooLowStaminaAttackingPlayer(Gladiator attackingPlayer)
        {
            Console.WriteLine($"{attackingPlayer.Name}, your stamina is too low, please choose an other action");
            Console.WriteLine($"{attackingPlayer.Name}, choose an action : 1 for Weak, 2 for Strong ou 3 for Parry");
            return (PlayerActions)Convert.ToInt32(Console.ReadLine());

        }

        public void ParryActionFromDefenderPlayer(Gladiator defenderPlayer, PlayerActions playeractions)
        {
            defenderPlayer.Parry();

            if (defenderPlayer.Stamina == 100)
            {
                defenderPlayer.Stamina = defenderPlayer.Stamina;
            }
            else
            {
                defenderPlayer.GainStamina();
            }
        }

        public void WeakActionPlayerScenario(Gladiator attackingPlayer, Gladiator defenderPlayer, PlayerActions actionFromPlayer)
        {
        
                if (attackingPlayer.Stamina >= 20)
                {
                    AttackFromAttackingPlayer(attackingPlayer, defenderPlayer, actionFromPlayer);
                }                         
                           
//                    TooLowStaminaAttackingPlayer(attackingPlayer); 
                if (attackingPlayer.Stamina < 20)
                {
                    throw new Exception($"Stamina {attackingPlayer.Name} too low for {actionFromPlayer}");
                }
  
        }

        public void StrongActionPlayerScenario(Gladiator attackingPlayer, Gladiator defenderPlayer, PlayerActions actionFromPlayer)
        {
            if (attackingPlayer.Stamina >= 50)
            {
                AttackFromAttackingPlayer(attackingPlayer, defenderPlayer, actionFromPlayer);
                
            }
            //            TooLowStaminaAttackingPlayer(attackingPlayer);

            if (attackingPlayer.Stamina < 50)
            {
                
                throw new Exception($"Stamina {attackingPlayer.Name} too low for {actionFromPlayer}");
            }
        }

        public void ParryActionPlayerScenario(Gladiator defenderPlayer, PlayerActions actionFromPlayer)
        {
            ParryActionFromDefenderPlayer(defenderPlayer, actionFromPlayer);
        }

//        public void Player1ActionExecute()
//        {
//
//        }


    }
}