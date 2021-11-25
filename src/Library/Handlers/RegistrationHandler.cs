using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

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
                   
                    if(Singleton<TelegramUserData>.Instance.userdata[message.UserId].Count == 1 && message.Text.ToLower().Equals("/emprendedor"))
                    {
                        Singleton<TelegramUserData>.Instance.userdata[message.UserId].Add(message.Text); /// agrego texto /emprendendor
                        response = "Ingrese nombre de su emprendimiento";
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
                            int num = 0;
                            StringBuilder responsetemp = new StringBuilder();
                            responsetemp.Append("Ingrese Rubro de la Empresa\n ");
                            foreach (AreaOfWork areaofwork in Singleton<DataManager>.Instance.areaofwork)
                            {
                                responsetemp.Append($"{num} - {areaofwork.Name}\n "); 
                                num ++;
                            }
                            
                            response = $"{responsetemp}";
                            
                            return true;
                    
                            case 7:
                            
                            Singleton<TelegramUserData>.Instance.userdata[message.UserId].Add(Singleton<DataManager>.Instance.areaofwork[Int32.Parse(message.Text)].Name);
                            
                            Singleton<DataManager>.Instance.AddCompany(message.UserId,Singleton<TelegramUserData>.Instance.userdata[message.ChatId][2],Singleton<TelegramUserData>.Instance.userdata[message.ChatId][3],Singleton<TelegramUserData>.Instance.userdata[message.ChatId][4],Singleton<TelegramUserData>.Instance.userdata[message.ChatId][5],Singleton<TelegramUserData>.Instance.userdata[message.ChatId][6],Singleton<TelegramUserData>.Instance.userdata[message.ChatId][7]);
                            response = $"Se Creo La Empresa Correctamente\n Puede ver sus datos ingresando \n /vermisdatos \n /mostrar_materiales";
                            //Singleton<TelegramUserData>.Instance.userdata.Remove(message.UserId);
                            return true;
                        
                        }

                    }
                    if(Singleton<TelegramUserData>.Instance.userdata[message.UserId][1].ToLower().Contains("/emprendedor"))
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
                            int num = 0;
                            string responsetemp = "Ingrese Rubro de la Emprendimieno\n ";
                            foreach (AreaOfWork areaofwork in Singleton<DataManager>.Instance.areaofwork)
                            {
                                responsetemp += $"{num} - {areaofwork.Name}\n "; 
                                num ++;
                            }
                            
                            response = responsetemp;
                            
                            return true;
                            
                            case 7:
                            Singleton<TelegramUserData>.Instance.userdata[message.UserId].Add(Singleton<DataManager>.Instance.areaofwork[Int32.Parse(message.Text)].Name);
                            response = "ingrese una especializacion de la Emprendimieno";
                            return true;
                            case 8:
                            Singleton<TelegramUserData>.Instance.userdata[message.UserId].Add(message.Text);
                            int num2 = 0;
                            string responsetemp2 = "Ingrese un permiso en caso de tenerlo\n ";
                            foreach (Permission permission in Singleton<DataManager>.Instance.permissions)
                            {
                                responsetemp2 += $"{num2} - {permission.Name}\n "; 
                                num2 ++;
                            }
                            
                            response = responsetemp2;
                            
                            return true;
                            case 9:
                            Singleton<TelegramUserData>.Instance.userdata[message.UserId].Add(Singleton<DataManager>.Instance.permissions[Int32.Parse(message.Text)].Name);
                        
                            Singleton<DataManager>.Instance.AddEntrepreneur(message.UserId,Singleton<TelegramUserData>.Instance.userdata[message.UserId][2],Singleton<TelegramUserData>.Instance.userdata[message.ChatId][3],Singleton<TelegramUserData>.Instance.userdata[message.ChatId][4],Singleton<TelegramUserData>.Instance.userdata[message.ChatId][5],Singleton<TelegramUserData>.Instance.userdata[message.ChatId][6],Singleton<TelegramUserData>.Instance.userdata[message.ChatId][7],Singleton<TelegramUserData>.Instance.userdata[message.ChatId][8],Singleton<TelegramUserData>.Instance.userdata[message.ChatId][9]);
                            response = "Se Creo el Emprendedor Correctamente\n Puede ver sus datos ingresando /vermisdatos";
                            //Singleton<TelegramUserData>.Instance.userdata.Remove(message.UserId);
                            return true;
                        
                        }

                    }
            }    
            response = String.Empty ;
            return false;
        }
    }
}

