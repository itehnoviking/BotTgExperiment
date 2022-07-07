using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace BotTgExperiment
{
    class BrainMethods
    {
        public static ITelegramBotClient Bot { get; set; } = new TelegramBotClient("TOKEN");

        public static async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancelllationToken)
        {

            Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(update));

            var sb = new StringBuilder();

            var urlButton = new InlineKeyboardButton("Google");
            var urlButton2 = new InlineKeyboardButton("Yandex");

            urlButton.Url = "https://www.google.com";
            urlButton2.Url = "https://www.yandex.ru";

            InlineKeyboardButton[] buttons = new InlineKeyboardButton[] { urlButton, urlButton2 };
            InlineKeyboardMarkup buttonForStart = new InlineKeyboardMarkup(urlButton);

            InlineKeyboardMarkup inline = new InlineKeyboardMarkup(buttons);

            if (update.Type == Telegram.Bot.Types.Enums.UpdateType.Message)
            {
                var message = update.Message;

                if (message.Text.ToLower() == "/start")
                {
                    await botClient.SendTextMessageAsync(message.Chat,
                        "Категорически приветствую!", replyMarkup: buttonForStart);
                    return;
                }

                await botClient.SendTextMessageAsync(message.Chat,
                    "Шалом!", replyMarkup: inline);
            }
        }

        public static async Task HandleErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancelllationToken)
        {
            Console.WriteLine(Newtonsoft.Json.JsonConvert
                .SerializeObject(exception));
        }
    }
}
