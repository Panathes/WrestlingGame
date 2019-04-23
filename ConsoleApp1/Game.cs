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

        public void PlayerFightScenario(Gladiator player1, Gladiator player2)
        {
            do
            {
                Console.WriteLine("Player 1, choose an action : 1 for Weak, 2 for Strong ou 3 for Parry");
                PlayerActions actionFromPlayer1 = (PlayerActions)Convert.ToInt32(Console.ReadLine());
                //   Console.WriteLine($"You choose {action}action");
                Console.WriteLine("Player 2, choose an action : 1 for Weak, 2 for Strong ou 3 for Parry");
                PlayerActions actionFromPlayer2 = (PlayerActions)Convert.ToInt32(Console.ReadLine());

                if (actionFromPlayer1 == PlayerActions.Weak)
                {
                    WeakActionPlayerScenario(player1, player2, actionFromPlayer1);
                }

                if (actionFromPlayer2 == PlayerActions.Weak)
                {
                    WeakActionPlayerScenario(player2, player1, actionFromPlayer2);
                }

                if (actionFromPlayer1 == PlayerActions.Strong)
                {
                    StrongActionPlayerScenario(player1, player2, actionFromPlayer1);
                }

                if (actionFromPlayer2 == PlayerActions.Strong)
                {
                    StrongActionPlayerScenario(player2, player1, actionFromPlayer2);
                }

                if (actionFromPlayer1 == PlayerActions.Parry)
                {
                    ParryActionPlayerScenario(player1, actionFromPlayer1);
                }

                if (actionFromPlayer2 == PlayerActions.Parry)
                {
                    ParryActionPlayerScenario(player2, actionFromPlayer2);
                }

                Console.WriteLine($"Player 1's Life {player1.Pv}");
                Console.WriteLine($"Player 2's Life {player2.Pv}");
                Console.WriteLine($"Player 1's Stamina {player1.Stamina}");
                Console.WriteLine($"Player 2's Stamina {player2.Stamina}");
            } while (player1.Pv > 0 && player2.Pv > 0);

            if (player2.Pv > player1.Pv)
            {
                Console.WriteLine($"Game is over mates !  Player 2 win");
            }

            if (player1.Pv > player2.Pv)
            {
                Console.WriteLine($"Game is over mates !  Player 1 win");
            }
            Console.ReadLine();
        }

    }
}