using System.Collections.Generic;

namespace Gladiator
{
    public class BattleRound
    {

        public Dictionary<Player, PlayerAction> ActionChooseFromPlayerAndPlayerFocus { get; set; }
        public PlayerAction PlayerAction { get; set; }

        public int RoundNumber { get; set; }

        public  BattleRound()
        {
             ActionChooseFromPlayerAndPlayerFocus = new Dictionary<Player, PlayerAction>();
             PlayerAction playerAction = null;
        }

        public void pushInformationInDictionary(Player player , string playerAction,string playerFocus)
        {
            string _playerAction = playerAction;
            string _playerFocus = playerFocus;


        }
    }


}