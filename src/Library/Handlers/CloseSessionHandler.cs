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
            this.Keywords = new string[] {"/cerrar_session"};
        }
        protected override bool InternalHandle(IMessage message, out string response)
        {
            
            if(message.Text.ToLower().Equals("/cerrar_session"))
            {
        
                if (Singleton<TelegramUserData>.Instance.userdata.ContainsKey(message.UserId))
                {
            
                    response = $"Cerrando Session";

                    Singleton<DataManager>.Instance.DataCompany();
                    Singleton<TelegramUserData>.Instance.userdata.Remove(message.UserId);
                    
                    return true;
                }
            }
            response = String.Empty ;
            return false;
        }
    }
}