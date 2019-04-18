using System;
using System.Collections.Generic;

namespace Gladiator
{
    class Battle 
    {
        public string Winner { get; set; }
        public int Score { get; set; }
        public List<BattleCharacter> BattleCharacter { get; set; }

        public Battle()
        {
            BattleCharacter = new List<BattleCharacter>();
        }

        public void StartBattle(Player player1, Player player2)
        {
            Player _player1 = player1;
            Player _player2 = player2;
        }

        public void ChooseCharacter(string character, Player player)
        {
            string _character = character;
            // Gladiator Gladiator = null;
            BattleCharacter battleCharacter = null;

            if (_character == "Spartacus")
            {
                battleCharacter = new BattleCharacter();
                battleCharacter.Player = player;
                battleCharacter.Gladiator = new Spartacus();
            }
            if (_character == "Crixus")
            {
                battleCharacter = new BattleCharacter();
                battleCharacter.Player = player;
                battleCharacter.Gladiator = new Crixus();
            }
            if (_character == "Piscus")
            {
                battleCharacter = new BattleCharacter();
                battleCharacter.Player = player;
                battleCharacter.Gladiator = new Piscus();
            }

            BattleCharacter.Add(battleCharacter);
        }
    }
}