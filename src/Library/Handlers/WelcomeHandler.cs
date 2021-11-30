using System;
using Telegram.Bot.Types;
using System.Collections.ObjectModel;
using System.Data;

namespace ClassLibrary
{
    /// <summary>
    /// Este handler implementa el patrón Chain of Responsability y es el encargado de manejar el comando /start
    /// En caso de que el usuario este registrado, devuelve /help para que obtenga sus comandos disponibles.
    /// Si el usuario no esta registrado le devuelve /registrarse para que acceda al menu de registrarse.
    /// </summary>
 
    public class WelcomeHandler : BaseHandler
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="WelcomeHandler"/>.
        /// Procesa el mensaje /start
        /// </summary>
        /// <param name="next">El próximo "handler".</param>
        public WelcomeHandler(BaseHandler next) : base(next)
        {
            this.Keywords = new string[] {"/start"};
        }

        /// <summary>
        /// Este metodo es el encargado de procesar el mensaje que le llega de telegram y enviar una respuesta
        /// </summary>
        /// <param name="message"> El mensaje que llega para procesar</param>
        /// <param name="response">La respuesta del mensaje procesado </param>
        /// <returns></returns>
        protected override bool InternalHandle(IMessage message, out string response)
        {
            
            if(message.Text.ToLower().Equals( "/start"))
            {
                if(!Singleton<TelegramUserData>.Instance.userdata.ContainsKey(message.UserId))
                {
                    Singleton<TelegramUserData>.Instance.userdata.Add(message.UserId,new Collection<string>());    
                }    
                if (Singleton<DataManager>.Instance.GetEntrepreneur(message.UserId) != null | Singleton<DataManager>.Instance.GetCompany(message.UserId) != null)
                {
                    response = "Bienvenido a la Aplicación Equipo15\n Indique /help para ver los comandos disponibles";
                    return true;
                }
                else
                {    
                    response = "Bienvenido a la Aplicación Equipo15\n Indique /registrarse si desea registrarse en nuestra plataforma";
                    return true;  
                }
            }
            else
            {
                response = String.Empty;
                return false;
            }
             
        }
    }
}

