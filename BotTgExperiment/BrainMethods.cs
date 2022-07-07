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

            if (update.Type == Telegram.Bot.Types.Enums.UpdateType.Message)
            {
                var message = update.Message;


                if (message.Text != null)
                {
                    await botClient.SendTextMessageAsync(message.Chat, "Читаю вас 👍", replyMarkup: GetKeyboardButtons());

                    if (message.Text == "Контакты ☎️")
                    {
                        await botClient.SendTextMessageAsync(message.Chat, "Воспользуйте удобным для вас способом:\n  \n +1111111111111 \n  \n +1111111111111", 
                            replyMarkup: GetInlineKeyboardContacts());
                        return;
                    }
                }
                else
                {
                    await botClient.SendTextMessageAsync(message.Chat, "Я не совсем вас понял...", replyMarkup: GetKeyboardButtons());
                }

                //await botClient.SendTextMessageAsync(message.Chat, message.Text, replyMarkup: GetKeyboardButtons());

                //if (message.Text.ToLower() == "/start")
                //{
                //    await botClient.SendTextMessageAsync(message.Chat,
                //        "Категорически приветствую!", replyMarkup: GetKeyboardButtons());
                //    return;
                //}

            }
        }

        public static async Task HandleErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancelllationToken)
        {
            Console.WriteLine(Newtonsoft.Json.JsonConvert
                .SerializeObject(exception));
        }

        private static IReplyMarkup GetKeyboardButtons()
        {
            return new ReplyKeyboardMarkup(new List<List<KeyboardButton>>
            {
                   new List<KeyboardButton>
                   {
                       new KeyboardButton ("О нас 📋"),
                       new KeyboardButton ("Контакты ☎️")
                   },
            
                   new List<KeyboardButton>
                   {
                       new KeyboardButton ("Оставьте заявку ✅")
                   }
            })
                   {
                       ResizeKeyboard = true
                   };
        }

        private static IReplyMarkup GetInlineKeyboardContacts()
        {
            return new InlineKeyboardMarkup(new List<List<InlineKeyboardButton>>
            {
                //new List<InlineKeyboardButton>
                //{
                //    new InlineKeyboardButton("+1111111112"){ },
                //    new InlineKeyboardButton("+2222222222"){CallbackData = "+2222222222" }
                //},

                new List<InlineKeyboardButton>
                {
                    new InlineKeyboardButton("Instagram") {Url = "https://www.instagram.com" }
                }
            });
        }

        private static IReplyMarkup GetInlineKeyboardSearch()
        {
            return new InlineKeyboardMarkup(new List<List<InlineKeyboardButton>>
            {
                new List<InlineKeyboardButton>
                {
                    new InlineKeyboardButton("Google") {Url = "https://www.google.com" },
                    new InlineKeyboardButton("Yandex") { Url = "https://www.yandex.ru" }
                }
            });
        }
    }
}
