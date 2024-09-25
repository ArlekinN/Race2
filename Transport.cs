namespace Transports
{
    public enum TypeTS
    {
        air,
        ground
    }
    abstract class Transport
    {
        internal string name { get;  private protected set; }
        internal TypeTS typeTS { get; private protected set; }
        private protected double startSpeed { get; set; }
        internal double place { get; set; }
        private protected Transport(string name, TypeTS typeTs, double startSpeed)
        {
            this.name = name;
            this.typeTS = typeTs;
            this.place = 0;
            this.startSpeed = startSpeed;
        }
        internal abstract void move(double currentTime);
    }

    class AirTransport : Transport
    {
        private protected double acceleratinoFactor { get; set; }
        private protected AirTransport(string name, double acceleratinoFactor, double startSpeed) : base(name, TypeTS.air, startSpeed)
        {
            this.acceleratinoFactor = acceleratinoFactor;
        }
        // s = v0*t + a*t^2/2
        internal override void move(double currentTime)
        {
            place = startSpeed * currentTime + acceleratinoFactor * Math.Pow(currentTime, 2) / 2;
        }
    }
}
