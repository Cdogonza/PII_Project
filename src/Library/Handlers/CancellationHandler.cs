using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace ClassLibrary
{
    /// <summary>
    /// Este handler implementa el patrón Chain of Responsability y es el encargado de manejar el comando /cancel
    /// Cuando se ejecuta el comando /cancel, 
    /// se elimina el registro del userID de los diccionarios donde se almacenan los datos temporales asociados al usuario 
    /// </summary>
    public class CancellationHandler : BaseHandler
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="CancellationHandler"/>.
        /// Procesa los mensajes /cancel
        /// </summary>
        /// <param name="next">El próximo "handler".</param>
        public CancellationHandler(BaseHandler next) : base(next)
        {
            this.Keywords = new string[] { "/cancel" };
        }

        /// <summary>
        /// Este metodo es el encargado de procesar el mensaje que le llega de telegram y enviar una respuesta
        /// </summary>
        /// <param name="message"> El mensaje que llega para procesar</param>
        /// <param name="response">La respuesta del mensaje procesado </param>
        /// <returns></returns>
        protected override bool InternalHandle(IMessage message, out string response)
        {
            if (message.Text.ToLower().Equals("/cancel"))
            {
                Singleton<TelegramUserData>.Instance.userdata.Remove(message.UserId);
                Singleton<TelegramUserData>.Instance.materialtypeDict.Remove(message.UserId);
                Singleton<TelegramUserData>.Instance.permissionsDict.Remove(message.UserId);
                response = "Se cancela el proceso actual, Escribe /help para ver los comandos disponibles";
                return true;
            }
            response = String.Empty;
            return false;
        }

    }
}



