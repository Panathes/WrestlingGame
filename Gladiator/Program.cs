using System;
using System.Collections.Generic;


namespace Gladiator
{
    class Program
    {
        static void Main(string[] args)
        {
            var playerWhoRespondNo = new List<Player>();

            Game game = new Game();
            Console.WriteLine("Hi, how many players want to play?");
            int playersNumber = int.Parse(Console.ReadLine());
            
            for (int i = 0; i < playersNumber; i++)
            {
                Console.WriteLine($"Player{i}, what's your name?");
                var name = Console.ReadLine();

                var player = new Player();
                player.Name = name;
                game.JoinGame(player);
            }

            Console.WriteLine($"Do you want to start a game ?");
            var startGame = Console.ReadLine();
            if (startGame == "yes")
            {
                Console.WriteLine($"What name do you want to give to your game ?");
                var gameName = Console.ReadLine();
                Console.WriteLine($"Let's start {gameName} ! ");
            }
            else
            {
                Console.ReadLine();
            }

            Battle battle = new Battle();

            foreach (var player in game.Players)
            {
                Console.WriteLine($"{player.Name} choose your charater : Spartacus, Crixus ou Piscus");
                var characterChooseByPlayer = Console.ReadLine();
                battle.ChooseCharacter(characterChooseByPlayer, player);
                Console.WriteLine($"{player.Name} a choisi {characterChooseByPlayer} !");
            }

            Console.WriteLine($"Players, are you ready ?");
            var ready = Console.ReadLine();
            Console.WriteLine($"So let's start this fight !");

            foreach (var player in game.Players)
            {
                Console.WriteLine($"P{player.Name}, choose an action : Weak, Strong ou Parry");
                string actionChooseFromPlayer = Console.ReadLine();
                Console.ReadLine();
                Console.WriteLine($"{player.Name}, which player do you want to attack ?");
                string playerFocus = Console.ReadLine();
            }


            // Cree une partie

            // La partie se termine

            // A la fin de la partie, tu demandes au joueur s'il veut continuer ou partir

            //            foreach (var player in game.Players)
            //            {
            //                Console.WriteLine($"{player.Name}");
            //                Console.WriteLine($"{player.Name} continued yes / no");
            //                var response = Console.ReadLine();
            //                if (response == "no")
            //                {
            //                    playerWhoRespondNo.Add(player);
            //                }
            //            }
            //
            //            foreach (var player in playerWhoRespondNo)
            //            {
            //               Console.WriteLine($"{player.Name}");
            //               game.LeaveGame(player);
            //            }
            //
            //            Console.WriteLine($"{playerWhoRespondNo.Count}");
            //
            //            Console.WriteLine(game.Players.Count);
            //
            //            Console.ReadLine();

            //

            //TODO : boucler autant de fois qu'il y a de joueur : for & foreach
            //Tu vas créer un joueur
            //Tu vas le register dans ton game


            // Tu m'appelles !!!



            // Version oop horrible / procédurale

            //Gladiator player1 = null;
            //Gladiator player2 = null;
            //// Player 1 choose charater
            //Console.WriteLine("Player 1, choose your charater : Spartacus, Crixus ou Piscus");
            //var name = Console.ReadLine();
            //switch (name)
            //{
            //    case "Spartacus":
            //    {
            //        Console.WriteLine("You choose Spartacus ! ");
            //        player1 = new Spartacus();
            //        break;
            //    }
            //    case "Crixus":
            //    {
            //        Console.WriteLine("You choose Crixus ! ");
            //        player1 = new Crixus();
            //        break;
            //    }
            //    case "Piscus":
            //    {
            //        Console.WriteLine("You choose Piscus ! ");
            //        player1 = new Piscus();
            //        break;
            //    }
            //    default:
            //        Console.WriteLine("No choice ? Well take Spartacus anyway ! ");
            //        player1 = new Spartacus();
            //        break;
            //}

            //// Player 2 choose charater
            //Console.WriteLine("Player 2, choose your charater : Spartacus, Crixus ou Piscus");
            //var name2 = Console.ReadLine();
            //switch (name2)
            //{
            //    case "Spartacus":
            //    {
            //        Console.WriteLine("You choose Spartacus ! ");
            //        player2 = new Spartacus();
            //        break;
            //    }
            //    case "Crixus":
            //    {
            //        Console.WriteLine("You choose Crixus ! ");
            //        player2 = new Crixus();
            //        break;
            //    }
            //    case "Piscus":
            //    {
            //        Console.WriteLine("You choose Piscus ! ");
            //        player2 = new Piscus();
            //        break;
            //    }
            //    default:
            //        Console.WriteLine("No choice ? Well take Crixus anyway ! ");
            //        player2 = new Crixus();
            //        break;
            //}

            //Console.WriteLine("Start fight !");

            //do
            //{
            //    Console.WriteLine("Player 1, choose an action : Weak, Strong ou Parry");
            //    var actionFromPlayer1 = Console.ReadLine();
            //  //   Console.WriteLine($"You choose {action}action");
            //    Console.WriteLine("Player 2, choose an action : Weak, Strong ou Parry");
            //    var actionFromPlayer2 = Console.ReadLine();
            //  //    Console.WriteLine($"You choose {action2}action");
            //  if (actionFromPlayer1 == "Weak")
            //  {
            //      if(player1.Stamina < 20)
            //        {
            //            Console.WriteLine($"Player 1, your stamina is too low, please choose an other action");
            //            Console.WriteLine("Player 1, choose an action : Weak, Strong ou Parry");
            //            actionFromPlayer1 = Console.ReadLine();
            //        }
            //      else
            //      {
            //            Console.WriteLine($"{actionFromPlayer1} action from Player 1 ! {player1.WeakAtt} deal");
            //            player2.Pv = player2.Pv - player1.WeakAtt;
            //            player1.ReduceStamina();
            //       }
            //   }

            //  if (actionFromPlayer2 == "Weak")
            //  {
            //      if (player2.Stamina < 20)
            //      {
            //          Console.WriteLine($"Player 2, your stamina is too low, please choose an other action");
            //          Console.WriteLine("Player 2, choose an action : Weak, Strong ou Parry");
            //          actionFromPlayer1 = Console.ReadLine();
            //      }
            //      else
            //      {
            //          Console.WriteLine($"{actionFromPlayer2} action from Player 2 ! {player2.WeakAtt} deal");
            //          player1.Pv = player1.Pv - player2.WeakAtt;
            //          player2.ReduceStamina();
            //      }
            //    }

            //  if (actionFromPlayer1 == "Strong")
            //  {
            //      if (player1.Stamina < 50)
            //      {
            //          Console.WriteLine($"Player 1, your stamina is too low, please choose an other action");
            //          Console.WriteLine("Player 1, choose an action : Weak, Strong ou Parry");
            //          actionFromPlayer1 = Console.ReadLine();
            //      }
            //      else
            //      {
            //          Console.WriteLine($"{actionFromPlayer1} action from Player 1 ! {player1.StrongAtt} deal");
            //          player2.Pv = player2.Pv - player1.StrongAtt;
            //          player1.BigReduceStamina();
            //      }
            //    }

            //  if (actionFromPlayer2 == "Strong")
            //  {
            //      if (player2.Stamina < 50)
            //      {
            //          Console.WriteLine($"Player 2, your stamina is too low, please choose an other action");
            //          Console.WriteLine("Player 2, choose an action : Weak, Strong ou Parry");
            //          actionFromPlayer2 = Console.ReadLine();
            //      }
            //      else
            //      {
            //          Console.WriteLine($"{actionFromPlayer2} action from Player 2 ! {player2.StrongAtt} deal");
            //          player1.Pv = player1.Pv - player2.StrongAtt;
            //          player2.BigReduceStamina();
            //      }
            //    }

            //  if (actionFromPlayer1 == "Parry")
            //  {
            //      Console.WriteLine($"Player 1 {actionFromPlayer1} ! No damage taken");
            //      player1.Parry();

            //      if (player1.Stamina == 100)
            //      {
            //          player1.Stamina = player1.Stamina;
            //      }
            //      else
            //      {
            //          player1.GainStamina();
            //      }
            //  }

            //  if (actionFromPlayer2 == "Parry")
            //  {
            //      Console.WriteLine($"Player 2 {actionFromPlayer2} ! No damage taken");
            //      player2.Parry();

            //      if (player2.Stamina == 100)
            //      {
            //          player2.Stamina = player2.Stamina;
            //      }
            //      else
            //      {
            //          player2.GainStamina();
            //      }
            //  }
            //  Console.WriteLine($"Player 1's Life {player1.Pv}");
            //  Console.WriteLine($"Player 2's Life {player2.Pv}");
            //  Console.WriteLine($"Player 1's Stamina {player1.Stamina}");
            //  Console.WriteLine($"Player 2's Stamina {player2.Stamina}");
            //} while (player1.Pv > 0 && player2.Pv > 0);

            //if (player1.Pv > player2.Pv)
            //{
            //    Console.WriteLine($"Game is over mates !  Player 2 win");
            //}

            //if (player1.Pv < player2.Pv)
            //{
            //    Console.WriteLine($"Game is over mates !  Player 1 win");
            //}
            //Console.ReadLine();


        }
    }

}
