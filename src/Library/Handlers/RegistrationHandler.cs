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
        private StringBuilder responsetemp = new StringBuilder();
        private string permiso {get; set;}
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
                var _mypermissions = Singleton<TelegramUserData>.Instance.permissionsDict;
                if (Singleton<DataManager>.Instance.GetEntrepreneur(message.UserId) != null | Singleton<DataManager>.Instance.GetCompany(message.UserId) != null)
                {
                    response = "Usted ya se encuentra registrad@";
                    return true;
                    }else
                    {
                        Singleton<TelegramUserData>.Instance.userdata[message.UserId].Add(message.Text.ToLower()); //Agrego /registrarse al diccionario
                        response = "Registrarse como Empresa o como Emprendedor\n/Empresa\n/Emprendedor\no cancela con /cancel ";
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
                    if(Singleton<TelegramUserData>.Instance.userdata[message.UserId].Count == 1 && message.Text.ToLower().Equals("/emprendedor"))
                    {
                        Singleton<TelegramUserData>.Instance.userdata[message.UserId].Add(message.Text); /// agrego texto /emprendendor
                        response = "Ingrese nombre de su emprendimiento";
                        return true;                   
                    }
                }
                    if(Singleton<TelegramUserData>.Instance.userdata[message.UserId][1].ToLower().Contains("/empresa"))
                    {  
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
                                responsetemp.Append("Ingrese el rubro de la empresa\n");
                                responsetemp.Append($"{Singleton<DataManager>.Instance.GetTextToPrintAreaOfWork()}");
                                response = $"{responsetemp}";
                                responsetemp.Clear();
                                return true;
                    
                                case 8:
                                if(Singleton<DataManager>.Instance.CheckAreaOfWork(Int16.Parse(message.Text)))
                                {
                                    Singleton<TelegramUserData>.Instance.userdata[message.UserId].Add(Singleton<DataManager>.Instance.areaofwork[Int32.Parse(message.Text)].Name);
                                    Singleton<DataManager>.Instance.AddCompany(message.UserId,Singleton<TelegramUserData>.Instance.userdata[message.UserId][3],Singleton<TelegramUserData>.Instance.userdata[message.UserId][4],Singleton<TelegramUserData>.Instance.userdata[message.UserId][5],Singleton<TelegramUserData>.Instance.userdata[message.UserId][6],Singleton<TelegramUserData>.Instance.userdata[message.UserId][7],Singleton<TelegramUserData>.Instance.userdata[message.UserId][8]);
                                    response = $"Se creó la Empresa correctamente\n \nPara ver las siguientes acciones posibles ingrese: \n /publicar_oferta \n /vermisdatos \n /materialtype \n /habilitaciones";
                                    Singleton<TelegramUserData>.Instance.userdata.Remove(message.UserId);
                                    return true;
                                }
                                else
                                {
                                    response = "Dato Mal ingresado, ingrese un numero de la lista";
                                    return true;
                                }

                        
                            }

                        }
                                 

            
                    if(Singleton<TelegramUserData>.Instance.userdata[message.UserId][1].ToLower().Contains("/emprendedor"))
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
                            if(Singleton<DataManager>.Instance.CheckAreaOfWork(Int16.Parse(message.Text)))
                            {
                                Singleton<TelegramUserData>.Instance.userdata[message.UserId].Add(Singleton<DataManager>.Instance.areaofwork[Int32.Parse(message.Text)].Name);
                                response = "Ingrese una especialización de su Emprendimiento";
                                return true;
                            }
                            else
                            {
                                response = "Dato mal ingresado, ingrese un numero de la lista";
                                return true;
                            }

                            case 8:
                            Singleton<TelegramUserData>.Instance.userdata[message.UserId].Add(message.Text);
                            response = $"Como emprendedor tiene algún permiso especial? Si/No";
                            return true;
                            

                            case 9:
                            if(message.Text.ToUpper().Equals("SI"))
                            {   
                                Singleton<TelegramUserData>.Instance.userdata[message.UserId].Add(message.Text);
                                response = $"Ingrese un permiso \n{Singleton<DataManager>.Instance.GetTextToPrintPermission()}";
                                return true;
                            }
                            else if(message.Text.ToUpper().Equals("NO"))
                            {
                                Singleton<TelegramUserData>.Instance.userdata[message.UserId].Add(message.Text);
                                response = "No se agregan permisos especiales, /continuar";   
                            }    
                            else
                            {
                                response = "Debe ingresar Si/No";
                                
                            }                 
                            return true; 
                   
                            case 10:

                            if(Singleton<TelegramUserData>.Instance.userdata[message.UserId][9].ToLower().Equals("no"))
                            {   
                                Singleton<TelegramUserData>.Instance.userdata[message.UserId].Add(message.Text);
                                this.permiso = $"{String.Empty}";
                            }
                            else if (Singleton<TelegramUserData>.Instance.userdata[message.UserId][9].ToLower().Equals("si"))
                            {
                                if (Singleton<DataManager>.Instance.CheckPermission(Int16.Parse(message.Text)))
                                {   
                                    Singleton<TelegramUserData>.Instance.userdata[message.UserId].Add(message.Text);
                                    Console.WriteLine($"{Singleton<DataManager>.Instance.GetPermissionByIndexText(Int16.Parse(message.Text))}");
                                    this.permiso = Singleton<DataManager>.Instance.GetPermissionByIndexText(Int16.Parse(message.Text));
                                }
                            }
                          
                            Console.WriteLine($"0 - {Singleton<TelegramUserData>.Instance.userdata[message.UserId][0]}");
                            Console.WriteLine($"1 - {Singleton<TelegramUserData>.Instance.userdata[message.UserId][1]}");
                            Console.WriteLine($"2 - {Singleton<TelegramUserData>.Instance.userdata[message.UserId][2]}");
                            Console.WriteLine($"3 - {Singleton<TelegramUserData>.Instance.userdata[message.UserId][3]}");
                            Console.WriteLine($"4 - {Singleton<TelegramUserData>.Instance.userdata[message.UserId][4]}");
                            Console.WriteLine($"5 - {Singleton<TelegramUserData>.Instance.userdata[message.UserId][5]}");
                            Console.WriteLine($"6 - {Singleton<TelegramUserData>.Instance.userdata[message.UserId][6]}");
                            Console.WriteLine($"7 - {Singleton<TelegramUserData>.Instance.userdata[message.UserId][7]}");
                            Console.WriteLine($"8 - {Singleton<TelegramUserData>.Instance.userdata[message.UserId][8]}");
                            Console.WriteLine($"9 - {Singleton<TelegramUserData>.Instance.userdata[message.UserId][9]}");

                            //Singleton<TelegramUserData>.Instance.userdata[message.UserId].Add(Singleton<DataManager>.Instance.permissions[Int32.Parse(message.Text)].Name);
                            Singleton<DataManager>.Instance.AddEntrepreneur(message.UserId,Singleton<TelegramUserData>.Instance.userdata[message.UserId][2],Singleton<TelegramUserData>.Instance.userdata[message.UserId][3],Singleton<TelegramUserData>.Instance.userdata[message.UserId][4],Singleton<TelegramUserData>.Instance.userdata[message.UserId][5],Singleton<TelegramUserData>.Instance.userdata[message.UserId][6],Singleton<TelegramUserData>.Instance.userdata[message.UserId][7],Singleton<TelegramUserData>.Instance.userdata[message.UserId][8],this.permiso);
                            response = "Se creó el Emprendedor correctamente\n Para ver las siguientes acciones posibles ingrese:\n/help";
                            Singleton<TelegramUserData>.Instance.userdata.Remove(message.UserId);                                
                            return true;
                            
                            }/*
                            Console.WriteLine($"0 - {Singleton<TelegramUserData>.Instance.userdata[message.UserId][0]}");
                            Console.WriteLine($"1 - {Singleton<TelegramUserData>.Instance.userdata[message.UserId][1]}");
                            Console.WriteLine($"2 - {Singleton<TelegramUserData>.Instance.userdata[message.UserId][2]}");
                            Console.WriteLine($"3 - {Singleton<TelegramUserData>.Instance.userdata[message.UserId][3]}");
                            Console.WriteLine($"4 - {Singleton<TelegramUserData>.Instance.userdata[message.UserId][4]}");
                            Console.WriteLine($"5 - {Singleton<TelegramUserData>.Instance.userdata[message.UserId][5]}");
                            Console.WriteLine($"6 - {Singleton<TelegramUserData>.Instance.userdata[message.UserId][6]}");
                            Console.WriteLine($"7 - {Singleton<TelegramUserData>.Instance.userdata[message.UserId][7]}");
                            Console.WriteLine($"8 - {Singleton<TelegramUserData>.Instance.userdata[message.UserId][8]}");
                            Console.WriteLine($"9 - {Singleton<TelegramUserData>.Instance.userdata[message.UserId][9]}");
                            //Console.WriteLine($"10 - {Singleton<TelegramUserData>.Instance.userdata[message.UserId][0]}");

*/
                        }

                    }
                    response = String.Empty ;
                    return false;
                } 

        }
}


