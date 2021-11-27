using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace ClassLibrary
{
    /// <summary>
    /// El handler inicial, el cual modifica el estado del pedido según lo necesitado.
    /// </summary>
    public class MaterialsHandler: BaseHandler
    {
        public MaterialsHandler(BaseHandler next) : base(next)
        {
            this.Keywords = new string[] {"/tipo_material", "/listar", "/agregar_tipodemateriales"};
        }
        protected override bool InternalHandle(IMessage message, out string response)
        {
            Console.WriteLine($"{message.Text}  {message.UserId} ");
         
            if(message.Text.ToLower().Equals("/tipo_material"))
            {
                if(!Singleton<TelegramUserData>.Instance.userdata.ContainsKey(message.UserId))
                {
                    Singleton<TelegramUserData>.Instance.userdata.Add(message.UserId,new Collection<string>());    
                }
                
                
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
            
            if(Singleton<TelegramUserData>.Instance.userdata[message.UserId][0].ToLower().Trim().Contains("/tipo_material") )
            {
                if(message.Text.ToLower().Equals("/listar") )
                {
                Singleton<TelegramUserData>.Instance.userdata[message.UserId].Add(message.Text);
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
                        response = "Ingrese el nombre del Material";
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
                        response = "Ingrese la descripción del tipo de Material:";
                        return true;
                        }
                        if(Singleton<TelegramUserData>.Instance.userdata[message.UserId].Count == 3)
                        {
                            Singleton<TelegramUserData>.Instance.userdata[message.UserId].Add(message.Text);
                            Singleton<DataManager>.Instance.AddMaterialType(Singleton<TelegramUserData>.Instance.userdata[message.UserId][2],Singleton<TelegramUserData>.Instance.userdata[message.UserId][3]);
                            response = $"Se creó el tipo de material con éxito \n - {Singleton<TelegramUserData>.Instance.userdata[message.UserId][2]} - {Singleton<TelegramUserData>.Instance.userdata[message.UserId][3]} ";
                            return true;
                        }
                    }
                }
                //if (message.Text.ToLower().Equals("/listar_tipodemateriales") | message.Text.ToLower().Equals("/agregar_tipodemateriales") )
                //{
                    //if(!Singleton<TelegramUserData>.Instance.userdata.ContainsKey(message.UserId))
                    //{
                    //    Singleton<TelegramUserData>.Instance.userdata.Add(message.UserId,new Collection<string>());    
                    //}
                
                /*  if(message.Text.ToLower().Trim().Equals("/tipodemateriales") )
                { 
                    Console.WriteLine("entre al IF ACA");
                    //  Singleton<TelegramUserData>.Instance.userdata[message.UserId].Add(message.Text);
                    if(Singleton<DataManager>.Instance.GetEntrepreneur(message.UserId) != null )
                    {
                        response = "Usted puede listar los tipos de materiales /listar_tipodemateriales";
                        return true;
                    }
                    if (Singleton<DataManager>.Instance.GetCompany(message.UserId) != null)
                    {
                        response = "Usted puede listar los tipos de materiales /listar_tipodemateriales o \n agregar tipos de materiales /agregar_tipodemateriales";
                        return true;
                    }
                    
                }
                */

                  
                        /*   switch(Singleton<TelegramUserData>.Instance.userdata[message.UserId].Count)
                        {
                        // case 1:
                        // Singleton<TelegramUserData>.Instance.userdata[message.UserId].Add(message.Text);
                        // break;
                            //response = String.Empty;
                            //return false;
                            case 1:
                        
                                Singleton<TelegramUserData>.Instance.userdata[message.UserId].Add(message.Text);
                                response = "Ingrese la descripcion del Tipo de Material:";
                                return true;
                            
                            case 2:
                                Singleton<TelegramUserData>.Instance.userdata[message.UserId].Add(message.Text);
                            // Singleton<DataManager>.Instance.AddMaterialType(Singleton<TelegramUserData>.Instance.userdata[message.UserId][1],Singleton<TelegramUserData>.Instance.userdata[message.UserId][2]);
                                response = "Se creo el Tipo de material con exito";
                                return true;
                        
                        }    
                        */
                        

                          response = String.Empty ;
                         return false;  
                 
                }
          
        }
}



