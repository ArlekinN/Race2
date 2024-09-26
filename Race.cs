using Spectre.Console;
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
        private Dictionary<int, string> placeRacer = new Dictionary<int, string>();
        // индекс ТС - время его финиша
        private Dictionary<int, string> timeFinish = new Dictionary<int, string>();
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
                placeRacer.Add(placeRacer.Count, "");
                timeFinish.Add(timeFinish.Count, "");
                return true;
            }
            catch (Exception)
            {
                transports.Clear();
                AnsiConsole.Markup($"Тип транспорта [red]{ts.name}[/] не соответсвует типу гонки\n");
                return false;
            }
        }
        public void Start()
        {
            Transport ts;
            int tsIndex;
            int placeResult = 1;
            Console.WriteLine("!!!!!Старт гонки!!!!!");

            var table = new Table().Centered();
            table.Title("Таблица результатов");
            table.Centered();
            table.AddColumn("Участник");
            table.AddColumn("Прогресс");
            table.AddColumn("Место");
            table.AddColumn("Время финиша");
            for (int i = 0; i < transports.Count; i++)
            {
                table.AddRow(transports[i].name, "0%", placeRacer[i], timeFinish[i]);
            }
           

            AnsiConsole.Live(table)
                .Start(ctx =>
                {
                    while (placeResult != transports.Count + 1)
                    {
                        ctx.Refresh();
                        foreach (var TSslot in transports)
                        {
                            table.RemoveRow(0);
                            ts = TSslot.Value;
                            tsIndex = TSslot.Key;
                            if (placeRacer[tsIndex] == "")
                            {
                                ts.move(time);
                                place[tsIndex] = ts.place;
                                if (place[tsIndex] >= distance)
                                {
                                    placeRacer[tsIndex] = placeResult.ToString();
                                    placeResult++;
                                    timeFinish[tsIndex] = time.ToString();
                                    place[tsIndex] = distance;
                                }
                                
                            }
                            table.AddRow(ts.name, (Math.Round(place[tsIndex] / distance * 100)).ToString() + "%", placeRacer[tsIndex], timeFinish[tsIndex]);
                        }
                        time++;
                    }


                });
        }
    }
}
