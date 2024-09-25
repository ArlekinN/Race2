namespace Transports
{
    public enum TypeTS
    {
        air,
        ground
    }
    abstract class Transport
    {
        public string name { get;  set; }
        public TypeTS typeTS { get;  set; }
        private protected double startSpeed { get; set; }
        public double place { get; set; }
        public Transport(string name, TypeTS typeTs, double startSpeed)
        {
            this.name = name;
            this.typeTS = typeTs;
            this.place = 0;
            this.startSpeed = startSpeed;
        }
        public abstract void move(double currentTime);
        private protected abstract void changeSpeed();
    }
}
