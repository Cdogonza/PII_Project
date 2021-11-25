using System;

namespace ClassLibrary
{
    /// <summary>
    /// El handler inicial, el cual modifica el estado del pedido según lo necesitado.
    /// </summary>
    public class CloseSessionHandler: BaseHandler
    {
  
        public CloseSessionHandler(BaseHandler next) : base(next)
        {
            this.Keywords = new string[] {"/salir"};
        }
        protected override bool InternalHandle(IMessage message, out string response)
        {
            Console.WriteLine("Entre a salir antes if");
            if(message.Text.ToLower().Equals("/salir"))
            {
                Console.WriteLine("Entre a salir");
                if (Singleton<TelegramUserData>.Instance.userdata.ContainsKey(message.UserId))
                {
            
                    response = $"Cerrando Session";
                    Singleton<TelegramUserData>.Instance.userdata.Remove(message.UserId);

                    return true;
                }
            }
            response = String.Empty ;
            return false;
        }
    }
}