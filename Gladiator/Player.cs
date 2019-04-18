using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace Gladiator
{
    public class Player
    {
        public string Name { get; set; }

        public override string ToString()
        {
            return $"A played named {Name}";
        }
    }
}
