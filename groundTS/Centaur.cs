using Race_progress.typeTS;

namespace Race_progress.groundTS
{
    internal class Centaur : GroundTransport
    {
        internal Centaur() : base("Кентавр", 6.0, 1.0, 74.0) { }
        protected override void ChangeSpeed()
        {
            // тригонометрическая функция 
            double angle = Math.PI * CurrentSpeed / 180.0;
            CurrentSpeed = Math.Sin(angle) * 100;
        }
    }
}
