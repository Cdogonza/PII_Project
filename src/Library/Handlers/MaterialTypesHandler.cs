using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace ClassLibrary
{
    /// <summary>
    /// El handler inicial, el cual modifica el estado del pedido según lo necesitado.
    /// </summary>
    public class MaterialTypesHandler: BaseHandler
    {
        public MaterialTypesHandler(BaseHandler next) : base(next)
        {
            this.Keywords = new string[] {"/materialtype", "/listar", "/agregar_tipodemateriales"};
        }
        protected override bool InternalHandle(IMessage message, out string response)
        {
            Console.WriteLine($"material type {message.Text}  {message.UserId} ");
            
            if(!Singleton<TelegramUserData>.Instance.userdata.ContainsKey(message.UserId))
            {       
                    Singleton<TelegramUserData>.Instance.userdata.Add(message.UserId,new Collection<string>());    
            }

            if(message.Text.ToLower().Equals("/materialtype"))
            {  

                if(Singleton<DataManager>.Instance.GetEntrepreneur(message.UserId) != null )
                {
                    Singleton<TelegramUserData>.Instance.userdata[message.UserId].Add(message.Text);
                    response = "Usted puede listar los tipos de materiales /listar";
                    return true;
                }

                if (Singleton<DataManager>.Instance.GetCompany(message.UserId) != null)
                {
                    Singleton<TelegramUserData>.Instance.userdata[message.UserId].Add(message.Text);
                    Console.WriteLine($"0 - {Singleton<TelegramUserData>.Instance.userdata[message.UserId][0]}");
                    Console.WriteLine($"Count - {Singleton<TelegramUserData>.Instance.userdata[message.UserId].Count}");
                    response = "Usted puede listar los tipos de materiales /listar o \n agregar tipos de materiales /agregar_tipodemateriales";
                    return true;
                }
            }
            
            if(Singleton<TelegramUserData>.Instance.userdata[message.UserId].Count >= 1)
            {
                if(message.Text.ToLower().Equals("/cancel") )
                {
                    //Singleton<TelegramUserData>.Instance.userdata[message.UserId].Add(message.Text);
                    Singleton<TelegramUserData>.Instance.userdata.Remove(message.UserId);
                    response = "Se cancela el proceso actual";
                    return true;
                }
                else{    
                    if (Singleton<TelegramUserData>.Instance.userdata[message.UserId][0].ToLower().Trim().Contains("/materialtype") )
                    {
                        if(message.Text.ToLower().Equals("/listar") )
                        {
                        //Singleton<TelegramUserData>.Instance.userdata[message.UserId].Add(message.Text);
                        response = $"{Singleton<DataManager>.Instance.GetTextToPrintMaterialType()}";

                        return true;
                        }                   
                        
                        if(message.Text.ToLower().Equals("/agregar_tipodemateriales") )
                        {
                            Console.WriteLine("Entre a agregar tipo de materiales");
                            if (Singleton<DataManager>.Instance.GetCompany(message.UserId) != null )
                            {
                    
                                Console.WriteLine("matcheo");
                                Singleton<TelegramUserData>.Instance.userdata[message.UserId].Add(message.Text);
                                Console.WriteLine($"0 - {Singleton<TelegramUserData>.Instance.userdata[message.UserId][0]}");
                                Console.WriteLine($"Count - {Singleton<TelegramUserData>.Instance.userdata[message.UserId].Count}");
                                response = "Ingrese el nombre del Tipo de Material";
                                return true;
                            }
                            else
                            {
                                response = "No tiene privilegios suficientes para agregar materiales, Solo las empresas pueden agregar materiales ";
                                return true;
                            }
                        }

                        if (Singleton<TelegramUserData>.Instance.userdata[message.UserId][1].ToLower().Contains("/agregar_tipodemateriales"))
                        {
                            if(Singleton<TelegramUserData>.Instance.userdata[message.UserId].Count == 2)
                            {
                            Singleton<TelegramUserData>.Instance.userdata[message.UserId].Add(message.Text);
                            response = "Ingrese la descripcion del Tipo de Material:";
                            return true;
                            }
                            if(Singleton<TelegramUserData>.Instance.userdata[message.UserId].Count == 3)
                            {
                                Singleton<TelegramUserData>.Instance.userdata[message.UserId].Add(message.Text);
                                Singleton<DataManager>.Instance.AddMaterialType(Singleton<TelegramUserData>.Instance.userdata[message.UserId][2],Singleton<TelegramUserData>.Instance.userdata[message.UserId][3]);
                                response = $"Se creo el Tipo de material con exito - {Singleton<TelegramUserData>.Instance.userdata[message.UserId][2]} - {Singleton<TelegramUserData>.Instance.userdata[message.UserId][3]} ";

                                return true;
                            }
                        }
                    }

                }

            }
                response = String.Empty ;
                return false;         
            }
          
        }
}



