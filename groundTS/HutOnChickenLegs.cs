using Race_progress.typeTS;

namespace Race_progress.groundTS
{
    internal class HutOnChickenLegs : GroundTransport
    {
        internal HutOnChickenLegs() : base("Избушка на курьих ножках", 4.0, 1.0, 17.0) { }
        protected override void ChangeSpeed()
        {
            //логарифмическая функция
            CurrentSpeed = Math.Log(CurrentSpeed * 5, 2) * 100;

        }
    }
}
