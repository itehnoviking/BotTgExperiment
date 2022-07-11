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


        public static async Task HandleErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancelllationToken)
        {
            Console.WriteLine(Newtonsoft.Json.JsonConvert
                .SerializeObject(exception));
        }


        public static async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancelllationToken)
        {
            Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(update));

            if (update.Type == Telegram.Bot.Types.Enums.UpdateType.Message)
            {
                var message = update.Message;

                if (message.Text != null)
                {
                    if (message.Text.ToLower() == "/start")
                    {
                        await botClient.SendTextMessageAsync(message.Chat, "Добро пожаловать в наш бот!", replyMarkup: Buttons.GetKeyboardButtons());
                        return;
                    }

                    if (message.Text == "О нас 🧑🏻‍💻")
                    {
                        await botClient.SendTextMessageAsync(message.Chat, "Чиними-переустанавливаем\n  \n Честно \n  \n Быстро \n  \n Недорого!");
                        return;
                    }

                    if (message.Text == "Контакты ☎️")
                    {
                        await botClient.SendTextMessageAsync(message.Chat, "Воспользуйте удобным для вас способом:\n  \n +1111111111111 \n  \n +1111111111111",
                            replyMarkup: Buttons.GetInlineKeyboardContacts());
                        return;
                    }

                    if (message.Text == "Наш прайс 📋")
                    {
                        await botClient.SendTextMessageAsync(message.Chat, "Всё по 300!");
                        return;
                    }

                    if (message.Text == "Оставьте заявку ✅")
                    {
                        await botClient.SendTextMessageAsync(message.Chat, "Оставьте свой номер телефона и мы вам совсем скоро перезвоним:");
                    }


                    if (message.Text != "/start" &
                        message.Text != "О нас 🧑🏻‍💻" &
                        message.Text != "Контакты ☎️" &
                        message.Text != "Наш прайс 📋" &
                        message.Text != "Оставьте заявку ✅")
                    {
                        await botClient.CopyMessageAsync(-1001636182201, message.From.Id, message.MessageId);
                        await botClient.SendTextMessageAsync(message.Chat, "Спасибо! Скоро мы с вами свяжемся.");
                        return;
                    }


                }


            }
        }
    }

    


}

