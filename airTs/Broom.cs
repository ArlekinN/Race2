using Race_progress.typeTS;

namespace Race_progress.airTs
{
    internal class Broom : AirTransport
    {
        internal Broom() : base("Метла", 0.3, 2.6) { }
        protected override void ChangeAcceleratinoFactor()
        {
            // линейная
            AcceleratinoFactor = Math.Abs(5 - Place * 0.3) / 200;
        }
    }
}
