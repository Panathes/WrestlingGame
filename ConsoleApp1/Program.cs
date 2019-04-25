using System;
using System.Collections.Generic;


namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();
            
            Console.WriteLine("Gladiator Battle !");

            Console.WriteLine("Player 1, choose your charater : Spartacus, Crixus ou Piscus");
            var name1 = Console.ReadLine();
            Gladiator player1 = game.PlayerChooseGladiator(name1);
            Console.WriteLine($"You choose {player1.Name} ! ");
            Console.WriteLine($"{player1.GladiatorId} C'est mal d'affiché l'id !!");


            Console.WriteLine("Player 2, choose your charater : Spartacus, Crixus ou Piscus");
            var name2 = Console.ReadLine();
            Gladiator player2 = game.PlayerChooseGladiator(name2);
            Console.WriteLine($"You choose {player2.Name} ! ");
            Console.WriteLine($"{player2.GladiatorId} C'est mal d'affiché l'id !!");

            Console.WriteLine("Start fight !");

            Guid battleId = game.StartBattle();

            do
            {

                Console.WriteLine($"{player1.Name}, choose an action : 1 for Weak, 2 for Strong ou 3 for Parry");
                PlayerActions actionFromPlayer1 = (PlayerActions)Convert.ToInt32(Console.ReadLine());
                //   Console.WriteLine($"You choose {action}action");
                Console.WriteLine($"{player2.Name}, choose an action : 1 for Weak, 2 for Strong ou 3 for Parry");
                PlayerActions actionFromPlayer2 = (PlayerActions)Convert.ToInt32(Console.ReadLine());

                game.ActionChooseByPlayers(player1.GladiatorId, actionFromPlayer1);
                game.ActionChooseByPlayers(player2.GladiatorId, actionFromPlayer2);

                Console.WriteLine($"{player1.Name} choose {actionFromPlayer1} action !");
                Console.WriteLine($"{player2.Name} choose {actionFromPlayer2} action !");

                try
                {
                    game.CheckIfPlayerCanAttack(player1, player2, actionFromPlayer1);
                }
                
                catch (PlayerFightLowStaminaException e)
                {
                    Console.WriteLine($"{e.Message}" );
                    continue;
                }

                try
                {
                    game.CheckIfPlayerCanAttack(player2, player1, actionFromPlayer2);
                }

                catch (PlayerFightLowStaminaException e)
                {
                    Console.WriteLine($"{e.Message}");
                    continue;
                }

                //                if (game.PlayerCanAttack == false);
                //                {
                //                    throw new Exception($"Stamina  too low for throwing a attack");
                //                }

                //                try
                //                {

                game.PlayerFightScenario(player1, player2, actionFromPlayer1, actionFromPlayer2, battleId);
//                }
//                catch (Exception e)
//                {
//                      Console.WriteLine($"Players, Someone can't use this attack, please choose your action again");
//
////                    Console.WriteLine($"{player1.Name}, your stamina is too low, please choose an other action");
////                    Console.WriteLine($"{player1.Name}, choose an action : 1 for Weak, 2 for Strong ou 3 for Parry");
////                    actionFromPlayer1 = (PlayerActions)Convert.ToInt32(Console.ReadLine());                    
//                }
              

                Console.WriteLine($"Player 1's Life {player1.Pv}");
                Console.WriteLine($"Player 2's Life {player2.Pv}");
                Console.WriteLine($"Player 1's Stamina {player1.Stamina}");
                Console.WriteLine($"Player 2's Stamina {player2.Stamina}");
                
                Console.WriteLine(player1.GladiatorId);
                Console.WriteLine(player2.GladiatorId);

                game.PlayerIdAndActionChoose.Clear();

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
