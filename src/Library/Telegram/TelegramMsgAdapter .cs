using Telegram.Bot.Types;

namespace ClassLibrary
{
    public class TelegramMsgAdapter : IMessage
    {
        private long userId;
        private string chatId;
        private  Message message;
        public TelegramMsgAdapter(Message message)
        {
            this.message = message;
            this.userId = message.From.Id;
            this.chatId = message.Chat.Id.ToString();
        }

        public string Text
        {
            get
            {
                return this.message.Text;
            }
        }
    
        public string ChatId
        {
            get
            {
                return this.message.Chat.Id.ToString();
            }
        }

        public long UserId
        {
            get
            {
                return this.message.From.Id;
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