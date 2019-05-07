using System;

namespace GladiatorLibrary
{
    public abstract class Gladiator
    {
        public abstract Guid GladiatorId { get; set; }
        public abstract string Name { get; set; }
        public abstract int Pv { get; set; }
        public abstract int Stamina { get; set; }
        public abstract int WeakAtt { get; }
        public abstract int StrongAtt { get; }


        public int Parry()
        {
            return Pv;
        } 
        public int ReduceStamina()
        {
            return Stamina = Stamina - 20;
        }

        public int BigReduceStamina()
        {
            return Stamina = Stamina - 50;
        }

        public int GainStamina()
        {
            return Stamina = Stamina + 20;
        }
    }
}
