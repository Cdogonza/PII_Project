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
    /// El handler inicial, el cual modifica el estado del pedido según lo necesitado.
    /// </summary>
    public class PermissionsHandler: BaseHandler
    {
        public PermissionsHandler(BaseHandler next) : base(next)
        {
            this.Keywords = new string[] {"/habilitaciones"};
        }
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
                        response = "Ingrese el nombre de la nueva habilitacion";
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




