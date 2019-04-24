using System;

namespace ConsoleApp1
{
    class Piscus : Gladiator
    {
        public override Guid GladiatorId { get; set; }
        public override string Name { get; set; } = "Piscus";
        public override int Pv { get; set; } = 100;
        public override int Stamina { get; set; } = 100;
        public override int WeakAtt { get; } = 15;
        public override int StrongAtt { get; } = 45;
    }
}