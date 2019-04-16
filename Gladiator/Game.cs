using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;

namespace Gladiator
{
    class Game
    {
        public  List<Battle> Battle { get; set; }
        public List<Player> Player { get; set; }

        
        //public void  StartGame()
        //{
        //    Gladiator player1 = null;
        //    Gladiator player2 = null;
        //    // Player 1 choose charater
        //    Console.WriteLine("Player 1, choose your charater : Spartacus, Crixus ou Piscus");
        //    var name = Console.ReadLine();
        //    switch (name)
        //    {
        //        case "Spartacus":
        //            {
        //                Console.WriteLine("You choose Spartacus ! ");
        //                player1 = new Spartacus();
        //                break;
        //            }
        //        case "Crixus":
        //            {
        //                Console.WriteLine("You choose Crixus ! ");
        //                player1 = new Crixus();
        //                break;
        //            }
        //        case "Piscus":
        //            {
        //                Console.WriteLine("You choose Piscus ! ");
        //                player1 = new Piscus();
        //                break;
        //            }
        //        default:
        //            Console.WriteLine("No choice ? Well take Spartacus anyway ! ");
        //            player1 = new Spartacus();
        //            break;
        //    }

        //    // Player 2 choose charater
        //    Console.WriteLine("Player 2, choose your charater : Spartacus, Crixus ou Piscus");
        //    var name2 = Console.ReadLine();
        //    switch (name2)
        //    {
        //        case "Spartacus":
        //            {
        //                Console.WriteLine("You choose Spartacus ! ");
        //                player2 = new Spartacus();
        //                break;
        //            }
        //        case "Crixus":
        //            {
        //                Console.WriteLine("You choose Crixus ! ");
        //                player2 = new Crixus();
        //                break;
        //            }
        //        case "Piscus":
        //            {
        //                Console.WriteLine("You choose Piscus ! ");
        //                player2 = new Piscus();
        //                break;
        //            }
        //        default:
        //            Console.WriteLine("No choice ? Well take Crixus anyway ! ");
        //            player2 = new Crixus();
        //            break;
        //    }

        //    Console.WriteLine("Start fight !");
        //}

//        public void EndGame()
//        {
//            if (player1.Pv > player2.Pv)
//            {
//                Console.WriteLine($"Game is over mates !  Player 2 win");
//            }
//
//            if (player1.Pv < player2.Pv)
//            {
//                Console.WriteLine($"Game is over mates !  Player 1 win");
//            }
//            Console.ReadLine();
//        }
    }
}