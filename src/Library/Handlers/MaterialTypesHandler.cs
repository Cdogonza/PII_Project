using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace ClassLibrary
{
    /// <summary>
    /// Este handler implementa el patrón Chain of Responsability y es el encargado de manejar los comandos /tipo_de_material, /listar_tipodemateriales y /agregar_tipodemateriales
    /// Permite a las companias agregar nuevos tipos de material, y listar los tipos de materiales, a los emprendedores se les permite solamente listar los tipos de materiales.
    /// </summary>
    public class MaterialTypesHandler: BaseHandler
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="MaterialTypesHandler"/>.
        /// Procesa los mensajes /rubros, /listar_rubros, /agregar_rubros
        /// </summary>
        /// <param name="next">El próximo "handler".</param>
        public MaterialTypesHandler(BaseHandler next) : base(next)
        {
            this.Keywords = new string[] {"/tipo_de_material", "/listar_tipodemateriales", "/agregar_tipodemateriales"};
        }

        /// <summary>
        /// Este metodo es el encargado de procesar el mensaje que le llega de telegram y enviar una respuesta
        /// </summary>
        /// <param name="message"> El mensage que llega para procesar</param>
        /// <param name="response">La respuesta del mensaje procesado </param>
        /// <returns></returns>
        protected override bool InternalHandle(IMessage message, out string response)
        {
            if(!Singleton<TelegramUserData>.Instance.userdata.ContainsKey(message.UserId))
            {       
                Singleton<TelegramUserData>.Instance.userdata.Add(message.UserId,new Collection<string>());    
            }

            if(message.Text.ToLower().Equals("/tipo_de_material"))
            {  

                if(Singleton<DataManager>.Instance.GetEntrepreneur(message.UserId) != null )
                {
                    Singleton<TelegramUserData>.Instance.userdata[message.UserId].Add(message.Text);
                    response = "Usted puede listar los tipos de materiales /listar_tipodemateriales";
                    return true;
                }

                if (Singleton<DataManager>.Instance.GetCompany(message.UserId) != null)
                {
                    Singleton<TelegramUserData>.Instance.userdata[message.UserId].Add(message.Text);
                    response = "Usted puede listar los tipos de materiales /listar_tipodemateriales o \nagregar tipos de materiales /agregar_tipodemateriales";
                    return true;
                }
            }
            
            if(Singleton<TelegramUserData>.Instance.userdata[message.UserId].Count >= 1 &&Singleton<TelegramUserData>.Instance.userdata[message.UserId][0].ToLower().Contains("/tipo_de_material"))
            {
                if(message.Text.ToLower().Equals("/cancel") )
                {
                    Singleton<TelegramUserData>.Instance.userdata.Remove(message.UserId);
                    response = "Se cancela el proceso actual";
                    return true;
                }
                else{    
                    if (Singleton<TelegramUserData>.Instance.userdata[message.UserId][0].ToLower().Trim().Contains("/tipo_de_material") )
                    {
                        if(message.Text.ToLower().Equals("/listar_tipodemateriales") )
                        {
                        response = $"{Singleton<DataManager>.Instance.GetTextToPrintMaterialType()}";

                        return true;
                        }                   
                        
                        if(message.Text.ToLower().Equals("/agregar_tipodemateriales") )
                        {
                            if (Singleton<DataManager>.Instance.GetCompany(message.UserId) != null )
                            {
                    
                                Singleton<TelegramUserData>.Instance.userdata[message.UserId].Add(message.Text);
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
                                response = $"Se creó el tipo de material con éxito - {Singleton<TelegramUserData>.Instance.userdata[message.UserId][2]} - {Singleton<TelegramUserData>.Instance.userdata[message.UserId][3]} \n /help para seguir";
                                Singleton<TelegramUserData>.Instance.userdata.Remove(message.UserId);
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



