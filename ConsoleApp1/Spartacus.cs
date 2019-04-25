using System;

namespace ConsoleApp1
{
    class Spartacus : Gladiator
    {
        public override Guid GladiatorId { get; set; }
        public override string Name { get; set; } = "Spartacus";
        public override int Pv { get; set; } = 90;
        public override int Stamina { get; set; } = 100;
        public override int WeakAtt { get; } = 20;
        public override int StrongAtt { get; } = 60;

        public Spartacus()
        {
            GladiatorId = Guid.NewGuid();
        }
    }
}