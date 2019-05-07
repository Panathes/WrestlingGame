using System;

namespace GladiatorLibrary
{
    class PlayerFightLowStaminaException : Exception
    {

        public  PlayerFightLowStaminaException(string message) : base(message)
        {

        }  

    }
}
