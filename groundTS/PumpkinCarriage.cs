using Race_progress.typeTS;

namespace Race_progress.groundTS
{
    internal class PumpkinCarriage : GroundTransport
    {
        internal PumpkinCarriage() : base("Карета-тыква", 7.0, 2.0, 35.2) { }
        protected override void ChangeSpeed()
        {
            //линейная функция
            CurrentSpeed *= 1.2;
        }
    }
}
