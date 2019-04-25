using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class PlayerFightLowStaminaException : Exception
    {

        public  PlayerFightLowStaminaException(string message) : base(message)
        {

        }  

    }
}
