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
            this.Keywords = new string[] {"/mostrar_tipomateriales","/agregar_tipomateriales"};
        }
        protected override bool InternalHandle(IMessage message, out string response)
        {
            if (Singleton<DataManager>.Instance.GetCompany(message.UserId) != null | Singleton<DataManager>.Instance.GetEntrepreneur(message.UserId) != null )
            {
                if(message.Text.ToLower().Equals("/mostrar_tipomateriales") )
                {
                    StringBuilder responsetemp = new StringBuilder();
                    responsetemp.Append($"{Singleton<DataManager>.Instance.GetTextToPrintMaterialType()}\n "); 
                    response = $"{responsetemp}";
                    return true;
                }
            }
            
            if (Singleton<DataManager>.Instance.GetCompany(message.UserId) != null )
            {
                if(message.Text.ToLower().Equals("/agregar_tipomateriales") )
                {
                    response = "Ingrese el nombre del Material";
                    return true;

                }
            
                Singleton<TelegramUserData>.Instance.userdata[message.UserId].Add(message.Text);
            }
            response = String.Empty ;
            return false;
        }    
    }
}

