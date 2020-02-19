using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace LemonadeStand_3DayStarter
{
    class Program
    {
        static void Main(string[] args)
        {
            //Game game = new Game();
            //game.StartGame();
            WeatherData weather = new WeatherData("Milwaukee", 0);
            weather.CheckWeather();
            Console.WriteLine("Todays forecast in Milwaukee\n\n" + weather.Condition + "\n\nTemperature: " + weather.Temperature);
            Console.ReadKey();
        }
    }
}
