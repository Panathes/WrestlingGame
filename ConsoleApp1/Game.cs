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
                    return new Spartacus();
                }
                case "Crixus":
                {
                    return new Crixus();
                }
                case "Piscus":
                {
                    return new Piscus();
                }
                default:
                    return new Spartacus();
            }
        }

        public Battle StartBattle()
        {
            Battle[] battles = new Battle[10];

            Dictionary<string, Gladiator> g = new Dictionary<string, Gladiator>();
            g.Add("fdsfsdf", g);

            

            HashSet<string> names = new HashSet<string>();
            names.Add("jerome");
            names.Add("steven");
            names.Add("jerome");

            Battle battle = new Battle();
            return battle;
        }

        public void PlayerFightScenario(Gladiator player1, Gladiator player2, PlayerActions actionFromPlayer1, PlayerActions actionFromPlayer2, Battle battle )
        {

            if (actionFromPlayer1 == PlayerActions.Weak)
            {
                battle.WeakActionPlayerScenario(player1, player2, actionFromPlayer1);
            }

            if (actionFromPlayer2 == PlayerActions.Weak)
            {
                battle.WeakActionPlayerScenario(player2, player1, actionFromPlayer2);
            }

            if (actionFromPlayer1 == PlayerActions.Strong)
            {
                battle.StrongActionPlayerScenario(player1, player2, actionFromPlayer1);
            }

            if (actionFromPlayer2 == PlayerActions.Strong)
            {
                battle.StrongActionPlayerScenario(player2, player1, actionFromPlayer2);
            }

            if (actionFromPlayer1 == PlayerActions.Parry)
            {
                battle.ParryActionPlayerScenario(player1, actionFromPlayer1);
            }

            if (actionFromPlayer2 == PlayerActions.Parry)
            {
                battle.ParryActionPlayerScenario(player2, actionFromPlayer2);
            }
        }

    }
}