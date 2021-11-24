using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
namespace ClassLibrary
{
    /// <summary>
    /// El handler inicial, el cual modifica el estado del pedido según lo necesitado.
    /// </summary>
    public class RegistrationHandler: BaseHandler
    {
        public RegistrationHandler(BaseHandler next) : base(next)
        {
            this.Keywords = new string[] {"/registrarse"};
        }
        protected override bool InternalHandle(IMessage message, out string response)
        {
            if ((Singleton<TelegramUserData>.Instance.userdata.ContainsKey(message.UserId)))
            {
                if(message.Text.ToLower().Equals( "/registrarse") )
                {
                    
                if (Singleton<DataManager>.Instance.GetEntrepreneur(message.UserId) != null | Singleton<DataManager>.Instance.GetCompany(message.UserId) != null)
                    {
                        response = "Usted ya se encuentra registrado";
                        return true;
                    }else
                    {
                    
                        Singleton<TelegramUserData>.Instance.userdata[message.UserId].Add(message.Text);
                        response = "Registrarse como Empresa o como Emprendedor\n/Empresa\n/Emprendedor";
                        return true;
                    }
                }
                    
                    if(Singleton<TelegramUserData>.Instance.userdata[message.UserId].Count == 1 && message.Text.ToLower().Equals("/empresa"))
                    {
                        Singleton<TelegramUserData>.Instance.userdata[message.UserId].Add(message.Text); /// agrego texto /empresa
                        response = "Ingrese nombre de la empresa";
                        return true;
                    
                    }
                   
                    if(Singleton<TelegramUserData>.Instance.userdata[message.UserId][1].ToLower().Contains("/empresa"))
                    {
                        
                        switch(Singleton<TelegramUserData>.Instance.userdata[message.UserId].Count)
                        {
                            case 2:                    
                            Singleton<TelegramUserData>.Instance.userdata[message.UserId].Add(message.Text);
                            response = "Ingrese su telefono";
                            return true;
                        
                        
                            case 3:
                            Singleton<TelegramUserData>.Instance.userdata[message.UserId].Add(message.Text);
                            response = "Ingrese Calle y Numero de puerta";
                            return true;
                            
                            case 4:
                            Singleton<TelegramUserData>.Instance.userdata[message.UserId].Add(message.Text);
                            response = "Ingrese Ciudad";
                            
                            return true;
                        
                            case 5:
                            Singleton<TelegramUserData>.Instance.userdata[message.UserId].Add(message.Text);
                            response = "Ingrese Departamento";
                            
                            return true;
                        
                            case 6:                      
                            Singleton<TelegramUserData>.Instance.userdata[message.UserId].Add(message.Text);
                            response = "Ingrese Rubro de la Empresa";
                            
                            return true;
                    
                            case 7:
                            Singleton<TelegramUserData>.Instance.userdata[message.UserId].Add(message.Text);
                            DataManager company = new DataManager();
                            company.AddCompany(message.UserId,Singleton<TelegramUserData>.Instance.userdata[message.ChatId][2],Singleton<TelegramUserData>.Instance.userdata[message.ChatId][3],Singleton<TelegramUserData>.Instance.userdata[message.ChatId][4],Singleton<TelegramUserData>.Instance.userdata[message.ChatId][5],Singleton<TelegramUserData>.Instance.userdata[message.ChatId][6],Singleton<TelegramUserData>.Instance.userdata[message.ChatId][7]);
                            response = "Se Creo La Empresa Correctamente\n Puede ver sus datos ingresando /vermisdatos";
                            Console.WriteLine($"0 - {Singleton<TelegramUserData>.Instance.userdata[message.UserId][0]}");
                            Console.WriteLine($"1 - {Singleton<TelegramUserData>.Instance.userdata[message.UserId][1]}");
                            Console.WriteLine($"2 - {Singleton<TelegramUserData>.Instance.userdata[message.UserId][2]}");
                            Console.WriteLine($"3 - {Singleton<TelegramUserData>.Instance.userdata[message.UserId][3]}");
                            Console.WriteLine($"4 - {Singleton<TelegramUserData>.Instance.userdata[message.UserId][4]}");
                            Console.WriteLine($"5 - {Singleton<TelegramUserData>.Instance.userdata[message.UserId][5]}");
                            Console.WriteLine($"6 - {Singleton<TelegramUserData>.Instance.userdata[message.UserId][6]}");
                            Console.WriteLine($"7 - {Singleton<TelegramUserData>.Instance.userdata[message.UserId][7]}");
                            return true;
                        
                        }

                    }
            }    
                response = String.Empty ;
                return false;

            

        }
    }
}

