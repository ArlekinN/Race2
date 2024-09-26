using GameRace;
using Spectre.Console;
using Transports.AirRacer;
using Transports.GroundRacer;

public static class Program
{
    public static void Main(string[] args)
    {
        string typeRaceConsole = AnsiConsole.Prompt(
        new SelectionPrompt<string>()
            .Title("Какой тип транспорта может участвовать в гонке?")
            .PageSize(3)
        .AddChoices(new[] {
            "Воздушный", "Наземный", "Любой",
            }));

        AnsiConsole.Markup($"Тип гонки выбран [green]{typeRaceConsole}[/]!\n");
        TypeRace typeRace;
        switch (typeRaceConsole)
        {
            case "Воздушный":
                typeRace = TypeRace.air;
                break;
            case "Наземный":
                typeRace = TypeRace.ground;
                break;
            default:
                typeRace = TypeRace.airAndGround;
                break;
        }

        double distance;
        while (true)
        {
            try
            {
                var distConsole = AnsiConsole.Ask<string>("Введите длину трассы: ");
                distance = Convert.ToDouble(distConsole);
                try
                {
                    if (distance <= 0) throw new Exception();
                    break;
                }
                catch (Exception)
                {
                    AnsiConsole.Markup("[red]Длина должна быть больше 0![/]\n");

                } 
            }
            catch (Exception)
            {
                AnsiConsole.Markup("[red]Это не число![/]\n");
            }
 
        }
        Race race = new Race(distance, typeRace);

        while (true)
        {
            bool successRegistration = true;
            var transportsConsole = AnsiConsole.Prompt(
            new MultiSelectionPrompt<string>()
                .Title("Кто будет участвовать в заезде?")
                .PageSize(9)
                .InstructionsText(
                    "[grey](Press [blue]<space>[/] to toggle a transport, " +
                    "[green]<enter>[/] to accept)[/]")
                .AddChoices(new[] {
                    "Ступа Бабы Яги", "Метла", "Сапоги-скороходы",
                    "Карета-тыква", "Ковер-самолет", "Избушка на курьих ножках",
                    "Кентавр", "Летучий корабль",

            }));
            foreach (string transport in transportsConsole)
            {
                if (!successRegistration)
                {
                    break;
                } 
                switch (transport)
                {
                    case "Ступа Бабы Яги":
                        successRegistration = race.registration(new BabaYagaStupa());
                        break;
                    case "Метла":
                        successRegistration = race.registration(new Broom());
                        break;
                    case "Ковер-самолет":
                        successRegistration = race.registration(new MagicCarpet());
                        break;
                    case "Летучий корабль":
                        successRegistration = race.registration(new FlyingShip());
                        break;
                    case "Сапоги-скороходы":
                        successRegistration = race.registration(new WalkingBoots());
                        break;
                    case "Карета-тыква":
                        successRegistration = race.registration(new PumpkinCarriage());
                        break;
                    case "Избушка на курьих ножках":
                        successRegistration = race.registration(new HutOnChickenLegs());
                        break;
                    case "Кентавр":
                        successRegistration = race.registration(new Centaur());
                        break;
                }
            }
            if (successRegistration) break;
        }
        //race.Start();
    }

   
}



