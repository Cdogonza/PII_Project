using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace ClassLibrary
{
    /// <summary>
    /// El handler inicial, el cual modifica el estado del pedido según lo necesitado.
    /// </summary>
    public class CancellationHandler: BaseHandler
    {
        public CancellationHandler(BaseHandler next) : base(next)
        {
            this.Keywords = new string[] {"/cancel"};
        }
        protected override bool InternalHandle(IMessage message, out string response)
        {
            if(message.Text.ToLower().Equals("/cancel"))
            {  
                    Singleton<TelegramUserData>.Instance.userdata.Remove(message.UserId);
                    response = "Se cancela el proceso actual, Escribe /help para ver los comandos disponibles";
                    return true;
            }
                response = String.Empty ;
                return false;         
            }
          
        }
}



