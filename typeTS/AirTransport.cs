using Transports;

namespace Race_progress.typeTS
{
    internal abstract class AirTransport : Transport
    {
        protected double AcceleratinoFactor { get; set; }
        protected AirTransport(string name, double acceleratinoFactor, double startSpeed) : base(name, TypeTS.Air, startSpeed)
        {
            AcceleratinoFactor = acceleratinoFactor;
        }
        // s = v0*t + a*t^2/2
        internal override void Move(double currentTime)
        {
            Place = StartSpeed * currentTime + AcceleratinoFactor * Math.Pow(currentTime, 2) / 2;
            ChangeAcceleratinoFactor();
        }
        protected virtual void ChangeAcceleratinoFactor() { }
    }
}
