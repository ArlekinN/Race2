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
            this.place = 1;
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
            changeAcceleratinoFactor();
        }
        private protected virtual void changeAcceleratinoFactor() { }
    }

    class GroundTransport : Transport
    {
        private double timeBeforeRest;
        private double currentTimeBeforeRest;
        private double timeRest;
        private double currentTimeRest;
        private protected double currentSpeed;
        private protected GroundTransport(string name, double timeBeforeRest, double timeRest, double startSpeed) : base(name, TypeTS.ground, startSpeed)
        {
            this.timeBeforeRest = timeBeforeRest;
            this.currentTimeBeforeRest = timeBeforeRest;
            this.timeRest = timeRest;
            this.currentTimeRest = timeRest;
            this.currentSpeed = startSpeed;
        }

        internal override void move(double currentTime)
        {
            if (currentTimeBeforeRest > 0)
            {
                currentTimeBeforeRest--;
                place += startSpeed;
                changeSpeed();
            }
            else if (currentTimeRest > 0)
            {
                currentTimeRest--;
            }
            else
            {
                currentTimeRest = timeRest;
                currentTimeBeforeRest = timeBeforeRest;
                currentSpeed = startSpeed;
            }

        }
        private protected virtual void changeSpeed() { }
    }

    namespace AirRacer
    {
        class BabaYagaStupa : AirTransport
        {
            public BabaYagaStupa() : base("Ступа Бабы Яги", 1.0, 3.4) { }
            private protected override void changeAcceleratinoFactor()
            {
                // показательная функция 
                acceleratinoFactor = Math.Pow(acceleratinoFactor, 1 / place);
            }
        }
        class Broom : AirTransport
        {
            public Broom() : base("Метла", 2.0, 2.6) { }
            private protected override void changeAcceleratinoFactor()
            {
                // линейная
                acceleratinoFactor = Math.Abs(5 - place * 0.3);
            }
        }
        class MagicCarpet : AirTransport
        {
            public MagicCarpet() : base("Ковер-самолет", 1.6, 2.9) { }
            private protected override void changeAcceleratinoFactor()
            {
                // квадратная
                acceleratinoFactor = Math.Pow((place * 0.9), 2); ;
            }
        }
        class FlyingShip : AirTransport
        {
            public FlyingShip() : base("Летучий Корабль", 3.1, 1.3) { }
            private protected override void changeAcceleratinoFactor()
            {
                // логарифмическая функция
                acceleratinoFactor = Math.Abs(Math.Log(place * 1.2, 2));
            }
        }

    }
    namespace GroundRacer
    {
        class WalkingBoots : GroundTransport
        {
            public WalkingBoots() : base("Сапоги-скороходы", 3.0, 1.0, 2.1) { }
            // скорость константа

        }
        class PumpkinCarriage : GroundTransport
        {
            public PumpkinCarriage() : base("Карета-тыква", 7.0, 2.0, 1.2) { }
            private protected override void changeSpeed()
            {
                //линейная функция
                currentSpeed *= 1.2;
            }
        }
        class HutOnChickenLegs : GroundTransport
        {
            public HutOnChickenLegs() : base("Избушка на курьих ножках", 4.0, 1.0, 8.0) { }
            private protected override void changeSpeed()
            {
                //логарифмическая функция
                currentSpeed = Math.Log(currentSpeed * 1.4, 2);

            }
        }
        class Centaur : GroundTransport
        {
            public Centaur() : base("Кентавр", 6.0, 2.0, 6.0) { }
            private protected override void changeSpeed()
            {
                // тригонометрическая функция 
                double angle = Math.PI * currentSpeed / 180.0;
                currentSpeed = Math.Sin(angle) * 100;
            }
        }
    }
}
