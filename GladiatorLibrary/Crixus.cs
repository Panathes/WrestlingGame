using System;

namespace GladiatorLibrary
{
    class Crixus : Gladiator
    {
        public override Guid GladiatorId { get; set; }
        public override string Name { get; set; } = "Crixus";
        public override int Pv { get; set; } = 140;
        public override int Stamina { get; set; } = 100;
        public override int WeakAtt { get; } = 10;
        public override int StrongAtt { get; } = 30;

        public Crixus()
        {
            GladiatorId = Guid.NewGuid();
        }

    }
}