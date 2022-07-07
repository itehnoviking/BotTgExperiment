using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Extensions.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace BotTgExperiment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Запущен бот " + BrainMethods.Bot.GetMeAsync().Result.FirstName);


            var cts = new CancellationTokenSource();
            var cancellationToken = cts.Token;
            var receiverOptions = new ReceiverOptions
            {
                AllowedUpdates = { }
            };

            BrainMethods.Bot.StartReceiving(
                BrainMethods.HandleUpdateAsync,
                BrainMethods.HandleErrorAsync,
                receiverOptions,
                cancellationToken
                );

            Console.ReadLine();
        }
    }
}
