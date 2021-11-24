using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
namespace ClassLibrary
{
    /// <summary>
    /// El handler inicial, el cual modifica el estado del pedido según lo necesitado.
    /// </summary>
    public class InitialHandler: BaseHandler
    {
        public Collection<string> TempList = new Collection<string>();
        public InitialHandler(BaseHandler next) : base(next)
        {
            this.Keywords = new string[] {"/registrarse"};
        }
        protected override bool InternalHandle(IMessage message, out string response)
        {
            
            if(message.Text.ToLower().Equals( "/registrarse") )
            {
                
               if (Singleton<DataManager>.Instance.GetEntrepreneur(message.UserId) != null | Singleton<DataManager>.Instance.GetCompany(message.UserId) != null)
                {
                    response = "Usted ya se encuentra registrado";
                    return true;
                }else
                {
                    Singleton<TelegramUserData>.Instance.userdata.Add(message.ChatId,TempList);
                   

                    response = "Registrarse como Empresa o como Emprendedor\n/Empresa\n/Emprendedor";
                    Singleton<TelegramUserData>.Instance.userdata[message.ChatId].Add(message.Text);
                    return true;
                }
            }
                
                if(Singleton<TelegramUserData>.Instance.userdata[message.ChatId].Count == 1 && message.Text.ToLower().Equals("/empresa"))
                {
                    Singleton<TelegramUserData>.Instance.userdata[message.ChatId].Add(message.Text);
                    response = "Ingrese nombre de la empresa";
                    
                    return true;
                
                }

                if(Singleton<TelegramUserData>.Instance.userdata[message.ChatId].Count == 2 && Singleton<TelegramUserData>.Instance.userdata[message.ChatId][1].ToLower().Contains("/empresa") )
                {
                    Singleton<TelegramUserData>.Instance.userdata[message.ChatId].Add(message.Text);
                    response = "Ingrese su telefon";
                    
                    return true;
                
                }
                if(Singleton<TelegramUserData>.Instance.userdata[message.ChatId].Count == 3 && Singleton<TelegramUserData>.Instance.userdata[message.ChatId][1].ToLower().Contains("/empresa") )
                {
                    Singleton<TelegramUserData>.Instance.userdata[message.ChatId].Add(message.Text);
                    response = "Ingrese Calle y Numero de puerta";
                    
                    return true;
                
                }
                if(Singleton<TelegramUserData>.Instance.userdata[message.ChatId].Count == 4 && Singleton<TelegramUserData>.Instance.userdata[message.ChatId][1].ToLower().Contains("/empresa")  )
                {
                    Singleton<TelegramUserData>.Instance.userdata[message.ChatId].Add(message.Text);
                    response = "Ingrese Ciudad";
                    
                    return true;
                
                }
                if(Singleton<TelegramUserData>.Instance.userdata[message.ChatId].Count == 5 && Singleton<TelegramUserData>.Instance.userdata[message.ChatId][1].ToLower().Contains("/empresa")  )
                {
                    Singleton<TelegramUserData>.Instance.userdata[message.ChatId].Add(message.Text);
                    response = "Ingrese Departamento";
                    
                    return true;
                
                }
                if(Singleton<TelegramUserData>.Instance.userdata[message.ChatId].Count == 6 && Singleton<TelegramUserData>.Instance.userdata[message.ChatId][1].ToLower().Contains("/empresa")  )
                {
                    Singleton<TelegramUserData>.Instance.userdata[message.ChatId].Add(message.Text);
                    response = "Ingrese Rubro de la Empresa";
                
                    return true;
              
                }
                if(Singleton<TelegramUserData>.Instance.userdata[message.ChatId].Count == 7 && Singleton<TelegramUserData>.Instance.userdata[message.ChatId][1].ToLower().Contains("/empresa")  )
                {
                    Singleton<TelegramUserData>.Instance.userdata[message.ChatId].Add(message.Text);
                     
                     LocationApiClient Loc = new LocationApiClient();
                    Location LocatioCompany =Loc.GetLocation(Singleton<TelegramUserData>.Instance.userdata[message.ChatId][3],Singleton<TelegramUserData>.Instance.userdata[message.ChatId][4],Singleton<TelegramUserData>.Instance.userdata[message.ChatId][5]);
                    Company company = new Company(message.UserId,Singleton<TelegramUserData>.Instance.userdata[message.ChatId][2],Singleton<TelegramUserData>.Instance.userdata[message.ChatId][3],LocatioCompany,Singleton<TelegramUserData>.Instance.userdata[message.ChatId][7]);
                    response = "Se Creo La Empresa";
                    return true;
                }
               
             
               

            
        response = null;
        return false;
        }
    }
}

