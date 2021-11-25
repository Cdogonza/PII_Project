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
            this.Keywords = new string[] {"/listar_tipodemateriales", "/agregar_tipodemateriales" };
        }
        protected override bool InternalHandle(IMessage message, out string response)
        {
            Console.WriteLine($"{message.Text}");
            if(!Singleton<TelegramUserData>.Instance.userdata.ContainsKey(message.UserId))
            {
                Singleton<TelegramUserData>.Instance.userdata.Add(message.UserId,new Collection<string>());    
            }
            else 
            {
          /*  Console.WriteLine("entre al IF ContainsKEY");
            if(message.Text.ToLower().Trim().Equals("/tipodemateriales") )
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

                if (Singleton<DataManager>.Instance.GetCompany(message.UserId) != null | Singleton<DataManager>.Instance.GetEntrepreneur(message.UserId) != null)
                {
                    if(message.Text.ToLower().Equals("/listar_tipodemateriales") )
                    {
                        response = $"{Singleton<DataManager>.Instance.GetTextToPrintMaterialType()}";
                        return true;
                    }   
                }
                
                if (Singleton<DataManager>.Instance.GetCompany(message.UserId) != null )
                {
                    if(message.Text.ToLower().Equals("/agregar_tipodemateriales") )
                    {
                        Singleton<TelegramUserData>.Instance.userdata[message.UserId].Add(message.Text);
                        response = "Ingrese el nombre del Material";
                        return true;
                    }
                   Console.WriteLine($"0 - {Singleton<TelegramUserData>.Instance.userdata[message.UserId][0]}");
                   Console.WriteLine($"1 - {Singleton<TelegramUserData>.Instance.userdata[message.UserId][1]}");                                
                if (Singleton<TelegramUserData>.Instance.userdata[message.UserId][0].ToLower().Trim().Equals("/agregar_tipodemateriales"))
                {
                    switch(Singleton<TelegramUserData>.Instance.userdata[message.UserId].Count)
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
                }
            }   
            }
            response = String.Empty ;
            return false;     
        }
 
}
}

