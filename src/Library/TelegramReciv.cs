using System;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot.Extensions.Polling;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Args;

namespace ClassLibrary
{
    public class TelegramReciv : IRecive
    {
         private TelegramBot TelegramBot{set; get; }
        private ITelegramBotClient Bot{get; set; }
        private bool receiving;
      public TelegramReciv()
     
      {
        this.TelegramBot = TelegramBot.Instance;
        this.Bot = TelegramBot.Client;
        Bot.OnMessage += OnMessage;
        
      }
        public void StartRecive()
        {
            Bot.StartReceiving();
            this.receiving = true;
            Console.WriteLine("Se empiezan a recibir los mensajes");
        }
        public void StopRecive()
        {
            Bot.StopReceiving();
            this.receiving = false;
            Console.WriteLine("Se dejan de recibir los mensajes");
        }
        public bool IsRecive()
        {
            return receiving;
        }
        private static void OnMessage(object sender, MessageEventArgs messageEventArgs)
        {
            Message message = messageEventArgs.Message;
            Chat chatInfo = message.Chat;
            string messageText = message.Text;
            UserTelegramBot actualUser = UsersManager.Instance.GetTelegramUser(chatInfo.Id);

            BotBase.Instance.GetInput(actualUser.Id, messageText);
        }
        
    }
}