using System;


namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();

            Console.WriteLine("Hello World!");

            Console.WriteLine("Player 1, choose your charater : Spartacus, Crixus ou Piscus");
            var name1 = Console.ReadLine();
            Gladiator player1 = game.PlayerChooseGladiator(name1);

            Console.WriteLine("Player 2, choose your charater : Spartacus, Crixus ou Piscus");
            var name2 = Console.ReadLine();
            Gladiator player2 = game.PlayerChooseGladiator(name2);

            Console.WriteLine("Start fight !");

            do
            {
                Console.WriteLine("Player 1, choose an action : 1 for Weak, 2 for Strong ou 3 for Parry");
                PlayerActions actionFromPlayer1 = (PlayerActions)Convert.ToInt32(Console.ReadLine());
                //   Console.WriteLine($"You choose {action}action");
                Console.WriteLine("Player 2, choose an action : 1 for Weak, 2 for Strong ou 3 for Parry");
                PlayerActions actionFromPlayer2 = (PlayerActions)Convert.ToInt32(Console.ReadLine());

                if (actionFromPlayer1 == PlayerActions.Weak)
                {
                    game.WeakActionPlayerScenario(player1, player2, actionFromPlayer1);
                }

                if (actionFromPlayer2 == PlayerActions.Weak)
                {
                    game.WeakActionPlayerScenario(player2, player1, actionFromPlayer2);
                }

                if (actionFromPlayer1 == PlayerActions.Strong)
                {
                    game.StrongActionPlayerScenario(player1, player2, actionFromPlayer1);
                }

                if (actionFromPlayer2 == PlayerActions.Strong)
                {
                    game.StrongActionPlayerScenario(player2, player1, actionFromPlayer2);
                }

                if (actionFromPlayer1 == PlayerActions.Parry)
                {
                    game.ParryActionPlayerScenario(player1, actionFromPlayer1);
                }

                if (actionFromPlayer2 == PlayerActions.Parry)
                {
                    game.ParryActionPlayerScenario(player2, actionFromPlayer2);
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
