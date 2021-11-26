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
                    LocationApiClient loc = new LocationApiClient();
                    double lat=0;
                    double log=0;
                    int zoomLevel = 15;
                    string path=@"C:\Users\gpaz\Desktop\PII_2021_2_Equipo15\Assets\map.png";
                    List<Company> lista = new List<Company>();
                    lista = Singleton<DataManager>.Instance.DataCompany();
                   foreach (var item in lista)
                   {
                      
                       lat =item.Location.Latitude;
                       log=item.Location.Longitude;
                   }
                     loc.DownloadMap(lat,log,path,zoomLevel);
                    response = $"Descargando mapa";                  
                    message.Text = "foto";                   
                    return true;
                }
            }
            response = String.Empty ;
            return false;
        }
        
            }
}