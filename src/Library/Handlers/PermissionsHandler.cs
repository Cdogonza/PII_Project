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
            Console.WriteLine($" permission {message.Text}  {message.UserId} ");
            
            if(!Singleton<TelegramUserData>.Instance.userdata.ContainsKey(message.UserId))
            {
                Singleton<TelegramUserData>.Instance.userdata.Add(message.UserId,new Collection<string>());    
            }    
            
            if(message.Text.ToLower().Equals("/habilitaciones"))
            {


                if(Singleton<DataManager>.Instance.GetEntrepreneur(message.UserId) != null )
                {
                  //  Singleton<TelegramUserData>.Instance.userdata[message.UserId].Add(message.Text);
                    response = "Usted No tiene privilegios para agregar habilitaciones al sistema";
                    return true;
                }

                if (Singleton<DataManager>.Instance.GetCompany(message.UserId) != null)
                {
                    Singleton<TelegramUserData>.Instance.userdata[message.UserId].Add(message.Text);
                   // Console.WriteLine($"0 - {Singleton<TelegramUserData>.Instance.userdata[message.UserId][0]}");
                    //Console.WriteLine($"Count - {Singleton<TelegramUserData>.Instance.userdata[message.UserId].Count}");
                    response = "Ingrese el nombre de la habilitacion a agregar al sistema";
                    return true;
                }
            }
            if(Singleton<TelegramUserData>.Instance.userdata[message.UserId].Count >= 1)
            {
                if(Singleton<TelegramUserData>.Instance.userdata[message.UserId][0].ToLower().Trim().Contains("/habilitaciones") )
                {
                    if(!message.Text.ToUpper().Equals("Y") && !message.Text.ToUpper().Equals("N") )
                    {
                        Singleton<TelegramUserData>.Instance.userdata[message.UserId].Add(message.Text);
                        response = "Desea ingresar otra Habilitacion Y/N";
                        return true;                    
                    }
                    if(message.Text.ToUpper().Equals("Y"))
                    {
                        //Singleton<TelegramUserData>.Instance.userdata[message.UserId].Add(message.Text);
                        response = "Ingrese el nombre de la nueva habilitacion";
                        return true;
                    }
                    else if(message.Text.ToUpper().Equals("N"))
                    {
                        Console.WriteLine("Entre en el elseIF N");
                        StringBuilder responsetemp = new StringBuilder();
                        responsetemp.Append("Se agregaron las siguientes habilitaciones: \n");
                        for (int i = 1; i < Singleton<TelegramUserData>.Instance.userdata[message.UserId].Count; i++)
                        {
                            Console.WriteLine($"{Singleton<TelegramUserData>.Instance.userdata[message.UserId][i]}");
                            Singleton<DataManager>.Instance.AddPermission(Singleton<TelegramUserData>.Instance.userdata[message.UserId][i]);
                            responsetemp.Append($"{Singleton<TelegramUserData>.Instance.userdata[message.UserId][i]}\n");
                        }
                        Singleton<TelegramUserData>.Instance.userdata.Remove(message.UserId);
                        //Singleton<TelegramUserData>.Instance.userdata.Add(message.UserId,new Collection<string>());
                        response = $"{responsetemp}";
                        return true;
                    }
                }
            }
               /* if(Singleton<TelegramUserData>.Instance.userdata[message.UserId].Count == 1)
                {
                    Singleton<TelegramUserData>.Instance.userdata[message.UserId].Add(message.Text);
                    response = "Desea ingresar otra Habilitacion Y/N";
                    return true;
                }        
                */
            response = String.Empty ;
            return false;  
                 
        }
               
                       
    }
          
}




