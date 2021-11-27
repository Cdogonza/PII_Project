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

                    if (Singleton<DataManager>.Instance.GetEntrepreneur(message.UserId) != null | Singleton<DataManager>.Instance.GetCompany(message.UserId) != null){
                        response = "Usted ya se encuentra registrad@";
                        return true;
                        }else
                        {
                            Singleton<TelegramUserData>.Instance.userdata[message.UserId].Add(message.Text);
                            response = "Registrarse como Empresa o como Emprendedor\n/Empresa\n/Emprendedor";
                            return true;
                        }
                }
                    
                if(Singleton<TelegramUserData>.Instance.userdata[message.UserId][0].ToLower().Trim().Equals("/registrarse"))
                {
                    if(Singleton<TelegramUserData>.Instance.userdata[message.UserId].Count == 1 && message.Text.ToLower().Equals("/empresa"))
                    {
                        Singleton<TelegramUserData>.Instance.userdata[message.UserId].Add(message.Text); /// agrego texto /empresa
                        response = "Ingrese el código de invitación";
                        return true;
                    }

                    if(Singleton<TelegramUserData>.Instance.userdata[message.UserId].Count == 1 && message.Text.ToLower().Equals("/emprendedor"))
                    {
                        Singleton<TelegramUserData>.Instance.userdata[message.UserId].Add(message.Text); /// agrego texto /emprendendor
                        response = "Ingrese el nombre de su emprendimiento";
                        return true;
                    }

                    if(Singleton<TelegramUserData>.Instance.userdata[message.UserId][1].ToLower().Contains("/empresa"))
                    {
                        if(message.Text.ToLower().Equals( "1234") && Singleton<TelegramUserData>.Instance.userdata[message.UserId].Count == 2)
                        {
                            Singleton<TelegramUserData>.Instance.userdata[message.UserId].Add(message.Text);
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
                                /*
                                int num = 0;
                                StringBuilder responsetemp = new StringBuilder();
                                responsetemp.Append("Ingrese Rubro de la Empresa\n ");
                                foreach (AreaOfWork areaofwork in Singleton<DataManager>.Instance.areaofwork)
                                {
                                    responsetemp.Append($"{num} - {areaofwork.Name}\n "); 
                                    num ++;
                                }
                                
                                response = $"{responsetemp}";
                                    */
                                response = $"{Singleton<DataManager>.Instance.GetTextToPrintAreaOfWork()}";
                                return true;

                                case 8:
                                Singleton<TelegramUserData>.Instance.userdata[message.UserId].Add(Singleton<DataManager>.Instance.areaofwork[Int32.Parse(message.Text)].Name);
                                
                                Singleton<DataManager>.Instance.AddCompany(message.UserId,Singleton<TelegramUserData>.Instance.userdata[message.UserId][3],Singleton<TelegramUserData>.Instance.userdata[message.UserId][4],Singleton<TelegramUserData>.Instance.userdata[message.UserId][5],Singleton<TelegramUserData>.Instance.userdata[message.UserId][6],Singleton<TelegramUserData>.Instance.userdata[message.UserId][7],Singleton<TelegramUserData>.Instance.userdata[message.UserId][8]);
                                response = $"Se Creo La Empresa Correctamente\n Puede ver sus datos ingresando \n /vermisdatos \n /tipo_material";
                                //Console.WriteLine($"0 - {Singleton<TelegramUserData>.Instance.userdata[message.UserId][0]}");
                                //Console.WriteLine($"1 - {Singleton<TelegramUserData>.Instance.userdata[message.UserId][1]}");
                                //Console.WriteLine($"2 - {Singleton<TelegramUserData>.Instance.userdata[message.UserId][2]}");
                                //Console.WriteLine($"3 - {Singleton<TelegramUserData>.Instance.userdata[message.UserId][3]}");
                                //Console.WriteLine($"4 - {Singleton<TelegramUserData>.Instance.userdata[message.UserId][4]}");
                                //Console.WriteLine($"5 - {Singleton<TelegramUserData>.Instance.userdata[message.UserId][5]}");
                                //Console.WriteLine($"6 - {Singleton<TelegramUserData>.Instance.userdata[message.UserId][6]}");
                                //Console.WriteLine($"7 - {Singleton<TelegramUserData>.Instance.userdata[message.UserId][7]}");
                                //Singleton<TelegramUserData>.Instance.userdata[message.UserId].Clear();
                                Singleton<TelegramUserData>.Instance.userdata.Remove(message.UserId);
                                // Singleton<TelegramUserData>.Instance.userdata.Add(message.UserId,new Collection<string>());
                                Console.WriteLine($"Registration USERID - {message.UserId}");
                                return true;
                            }

                        }

                        if(Singleton<TelegramUserData>.Instance.userdata[message.UserId][1].ToLower().Trim().Equals("/emprendedor"))
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
                                response = $"{Singleton<DataManager>.Instance.GetTextToPrintAreaOfWork()}";
                                return true;
                                                            
                                case 7:
                                Singleton<TelegramUserData>.Instance.userdata[message.UserId].Add(Singleton<DataManager>.Instance.areaofwork[Int32.Parse(message.Text)].Name);
                                response = "Ingrese una especialización de su Emprendimiento";
                                return true;

                                case 8:
                                Singleton<TelegramUserData>.Instance.userdata[message.UserId].Add(message.Text);
                                response = $"Ingrese un permiso. \n{Singleton<DataManager>.Instance.GetTextToPrintPermission()}";
                                return true;

                                case 9:
                                Singleton<TelegramUserData>.Instance.userdata[message.UserId].Add(Singleton<DataManager>.Instance.permissions[Int32.Parse(message.Text)].Name);
                                Singleton<DataManager>.Instance.AddEntrepreneur(message.UserId,Singleton<TelegramUserData>.Instance.userdata[message.UserId][2],Singleton<TelegramUserData>.Instance.userdata[message.UserId][3],Singleton<TelegramUserData>.Instance.userdata[message.UserId][4],Singleton<TelegramUserData>.Instance.userdata[message.UserId][5],Singleton<TelegramUserData>.Instance.userdata[message.UserId][6],Singleton<TelegramUserData>.Instance.userdata[message.UserId][7],Singleton<TelegramUserData>.Instance.userdata[message.UserId][8],Singleton<TelegramUserData>.Instance.userdata[message.UserId][9]);
                                response = "Se Creo el Emprendedor Correctamente\n Puede ver sus datos ingresando /vermisdatos /tipo_material";
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
                                Singleton<TelegramUserData>.Instance.userdata.Remove(message.UserId);
                                //Singleton<TelegramUserData>.Instance.userdata[message.UserId].Clear();
                                Console.WriteLine($"Registration USERID - {message.UserId}");
                                return true;
                            
                            }

                        }
                }
                
            }
            response = String.Empty ;
            return false;
        }
    }
}
