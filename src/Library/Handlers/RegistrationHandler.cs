using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
namespace ClassLibrary
{
    /// <summary>
    /// 
    /// </summary>
    public class RegistrationHandler: BaseHandler
    {
        public RegistrationHandler(BaseHandler next) : base(next)
        {
            this.Keywords = new string[] {"/registrarse"};
        }
        protected override bool InternalHandle(IMessage message, out string response)
        {
            if(!Singleton<TelegramUserData>.Instance.userdata.ContainsKey(message.UserId))
            {
                Singleton<TelegramUserData>.Instance.userdata.Add(message.UserId,new Collection<string>());    
            }    
            
            if(message.Text.ToLower().Equals("/registrarse") )
            {
                if (Singleton<DataManager>.Instance.GetEntrepreneur(message.UserId) != null | Singleton<DataManager>.Instance.GetCompany(message.UserId) != null)
                {
                    response = "Usted ya se encuentra registrad@";
                    return true;
                    }else
                    {
                        Singleton<TelegramUserData>.Instance.userdata[message.UserId].Add(message.Text.ToLower()); //Agrego /registrarse al diccionario
                        response = "Registrarse como Empresa o como Emprendedor\n/Empresa\n/Emprendedor o cancela con /cancel ";
                        return true;
                    }
            }
            
            if(Singleton<TelegramUserData>.Instance.userdata[message.UserId].Count >= 1 && Singleton<TelegramUserData>.Instance.userdata[message.UserId][0].ToLower().Contains("/registrarse") )
            {
                if(Singleton<TelegramUserData>.Instance.userdata[message.UserId][0].ToLower().Contains("/registrarse"))
                {
                   
                    if(Singleton<TelegramUserData>.Instance.userdata[message.UserId].Count >= 1 && message.Text.ToLower().Contains("/empresa"))
                    {
                        Singleton<TelegramUserData>.Instance.userdata[message.UserId].Add(message.Text.ToLower()); /// agrego texto /empresa
                        response = "Ingrese el código de invitación";
                        return true;
                    }  
                    if(message.Text.ToLower().Equals( "1234") && Singleton<TelegramUserData>.Instance.userdata[message.UserId].Count == 2)
                        {
                            Singleton<TelegramUserData>.Instance.userdata[message.UserId].Add(message.Text.ToLower());
                            response = "Ingrese el nombre de la empresa";
                            return true;
                        }
                        if(!message.Text.ToLower().Equals( "1234") && Singleton<TelegramUserData>.Instance.userdata[message.UserId].Count == 2) { 

                            response = "Código incorrecto, intente nuevamente";
                            return true;
                        }

                            switch(Singleton<TelegramUserData>.Instance.userdata[message.UserId].Count)
                            {
                                case 3:                
                                response = "Ingrese su teléfono";
                                Singleton<TelegramUserData>.Instance.userdata[message.UserId].Add(message.Text);
                                return true;

                                case 4:
                                Singleton<TelegramUserData>.Instance.userdata[message.UserId].Add(message.Text);
                                response = "Ingrese Calle y Numero de puerta";
                                return true;

                                case 5:
                                Singleton<TelegramUserData>.Instance.userdata[message.UserId].Add(message.Text);
                                response = "Ingrese Ciudad";                                
                                return true;

                                case 6:
                                Singleton<TelegramUserData>.Instance.userdata[message.UserId].Add(message.Text);
                                response = "Ingrese Departamento";                                
                                return true;

                                case 7:                  
                                Singleton<TelegramUserData>.Instance.userdata[message.UserId].Add(message.Text);
                                response = $"{Singleton<DataManager>.Instance.GetTextToPrintAreaOfWork()}";
                                return true;
                    
                                case 8:
                                Singleton<TelegramUserData>.Instance.userdata[message.UserId].Add(Singleton<DataManager>.Instance.areaofwork[Int32.Parse(message.Text)].Name);
                                
                                Singleton<DataManager>.Instance.AddCompany(message.UserId,Singleton<TelegramUserData>.Instance.userdata[message.UserId][3],Singleton<TelegramUserData>.Instance.userdata[message.UserId][4],Singleton<TelegramUserData>.Instance.userdata[message.UserId][5],Singleton<TelegramUserData>.Instance.userdata[message.UserId][6],Singleton<TelegramUserData>.Instance.userdata[message.UserId][7],Singleton<TelegramUserData>.Instance.userdata[message.UserId][8]);
                                response = $"Se creó la Empresa correctamente\n Las siguientes acciones posibles son: \n /publicar_oferta \n /vermisdatos \n /materialtype \n /habilitaciones";
                                Singleton<TelegramUserData>.Instance.userdata.Remove(message.UserId);
                                return true;
                        
                        }
                    }else if(Singleton<TelegramUserData>.Instance.userdata[message.UserId].Count == 1 && message.Text.ToLower().Trim().Equals("/emprendedor"))
                    {
                        Singleton<TelegramUserData>.Instance.userdata[message.UserId].Add(message.Text); /// agrego texto /emprendendor
                        response = "Ingrese nombre de su emprendimiento";
                        return true;                   
                    }
                
            
                    if(Singleton<TelegramUserData>.Instance.userdata[message.UserId][1].ToLower().Trim().Contains("/emprendedor"))
                    {
                        
                        switch(Singleton<TelegramUserData>.Instance.userdata[message.UserId].Count)
                        {
                            case 2:                    
                            Singleton<TelegramUserData>.Instance.userdata[message.UserId].Add(message.Text);
                            response = "Ingrese su teléfono";
                            return true;
                                                
                            case 3:
                            Singleton<TelegramUserData>.Instance.userdata[message.UserId].Add(message.Text);
                            response = "Ingrese calle y número de puerta";
                            return true;
                            
                            case 4:
                            Singleton<TelegramUserData>.Instance.userdata[message.UserId].Add(message.Text);
                            response = "Ingrese ciudad";
                            return true;
                        
                            case 5:
                            Singleton<TelegramUserData>.Instance.userdata[message.UserId].Add(message.Text);
                            response = "Ingrese departamento";
                            return true;
                        
                            case 6:                      
                            Singleton<TelegramUserData>.Instance.userdata[message.UserId].Add(message.Text);
                            response = $"{Singleton<DataManager>.Instance.GetTextToPrintAreaOfWork()}";
                            return true;
                                                        
                            case 7:
                            Singleton<TelegramUserData>.Instance.userdata[message.UserId].Add(Singleton<DataManager>.Instance.areaofwork[Int32.Parse(message.Text)].Name);
                            response = "Ingrese una especialización de su Emprendimiento";
                            return true;

                            case 8:
                            Singleton<TelegramUserData>.Instance.userdata[message.UserId].Add(message.Text);
                            response = $"Ingrese un permiso \n{Singleton<DataManager>.Instance.GetTextToPrintPermission()}";
                            return true;

                            case 9:
                            Singleton<TelegramUserData>.Instance.userdata[message.UserId].Add(Singleton<DataManager>.Instance.permissions[Int32.Parse(message.Text)].Name);
                            Singleton<DataManager>.Instance.AddEntrepreneur(message.UserId,Singleton<TelegramUserData>.Instance.userdata[message.UserId][2],Singleton<TelegramUserData>.Instance.userdata[message.UserId][3],Singleton<TelegramUserData>.Instance.userdata[message.UserId][4],Singleton<TelegramUserData>.Instance.userdata[message.UserId][5],Singleton<TelegramUserData>.Instance.userdata[message.UserId][6],Singleton<TelegramUserData>.Instance.userdata[message.UserId][7],Singleton<TelegramUserData>.Instance.userdata[message.UserId][8],Singleton<TelegramUserData>.Instance.userdata[message.UserId][9]);
                            response = "Se creó el Emprendedor correctamente\n Las siguientes acciones posibles son:\n/help";
                            Singleton<TelegramUserData>.Instance.userdata.Remove(message.UserId);                                
                            return true;
                        
                        }

                    }
                } 
              
            response = String.Empty ;
            return false;

        }
    }
}


