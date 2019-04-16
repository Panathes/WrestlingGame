namespace Gladiator
{
    class Spartacus : Gladiator
    {
        public override string Name { get; } = "Spartacus";
        public override int Pv { get; set; } = 90;
        public override int Stamina { get; set; } = 1;
        public override int WeakAtt { get; } = 20;
        public override int StrongAtt { get; } = 60;

    }
}