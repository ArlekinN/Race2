using Race_progress.typeTS;
namespace Race_progress.airTs
{
    internal class MagicCarpet : AirTransport
    {
       internal MagicCarpet() : base("Ковер-самолет", 0.2, 1.3) { }
        protected override void ChangeAcceleratinoFactor()
        {
            // квадратная
            AcceleratinoFactor = Math.Pow((Place * 0.01), 2) / 800; ;
        }
    }
}
