using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Bot.Types.ReplyMarkups;

namespace BotTgExperiment
{
    internal class Buttons
    {
        public static IReplyMarkup GetKeyboardButtons()
        {
            return new ReplyKeyboardMarkup(new List<List<KeyboardButton>>
            {
                   new List<KeyboardButton>
                   {
                       new KeyboardButton ("О нас 🧑🏻‍💻"),
                       new KeyboardButton ("Контакты ☎️")
                   },

                   new List<KeyboardButton>
                   {
                       new KeyboardButton ("Наш прайс 📋")
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

        public static IReplyMarkup GetInlineKeyboardContacts()
        {
            return new InlineKeyboardMarkup(new List<List<InlineKeyboardButton>>
            {
                new List<InlineKeyboardButton>
                {
                    new InlineKeyboardButton("Instagram") {Url = "https://www.instagram.com" }
                }
            });
        }
    }
}
