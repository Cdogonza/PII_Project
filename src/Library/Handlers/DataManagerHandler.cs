using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
namespace ClassLibrary
{

    /// <summary>
    /// Este handler implementa el patrón Chain of Responsability y es el encargado de manejar el comando /vermisdatos
    /// En caso de que el usuario sea del Tipo Compania, despliega los datos del usuario asociados a este tipo,
    /// Si es del Tipo Emprendedor, despliega los datos del emprendedor asociados a este tipo
    /// </summary>
    public class DataManagerHandler: BaseHandler
    {

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="DataManagerHandler"/>.
        /// Procesa el mensaje /vermisdatos
        /// </summary>
        /// <param name="next">El próximo "handler".</param> 
        public DataManagerHandler(BaseHandler next) : base(next)
        {
            this.Keywords = new string[] {"/vermisdatos"};
        }

        /// <summary>
        /// Este metodo es el encargado de procesar el mensaje que le llega de telegram y enviar una respuesta
        /// </summary>
        /// <param name="message"> El mensaje que llega para procesar</param>
        /// <param name="response">La respuesta del mensaje procesado </param>
        /// <returns></returns>
        protected override bool InternalHandle(IMessage message, out string response)
        {
            if(message.Text.ToLower().Equals("/vermisdatos"))
            {
             if (Singleton<DataManager>.Instance.GetCompany(message.UserId) != null)
                {
                   
                    response= Singleton<DataManager>.Instance.GetCompany(message.UserId);
                    return true;
                }
                else
                {
                    if(Singleton<DataManager>.Instance.GetEntrepreneur(message.UserId) != null)
                    {
                        
                        response= Singleton<DataManager>.Instance.GetEntrepreneur(message.UserId);
                        return true;
                     }
                }         
            }
            response= String.Empty ;
            return false;
        }
}
}