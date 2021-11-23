using System;
using Telegram.Bot.Types;
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

