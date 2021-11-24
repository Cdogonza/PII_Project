using System;
using Telegram.Bot.Types;
using System.Collections.ObjectModel;
using System.Data;

namespace ClassLibrary
{ 
    public class WelcomeHandler : BaseHandler
    {
        public WelcomeHandler(BaseHandler next) : base(next)
        {
            this.Keywords = new string[] {"/start"};
        }
        protected override bool InternalHandle(IMessage message, out string response)
        {
            
            if(message.Text.ToLower().Equals( "/start"))
            {
                Singleton<TelegramUserData>.Instance.userdata.Add(message.UserId,new Collection<string>());    
                //response = "Usted no se encuentra ingresado en la appliación , ingrese 1 Empresa o 2 para Emprendedor";
                response = "Bienvenido a la Aplicacion Equipo15\n Indique /registrarse si desea registrarse en nuestra plataforma";
                return true;
            }else
            {
                response = "no entendi";
                return false;
            }
             
        }
    }
}

