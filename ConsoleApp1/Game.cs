using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;

namespace ConsoleApp1
{

    public class Game
    {
        public Gladiator PlayerChooseGladiator(string name)
        {
            switch (name)
            {
                case "Spartacus":
                {
                    Console.WriteLine("You choose Spartacus ! ");
                    return new Spartacus();
                }
                case "Crixus":
                {
                    Console.WriteLine("You choose Crixus ! ");
                    return new Crixus();
                }
                case "Piscus":
                {
                    Console.WriteLine("You choose Piscus ! ");
                    return new Piscus();
                }
                default:
                    Console.WriteLine("No choice ? Well take Spartacus anyway ! ");
                    return new Spartacus();
            }
        }

        public void AttackFromAttackingPlayer(Gladiator attackingPlayer, Gladiator defenderPlayer, PlayerActions playeraction)
        {
            if (playeraction == PlayerActions.Weak)
            {
                Console.WriteLine($"{playeraction} action from {attackingPlayer.Name} ! He deal {attackingPlayer.WeakAtt} damage ");
                defenderPlayer.Pv = defenderPlayer.Pv - attackingPlayer.WeakAtt;
                attackingPlayer.ReduceStamina();
            }

            if (playeraction == PlayerActions.Strong)
            {
                Console.WriteLine($"{playeraction} action from {attackingPlayer.Name} ! He deal {attackingPlayer.StrongAtt} damage");
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
            Console.WriteLine($"Player {defenderPlayer} ! No damage taken");
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
            if (attackingPlayer.Stamina < 20)
            {
                TooLowStaminaAttackingPlayer(attackingPlayer);
            }
            else
            {
                AttackFromAttackingPlayer(attackingPlayer, defenderPlayer, actionFromPlayer);
            }
        }

        public void StrongActionPlayerScenario(Gladiator attackingPlayer, Gladiator defenderPlayer, PlayerActions actionFromPlayer)
        {
            if (attackingPlayer.Stamina < 50)
            {
                TooLowStaminaAttackingPlayer(attackingPlayer);
            }
            else
            {
                AttackFromAttackingPlayer(attackingPlayer, defenderPlayer, actionFromPlayer);
            }
        }

        public void ParryActionPlayerScenario(Gladiator defenderPlayer, PlayerActions actionFromPlayer)
        {
            ParryActionFromDefenderPlayer(defenderPlayer, actionFromPlayer);
        }

        public void PlayerFightScenario(PlayerActions actionFromPlayer1, PlayerActions actionFromPlayer2)
        {

        }

    }
}