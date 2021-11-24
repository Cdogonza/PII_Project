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
            this.Keywords = new string[] {"/mostrar_materiales"};
        }
        protected override bool InternalHandle(IMessage message, out string response)
        {
            Console.WriteLine("No entro en el if");
            Console.WriteLine($"{Singleton<DataManager>.Instance.GetCompany(message.UserId)}");
            if (Singleton<DataManager>.Instance.GetCompany(message.UserId) != null)
            {
                if(message.Text.ToLower().Equals("/mostrar_materiales") )
                {
                    Console.WriteLine("Entre en materiales");            
                    int num = 0;
                    StringBuilder responsetemp = new StringBuilder();
                    responsetemp.Append("A continuacion se muestran los tipos de materiales disponibles:\n ");
                  //  Singleton<DataManager>.Instance.GetTextToPrintMaterialType();  
                    responsetemp.Append($"{Singleton<DataManager>.Instance.GetTextToPrintMaterialType()}\n "); 
                    response = $"{responsetemp}";
                    return true;
                }
            }
            response = String.Empty ;
            return false;
        }    
    }
}

