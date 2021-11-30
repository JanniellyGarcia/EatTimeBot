using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;

namespace EatTimeBot
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;

        public Worker(ILogger<Worker> logger)
        {
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            //.ToShortTimeString()


            try
            {
                bool validation = true;
                while (validation)
                {
                    var time = DateTime.Now;
                    var time2 = time.AddHours(3);
                    if (time == time2)
                    {
                        var bot = new Telegram.Bot.TelegramBotClient("token");
                        await bot.SendTextMessageAsync("id_chat", "Hora de comer");
                        _logger.LogInformation("Teste");
                        Console.WriteLine(time2);
                    }
                }


            }
            catch (Exception e)
            {

                _logger.LogError("ERROR :", e);
            }
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}
