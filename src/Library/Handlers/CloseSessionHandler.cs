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
            this.Keywords = new string[] {"/cerrar_sesion"};
        }
        protected override bool InternalHandle(IMessage message, out string response)
        {
            
            if(message.Text.ToLower().Equals("/cerrar_sesion"))
            {
        
                if (Singleton<TelegramUserData>.Instance.userdata.ContainsKey(message.UserId))
                {
            
                    response = $"Cerrando Sesión";

                   // Singleton<DataManager>.Instance.CloseSession();
                    Singleton<TelegramUserData>.Instance.userdata.Remove(message.UserId);
                    
                    return true;
                }
            }
            response = String.Empty ;
            return false;
        }
    }
}