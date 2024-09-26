using Transports;
namespace GameRace
{
    public enum TypeRace
    {
        air,
        ground,
        airAndGround
    }
    class Race
    {
        private double distance;
        private TypeRace typeRace;
        private double time;
        // индекс ТС - объект ТС
        private Dictionary<int, Transport> transports = new Dictionary<int, Transport>();
        // индекс ТС - местоположение ТС
        private Dictionary<int, double> place = new Dictionary<int, double>();
        public Race(double distance, TypeRace typeRace)
        {
            this.distance = distance;
            this.typeRace = typeRace;
            time = 0;
        }
        private void checkTypeTs(Transport ts)
        {
            if (typeRace != TypeRace.airAndGround)
            {
                if (typeRace.ToString() != ts.typeTS.ToString())
                {
                    throw new Exception();
                }
            }
        }
        public void registration(Transport ts)
        {
            try
            {
                checkTypeTs(ts);
                transports.Add(transports.Count, ts);
                place.Add(place.Count, 0.0);
            }
            catch (Exception)
            {
                Console.WriteLine("Тип транспорта не соответсвует типу гонки");
            }
        }
        public void Start()
        {
          
        }
    }
}
