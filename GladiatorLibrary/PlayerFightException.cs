using System;

namespace GladiatorLibrary
{
    public class PlayerFightLowStaminaException : Exception
    {

        public  PlayerFightLowStaminaException(string message) : base(message)
        {

        }  

    }
}
