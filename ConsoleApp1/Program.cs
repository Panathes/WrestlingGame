using System;


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

            Console.WriteLine("Player 2, choose your charater : Spartacus, Crixus ou Piscus");
            var name2 = Console.ReadLine();
            Gladiator player2 = game.PlayerChooseGladiator(name2);

            Console.WriteLine("Start fight !");

            game.PlayerFightScenario(player1, player2);


        }
    }
}
