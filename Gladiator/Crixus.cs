namespace Gladiator
{
    class Crixus : Gladiator
    {
        public override string Name { get; } = "Crixus";
        public override int Pv { get; set; } = 140;
        public override int Stamina { get; set; } = 100;
        public override int WeakAtt { get; } = 10;
        public override int StrongAtt { get; } = 30;
    }
}