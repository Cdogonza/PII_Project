using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.InputFiles;
using Nito.AsyncEx;
using System.Collections.Generic;

namespace ClassLibrary
{
    /// <summary>
    /// Un "handler" del patrón Chain of Responsibility que implementa el comando "foto".
    /// </summary>
    public class MapsHandler : BaseHandler
    {
        private TelegramBotClient bot;

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="MapsHandler"/>. Esta clase procesa el mensaje "foto".
        /// </summary>
        /// <param name="next">El próximo "handler".</param>
        /// <param name="bot">El bot para enviar la foto.</param>
        public MapsHandler(TelegramBotClient bot, BaseHandler next)
            : base(new string[] { "/ver_mapa","/help","/mostrar_ruta" }, next)
        {
            this.bot = bot;
        }

        /// <summary>
        /// Procesa el mensaje "foto" y retorna true; retorna false en caso contrario.
        /// </summary>
        /// <param name="message">El mensaje a procesar.</param>
        /// <param name="response">La respuesta al mensaje procesado.</param>
        /// <returns>true si el mensaje fue procesado; false en caso contrario.</returns>
        protected override bool InternalHandle(IMessage message, out string response)
        {
            if(message.Text.ToLower().Equals("/help"))
            {
                if (Singleton<DataManager>.Instance.GetCompany(message.UserId) != null )
                {
                    response = "Los comandos disponibles para las empresas son\n/buscar_oferta\n/vermisdatos\n/registrarse\n/tipo_de_material\n/ver_mapa\n/publicar_oferta\n/habilitaciones\n/rubros\n/cerrar_sesion";
                    return true;
                }else
                {
                    if(Singleton<DataManager>.Instance.GetEntrepreneur(message.UserId) != null)
                    {
                        response = "Los comandos disponibles para los emprendedores son\n/buscar_oferta\n/registrarse\n/vermisdatos\n/rubros\n/ver_mapa\n/mostrar_ruta\n/cerrar_sesion";
                        return true;
                    }else
                    {
                        response = "Para comenzar indeque el comando /start";
                        return true;
                    }
                 
                } 
                          
            }else
            {
                if(message.Text.ToLower().Equals("/mostrar_ruta"))
                {
                    if(Singleton<DataManager>.Instance.GetEntrepreneur(message.UserId) != null)
                    {
                        LocationApiClient loc = new LocationApiClient();
                        double lat=0;
                        double log=0;                
                        string path=@"route.png";
                        List<Entrepreneur>  lista = new List<Entrepreneur>();
                        lista = Singleton<DataManager>.Instance.DataEntrepeneur();
                        foreach (var item in lista)
                        {                     
                            lat =item.Location.Latitude;
                            log=item.Location.Longitude;
                        }
                        response = $"";
                        loc.DownloadRoute(lat,log,-34.88064073732325, -56.14675630747833,path);             
                        AsyncContext.Run(() => SendProfileImageRout(message));                    
                        return true;
                    }
                }
                else
                {
                    if (this.CanHandle(message))
                    {
                        if (Singleton<DataManager>.Instance.GetCompany(message.UserId) != null)
                        {
                            LocationApiClient loc = new LocationApiClient();
                            double lat=0;
                            double log=0;
                            int zoomLevel = 15;
                            string path=@"map.png";
                            List<Company> lista = new List<Company>();
                            lista = Singleton<DataManager>.Instance.DataCompany();
                            foreach (var item in lista)
                            {   
                                lat =item.Location.Latitude;
                                log=item.Location.Longitude;
                            }
                            response = $"";
                            loc.DownloadMap(lat,log,path,zoomLevel);                          
                            AsyncContext.Run(() => SendProfileImage(message));                    
                            return true;
                        }
                        else
                        {
                            if(Singleton<DataManager>.Instance.GetEntrepreneur(message.UserId) != null)
                            {
                                LocationApiClient loc = new LocationApiClient();
                                double lat=0;
                                double log=0;
                                int zoomLevel = 15;
                                string path=@"map.png";
                                List<Entrepreneur>  lista = new List<Entrepreneur>();
                                lista = Singleton<DataManager>.Instance.DataEntrepeneur();
                                foreach (var item in lista)
                                {                     
                                    lat =item.Location.Latitude;
                                    log=item.Location.Longitude;
                                }
                            response = $"";
                            loc.DownloadMap(lat,log,path,zoomLevel);                              
                            AsyncContext.Run(() => SendProfileImage(message));                    
                            return true;
                            }
                        }
                        response = string.Empty;
                        return true;
                    }
                }
                    response = "Para ayuda indique /help para ayuda con los comandos";
                    return false;          
            }  
        }
            
        /// <summary>
        /// Envía una imagen como respuesta al mensaje recibido. Como ejemplo enviamos siempre la misma foto.
        /// </summary>
        private async Task SendProfileImage(IMessage message)
        {
            // Can be null during testing
            if (bot != null)
            {
                await bot.SendChatActionAsync(message.ChatId, ChatAction.UploadPhoto);
                const string filePath = @"map.png";
                using var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read);
                var fileName = filePath.Split(Path.DirectorySeparatorChar).Last();
                await bot.SendPhotoAsync(chatId: message.ChatId,photo: new InputOnlineFile(fileStream, fileName),caption: $"Direccion de la Empresa");
            }
        }
        private async Task SendProfileImageRout(IMessage message)
        {
            // Can be null during testing
            if (bot != null)
            {   
                await bot.SendChatActionAsync(message.ChatId, ChatAction.UploadPhoto);
                const string filePath = @"route.png";
                using var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read);
                var fileName = filePath.Split(Path.DirectorySeparatorChar).Last();
                await bot.SendPhotoAsync(chatId: message.ChatId,photo: new InputOnlineFile(fileStream, fileName),caption: $"Camino a la Empresa");
            }
        }
    }
}