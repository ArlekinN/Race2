using Transports;

namespace Race_progress.typeTS {
    internal abstract class GroundTransport : Transport
    {
        private double TimeBeforeRest { get; }
        private double CurrentTimeBeforeRest { get; set; }
        private double TimeRest { get; }
        private double CurrentTimeRest { get; set; }
        protected double CurrentSpeed { get; set; }
        protected GroundTransport(string name, double timeBeforeRest, double timeRest, double startSpeed) : base(name, TypeTS.Ground, startSpeed)
        {
            TimeBeforeRest = timeBeforeRest;
            CurrentTimeBeforeRest = timeBeforeRest;
            TimeRest = timeRest;
            CurrentTimeRest = timeRest;
            CurrentSpeed = startSpeed;
        }

        internal override void Move(double currentTime)
        {
            if (CurrentTimeBeforeRest > 0)
            {
                CurrentTimeBeforeRest--;
                Place += CurrentSpeed;
                ChangeSpeed();
            }
            else if (CurrentTimeRest > 0)
            {
                CurrentTimeRest--;
            }
            else
            {
                CurrentTimeRest = TimeRest;
                CurrentTimeBeforeRest = TimeBeforeRest;
                CurrentSpeed = StartSpeed;
            }

        }
        protected virtual void ChangeSpeed() { }
    }
}
