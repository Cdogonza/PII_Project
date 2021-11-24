using Telegram.Bot.Types;

namespace ClassLibrary
{
    public class TelegramMsgAdapter : IMessage
    {

        private  Message message;
        public TelegramMsgAdapter(Message message)
        {
            this.message = message;
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