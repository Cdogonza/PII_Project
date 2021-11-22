using System;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot.Extensions.Polling;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace ClassLibrary
{
    /// <summary>
    /// Una clase que implementa un bot de Telegram.
    /// </summary>
    public class TelegramBot
    {
        // La instancia del bot.
        private static TelegramBot instance;
        private TelegramBotClient Bot;
        public static TelegramBot Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new TelegramBot();
                }
                return instance;
            }
        }

        // El token provisto por Telegram al crear el bot.
        //private string Token = "2099808385:AAGebOzNFY6kA5hwEY2XJbOJxZBzWAIM8U0";
        private string Token = "2133513418:AAHIE7L6s-OQSi6BroKBheNa-JGIXAlsMR0";
       // private string Token = "2133499409:AAFKS9VqLu7UXqQccvTHFFzcIvxwEoCGtkM";
        private static IHandler firstHandler;

        /// <summary>
        /// 
        /// </summary>
        private TelegramBot()
        {
            this.Bot = new TelegramBotClient(Token);  
        
        }
        public ITelegramBotClient Client
        {
            get
            {
                return this.Bot;
            }
        }
}
}