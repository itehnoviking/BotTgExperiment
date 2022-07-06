using System;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Extensions.Polling;
using Telegram.Bot.Types;

namespace BotTgExperiment
{
    internal class Program
    {
        static ITelegramBotClient bot = new TelegramBotClient("TOKEN");

        public static async Task HandleUpdateAsync(ITelegramBotClient botClient,
            Update update, CancellationToken cancelllationToken)
        {
            Console.WriteLine(Newtonsoft.Json.JsonConvert
                .SerializeObject(update));

            if(update.Type == Telegram.Bot.Types.Enums.UpdateType.Message)
            {
                var message = update.Message;

                if (message.Text.ToLower() == "/start")
                {
                    await botClient.SendTextMessageAsync(message.Chat,
                        "Категорически приветствую!");
                    return;
                }

                await botClient.SendTextMessageAsync(message.Chat,
                    "Шалом!");
            }
        }

        public static async Task HandleErrorAsync(ITelegramBotClient botClient,
            Exception exception, CancellationToken cancelllationToken)
        {
            Console.WriteLine(Newtonsoft.Json.JsonConvert
                .SerializeObject(exception));
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Запущен бот " + bot.GetMeAsync().Result.FirstName);

            var cts = new CancellationTokenSource();
            var cancellationToken = cts.Token;
            var receiverOptions = new ReceiverOptions
            {
                AllowedUpdates = { }
            };

            bot.StartReceiving(
                HandleUpdateAsync,
                HandleErrorAsync,
                receiverOptions,
                cancellationToken
                );

            Console.ReadLine();
        }
    }
}
