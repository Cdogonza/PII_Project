using System;
using System.Collections.Generic;

namespace ClassLibrary
{
    /// <summary>
    /// El handler inicial, el cual modifica el estado del pedido según lo necesitado.
    /// </summary>
    public class LocationHandler: BaseHandler
    {
  
        public LocationHandler(BaseHandler next) : base(next)
        {
            this.Keywords = new string[] {"/mapa"};
        }
        protected override bool InternalHandle(IMessage message, out string response)
        {
            
            if(message.Text.ToLower().Equals("/mapa"))
            {
                if (Singleton<DataManager>.Instance.GetCompany(message.UserId) != null)
                {
                    List<Company> lista = new List<Company>();
                   lista = Singleton<DataManager>.Instance.DataCompany();
                   foreach (var item in lista)
                   {
                       Console.WriteLine(item);
                   }
                    response = $"";
                  
                    return true;
                }
            }
            response = String.Empty ;
            return false;
        }
    }
}