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

            Console.WriteLine("Player 2, choose your charater : Spartacus, Crixus ou Piscus");
            var name2 = Console.ReadLine();

            Guid battleId = game.StartBattle();

            Guid gladiatorId = game.RegisterPlayerInBattle(battleId, name1);
            Guid gladiatorId2 = game.RegisterPlayerInBattle(battleId, name2);


            Console.WriteLine($"You choose {name1} ! ");
            Console.WriteLine($"{gladiatorId} C'est mal d'affiché l'id !!");

            Console.WriteLine($"You choose {name2} ! ");
            Console.WriteLine($"{gladiatorId2} C'est mal d'affiché l'id !!");

            Console.WriteLine("Let's get start !");

            do
            {

                Console.WriteLine($"{name1}, choose an action : 1 for Weak, 2 for Strong ou 3 for Parry");
                PlayerActions actionFromPlayer1 = (PlayerActions) Convert.ToInt32(Console.ReadLine());
                //   Console.WriteLine($"You choose {action}action");
                Console.WriteLine($"{name2}, choose an action : 1 for Weak, 2 for Strong ou 3 for Parry");
                PlayerActions actionFromPlayer2 = (PlayerActions) Convert.ToInt32(Console.ReadLine());


                Console.WriteLine($"{name1} choose {actionFromPlayer1} action !");
                Console.WriteLine($"{name2} choose {actionFromPlayer2} action !");

                try
                {
                    game.ChooseAction(gladiatorId, actionFromPlayer1, battleId);
                }

                catch (PlayerFightLowStaminaException e)
                {
                    Console.WriteLine($"{e.Message}");
                    continue;
                }

                try
                {
                    game.ChooseAction(gladiatorId2, actionFromPlayer2, battleId);
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


//                }
//                catch (Exception e)
//                {
//                      Console.WriteLine($"Players, Someone can't use this attack, please choose your action again");
//
////                    Console.WriteLine($"{name1}, your stamina is too low, please choose an other action");
////                    Console.WriteLine($"{name1}, choose an action : 1 for Weak, 2 for Strong ou 3 for Parry");
////                    actionFromPlayer1 = (PlayerActions)Convert.ToInt32(Console.ReadLine());                    
//                }


//                Console.WriteLine($"{name1}'s Life (Pv) ");
//                Console.WriteLine($"{name2}'s Life (Pv)");
//                Console.WriteLine($"{name1}'s Stamina (Stamina)");
//                Console.WriteLine($"{name2}'s Stamina (Stamina)");

            } while (game.RunBattle(battleId) == false);

            string winner = game.FinishBattle(battleId);
            Console.WriteLine($"The winner is {winner}");
            

            Console.ReadLine();

        }
    }
}
