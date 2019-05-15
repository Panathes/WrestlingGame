using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.IO;
using System.Linq;

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

        private Dictionary<Guid, PlayerActions> _playerActions = new Dictionary<Guid, PlayerActions>();

        public Dictionary<Guid, Gladiator> Players = new Dictionary<Guid, Gladiator>();

        //        List<PlayerActions> playerActions = new List<PlayerActions>();

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

        public void SetAction(Guid playerId, PlayerActions action)
        {

                var gladiator = Players[playerId];


                if (action == PlayerActions.Weak && gladiator.Stamina < 20)
                {
                    //                PlayerCanAttack = false;
                    throw new PlayerFightLowStaminaException($"An error has occurred");
                }
                if (action == PlayerActions.Strong && gladiator.Stamina < 50)
                {
                    //                PlayerCanAttack = false;
                    throw new PlayerFightLowStaminaException($"An error has occurred");
                }

                if (_playerActions.ContainsKey(playerId))
                {
                    _playerActions[playerId] = action;
                }
                else
                {
                    _playerActions.Add(playerId, action);
                }

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
  
        }

        public void StrongActionPlayerScenario(Gladiator attackingPlayer, Gladiator defenderPlayer, PlayerActions actionFromPlayer)
        {
            if (attackingPlayer.Stamina >= 50)
            {
                AttackFromAttackingPlayer(attackingPlayer, defenderPlayer, actionFromPlayer);
                
            }
        }

        public void ParryActionPlayerScenario(Gladiator defenderPlayer, PlayerActions actionFromPlayer)
        {
            ParryActionFromDefenderPlayer(defenderPlayer, actionFromPlayer);
        }

        public bool IsBattleFinish()
        {
            int counter = 0;

            foreach (var player in Players.Values)
            {

                if (player.Pv >0)
                {
                    counter++;
                }
            }
            if (counter == 1)
            {
                return true;
            }
            return false;
        }

        public string PlayerWinner()
        {
            var player1 = Players.Values.ElementAt(0);
            var player2 = Players.Values.ElementAt(1);

            string text = "Still fighting";

            if (player1.Pv > player2.Pv)
            {
                return player1.Name;
            }

            if (player2.Pv > player1.Pv)
            {
                return player2.Name;
            }
           
            return text;
        }

        public List<Guid> ListPlayer()
        {
            var playerList = Players.Keys.ToList();
            return playerList;
        }

        public void ExecuteBattle()
        {
            foreach (var playerAction in _playerActions)
            {
                var player = Players[playerAction.Key];

                Gladiator playerSource = Players[playerAction.Key];
                Gladiator playerTarget = Players.Single(p => p.Key != playerSource.GladiatorId).Value;

                var action = playerAction.Value;
          
                if (action == PlayerActions.Weak)
                {
                    WeakActionPlayerScenario(playerSource, playerTarget, action);
                }

                if (action == PlayerActions.Strong)
                {
                    StrongActionPlayerScenario(playerSource, playerTarget, action);
                }

                if (action == PlayerActions.Parry)
                {
                    ParryActionPlayerScenario(player, action);
                }

            }
        }
    }
}