namespace Transports
{
    public enum TypeTS
    {
        Air,
        Ground
    }
    internal abstract class Transport
    {
        internal string Name { get; private set; }
        internal TypeTS TypeTS { get; private set; }
        protected double StartSpeed { get; set; }
        internal double Place { get; set; }
        
        protected Transport(string name, TypeTS typeTs, double startSpeed)
        {
            Name = name;
            TypeTS = typeTs;
            Place = 1;
            StartSpeed = startSpeed;
        }
        internal abstract void Move(double currentTime);
    }
}
