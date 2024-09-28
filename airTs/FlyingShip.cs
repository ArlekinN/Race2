using Race_progress.typeTS;

namespace Race_progress.airTs
{
    internal class FlyingShip : AirTransport
    {
        internal FlyingShip() : base("Летучий Корабль", 1.4, 1.3) { }
        protected override void ChangeAcceleratinoFactor()
        {
            // логарифмическая функция
            AcceleratinoFactor = Math.Abs(Math.Log(Place * 1.2, 2));
        }
    }
}
