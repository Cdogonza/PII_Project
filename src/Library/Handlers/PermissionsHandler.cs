using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Text;
using Microsoft.VisualBasic;

namespace ClassLibrary
{
    /// <summary>
    /// Este handler implementa el patrón Chain of Responsability y es el encargado de manejar el comando /habilitaciones
    /// Permite agregar a las companias habilitaciones al sistema, para ser ingrersados en la oferta o ser usados por los emprendedores.
    /// </summary>
    public class PermissionsHandler: BaseHandler
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="PermissionsHandler"/>.
        /// Procesa el mensaje /habilitaciones
        /// </summary>
        /// <param name="next">El próximo "handler".</param>
        public PermissionsHandler(BaseHandler next) : base(next)
        {
            this.Keywords = new string[] {"/habilitaciones"};
        }
        
        /// <summary>
        /// Este metodo es el encargado de procesar el mensaje que le llega de telegram y enviar una respuesta
        /// </summary>
        /// <param name="message"> El mensaje que llega para procesar</param>
        /// <param name="response">La respuesta del mensaje procesado </param>
        /// <returns></returns>
        protected override bool InternalHandle(IMessage message, out string response)
        {
            if(!Singleton<TelegramUserData>.Instance.userdata.ContainsKey(message.UserId))
            {
                Singleton<TelegramUserData>.Instance.userdata.Add(message.UserId,new Collection<string>());    
            }    
            
            if(message.Text.ToLower().Equals("/habilitaciones"))
            {

                if(Singleton<DataManager>.Instance.GetEntrepreneur(message.UserId) != null )
                {
                    Singleton<TelegramUserData>.Instance.userdata[message.UserId].Add(message.Text);
                    response = "Usted no tiene privilegios para agregar habilitaciones al sistema";
                    return true;
                }

                if (Singleton<DataManager>.Instance.GetCompany(message.UserId) != null)
                {
                    Singleton<TelegramUserData>.Instance.userdata[message.UserId].Add(message.Text);
                    response = "Ingrese el nombre de la habilitación a agregar al sistema";
                    return true;
                }
            }
            if(Singleton<TelegramUserData>.Instance.userdata[message.UserId].Count >= 1  && Singleton<TelegramUserData>.Instance.userdata[message.UserId][0].ToLower().Contains("/habilitaciones") )
            {
                if(Singleton<TelegramUserData>.Instance.userdata[message.UserId][0].ToLower().Trim().Contains("/habilitaciones") )
                {
                    if(!message.Text.ToUpper().Equals("SI") && !message.Text.ToUpper().Equals("NO") )
                    {
                        Singleton<TelegramUserData>.Instance.userdata[message.UserId].Add(message.Text);
                        response = "Desea ingresar otra Habilitación? Si/No";
                        return true;                    
                    }
                    if(message.Text.ToUpper().Equals("SI"))
                    {
                        response = "Ingrese el nombre de la nueva habilitación";
                        return true;
                    }
                    else if(message.Text.ToUpper().Equals("NO"))
                    {
                        StringBuilder responsetemp = new StringBuilder();
                        responsetemp.Append("Se agregaron las siguientes habilitaciones: \n");
                        for (int i = 1; i < Singleton<TelegramUserData>.Instance.userdata[message.UserId].Count; i++)
                        {
                            Singleton<DataManager>.Instance.AddPermission(Singleton<TelegramUserData>.Instance.userdata[message.UserId][i]);
                            responsetemp.Append($"{Singleton<TelegramUserData>.Instance.userdata[message.UserId][i]}\n");
                        }
                        Singleton<TelegramUserData>.Instance.userdata.Remove(message.UserId);
                        response = $"{responsetemp}";
                        return true;
                    }
                }
            }
            response = String.Empty ;
            return false;  
                 
        }               
    }
          
}




