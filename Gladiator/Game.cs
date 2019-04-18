using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;

namespace Gladiator
{
    class Game
    {
        public  List<Battle> Battles { get; set; }
        public List<Player> Players { get; set; }

        public Game()
        {
            Players = new List<Player>();
        }
        
        /// <summary>
        /// Creer les joueurs
        /// </summary>
        /// <param name="playerNumber"></param>
        /// <param name="playerName"></param>
        public void JoinGame(Player player)
        {
            Players.Add(player);
        }

        public void LeaveGame(Player player)
        {
            Players.Remove(player);
        }
    }
}