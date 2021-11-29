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
    /// 
    /// </summary>
    public class AreaOfWorkHandler: BaseHandler
    {
        public AreaOfWorkHandler(BaseHandler next) : base(next)
        {
            this.Keywords = new string[] {"/rubros", "/listar_rubros", "/agregar_rubros"};
        }
        protected override bool InternalHandle(IMessage message, out string response)
        {   
            if(!Singleton<TelegramUserData>.Instance.userdata.ContainsKey(message.UserId))
            {
                Singleton<TelegramUserData>.Instance.userdata.Add(message.UserId,new Collection<string>());    
            }    
            
            if(message.Text.ToLower().Equals("/rubros"))
            {
                if(Singleton<DataManager>.Instance.GetEntrepreneur(message.UserId) != null )
                {
                    Singleton<TelegramUserData>.Instance.userdata[message.UserId].Add(message.Text);
                    response = "Usted puede ver la lista de rubros /listar_rubros";
                    return true;
                }

                if (Singleton<DataManager>.Instance.GetCompany(message.UserId) != null)
                {
                    Singleton<TelegramUserData>.Instance.userdata[message.UserId].Add(message.Text);
                    response = "Usted puede ver la lista de rubros /listar_rubros\no agregar rubros al sitema /agregar_rubros";
                    return true;
                }
            }
            if(Singleton<TelegramUserData>.Instance.userdata[message.UserId].Count >= 1  && Singleton<TelegramUserData>.Instance.userdata[message.UserId][0].ToLower().Contains("/rubros") )
            {
                if(message.Text.ToLower().Equals("/listar_rubros"))
                {
                    Console.WriteLine("Hola");
                    Singleton<TelegramUserData>.Instance.userdata.Remove(message.UserId);
                    response = Singleton<DataManager>.Instance.GetTextToPrintAreaOfWork();
                    return true;
                }

                if(message.Text.ToLower().Equals("/agregar_rubros"))
                {
                    if(Singleton<DataManager>.Instance.GetCompany(message.UserId) != null)
                    {
                        Singleton<TelegramUserData>.Instance.userdata[message.UserId].Add(message.Text);
                        response = "Ingrese el nombre del rubro";
                        return true;
                    }else
                    {
                        response = "No tiene privilegios suficientes para agregar rubros, solo las empresas pueden realizar esta acción";
                        return true;
                    }
                }

                if (Singleton<TelegramUserData>.Instance.userdata[message.UserId][1].ToLower().Contains("/agregar_rubros"))
                {
                    Console.WriteLine("seee");
                    Singleton<TelegramUserData>.Instance.userdata[message.UserId].Add(message.Text);
                    // StringBuilder responsetemp = new StringBuilder();
                    // responsetemp.Append("Se agregó el siguiente rubro: \n");
                    // for (int i = 1; i < Singleton<TelegramUserData>.Instance.userdata[message.UserId].Count; i++)
                    // {
                         Singleton<DataManager>.Instance.AddAreaOfWork(Singleton<TelegramUserData>.Instance.userdata[message.UserId][2]);
                    //     responsetemp.Append($"{Singleton<TelegramUserData>.Instance.userdata[message.UserId][i]}\n");
                    // }
                    // Singleton<TelegramUserData>.Instance.userdata.Remove(message.UserId);
                
                    response = $"Se agregó el siguiente rubro:\n{Singleton<TelegramUserData>.Instance.userdata[message.UserId][2]}";
                    return true;
                }
                
            }
            response = String.Empty ;
            return false;  
                 
        }
               
                       
    }
          
}