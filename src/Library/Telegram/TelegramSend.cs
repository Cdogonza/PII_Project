using Telegram.Bot;

namespace ClassLibrary
{
    public class TelegramSend : ISend
    {
            public async void SendMessage(long id, string message)
        {
          
            ITelegramBotClient client = TelegramBot.Instance.Client;
            await client.SendTextMessageAsync(chatId: id, text: message);
        
        }



    }




}