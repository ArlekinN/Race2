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
        private bool successRegistration = true;
        // индекс ТС - объект ТС
        private Dictionary<int, Transport> transports = new Dictionary<int, Transport>();
        // индекс ТС - местоположение ТС
        private Dictionary<int, double> place = new Dictionary<int, double>();
        // индекс ТС - номер, под которым ТС финишировало 
        private Dictionary<int, int> placeRacer = new Dictionary<int, int>();
        public Race(double distance, TypeRace typeRace)
        {
            this.distance = distance;
            this.typeRace = typeRace;
            time = 1;
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
        public bool registration(Transport ts)
        {
            try
            {
                checkTypeTs(ts);
                transports.Add(transports.Count, ts);
                place.Add(place.Count, 0.0);
                placeRacer.Add(placeRacer.Count, 0);
                return true;
            }
            catch (Exception)
            {
                transports.Clear();
                Console.WriteLine($"Тип транспорта {ts.name} не соответсвует типу гонки");
                return false;
            }
        }
        public void Start()
        {
            Transport ts;
            int placeResult = 1;
            Console.WriteLine("!!!!!Старт гонки!!!!!");
            while (placeResult != transports.Count + 1)
            {
                foreach (var TSslot in transports)
                {
                    if (placeRacer[TSslot.Key] != 0) continue;
                    ts = TSslot.Value;
                    ts.move(time);
                    place[TSslot.Key] = ts.place;
                    // достиг финиша
                    if (place[TSslot.Key] >= distance)
                    {
                        Console.WriteLine($"{placeResult} место - {ts.name}, время финиша - {time}");
                        placeRacer[TSslot.Key] = placeResult;
                        placeResult++;
                    }
                }
                time++;
            }
            Console.WriteLine("Конец гонки");
        }
    }
}
