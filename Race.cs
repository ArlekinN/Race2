using Spectre.Console;
using Transports;
namespace GameRace
{
    public enum TypeRace
    {
        Air,
        Ground,
        AirAndGround
    }
    internal class Race
    {
        private double Distance { get; set; }
        private TypeRace TypeRace { get; set; }
        private double Time { get; set; }
        // индекс ТС - объект ТС
        private Dictionary<int, Transport> transports = new Dictionary<int, Transport>();
        // индекс ТС - местоположение ТС
        private Dictionary<int, double> place = new Dictionary<int, double>();
        // индекс ТС - номер, под которым ТС финишировало 
        private Dictionary<int, string> placeRacer = new Dictionary<int, string>();
        // индекс ТС - время его финиша
        private Dictionary<int, string> timeFinish = new Dictionary<int, string>();
        internal Race(double distance, TypeRace typeRace)
        {
            Distance = distance;
            TypeRace = typeRace;
            Time = 1;
        }
        private void CheckTypeTs(Transport ts)
        {
            if (TypeRace != TypeRace.AirAndGround)
            {
                if (TypeRace.ToString() != ts.TypeTS.ToString())
                {
                    throw new Exception();
                }
            }
        }
        internal bool Registration(Transport ts)
        {
            try
            {
                CheckTypeTs(ts);
                transports.Add(transports.Count, ts);
                place.Add(place.Count, 0.0);
                placeRacer.Add(placeRacer.Count, "");
                timeFinish.Add(timeFinish.Count, "");
                return true;
            }
            catch (Exception)
            {
                transports.Clear();
                AnsiConsole.Markup($"Тип транспорта [red]{ts.Name}[/] не соответсвует типу гонки\n");
                return false;
            }
        }
        internal void Start()
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
                table.AddRow(transports[i].Name, "0%", placeRacer[i], timeFinish[i]);
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
                                ts.Move(Time);
                                place[tsIndex] = ts.Place;
                                if (place[tsIndex] >= Distance)
                                {
                                    
                                    placeRacer[tsIndex] = placeResult.ToString();
                                    placeResult++;
                                    timeFinish[tsIndex] = Time.ToString();
                                    place[tsIndex] = Distance;
                                }
                                
                            }
                            table.AddRow(ts.Name, (Math.Round(place[tsIndex] / Distance * 100)).ToString() + "%", placeRacer[tsIndex], timeFinish[tsIndex]);
                        }
                        Time++;
                    }
                });
        }
    }
}
