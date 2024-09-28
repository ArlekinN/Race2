using Race_progress.typeTS;
namespace Race_progress.airTs
{
    internal class BabaYagaStupa : AirTransport
    {
        internal BabaYagaStupa() : base("Ступа Бабы Яги", 1.0, 1.5) { }
        protected override void ChangeAcceleratinoFactor()
        {
            // показательная функция 
            AcceleratinoFactor = Math.Pow(AcceleratinoFactor, 1 / (Place * 0.4));
        }
    }
}
