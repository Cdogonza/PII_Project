using Telegram.Bot.Types;

namespace ClassLibrary
{
    /// Esta clase se justifica con el patron adapter ya que implementa la interfaz que permite a la aplicación manejar diferentes clases de mensajes independiente de que canal vengan.

    public class TelegramMsgAdapter : IMessage
    {
        private string userId;
        private string chatId;
        private Message message;
        public TelegramMsgAdapter(Message message)
        {
            this.message = message;
            this.userId = message.From.Id.ToString();
            this.chatId = message.Chat.Id.ToString();
        }

        public string Text
        {
            get
            {
                return this.message.Text;
            }
            set { }
        }

        public string ChatId
        {
            get
            {
                return this.message.Chat.Id.ToString();
            }
        }

        public string UserId
        {
            get
            {
                return this.message.From.Id.ToString();
            }
        }
        public string FirstName
        {
            get
            {
                return this.message.From.FirstName.ToString();
            }
        }

    }


}