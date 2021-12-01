using System.IO;
using System;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using System.Collections.ObjectModel;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.InputFiles;
using Nito.AsyncEx;
using System.Collections.Generic;

namespace ClassLibrary
{
    /// <summary>
    /// Un "handler" del patrón Chain of Responsibility que implementa los comandos /ver_mapa, /mostrar_ruta y /help.
    /// </summary>
    public class MapsHandler : BaseHandler
    {
        private TelegramBotClient bot;

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="MapsHandler"/>.
        /// </summary>
        /// <param name="next">El próximo "handler".</param>
        /// <param name="bot">El bot para enviar el mapa</param>
        public MapsHandler(TelegramBotClient bot, BaseHandler next)
            : base(new string[] { "/ver_mapa", "/help", "/mostrar_ruta" }, next)
        {
            this.bot = bot;
        }

        /// <summary>
        /// Procesa el mensaje /help y devuelve una lista de comandos.
        /// Procesa los mensajes detallados anteriormentes y devuelve el mapa correspondiente
        /// </summary>
        /// <param name="message">El mensaje a procesar.</param>
        /// <param name="response">La respuesta al mensaje procesado.</param>
        protected override bool InternalHandle(IMessage message, out string response)
        {
            if (!Singleton<TelegramUserData>.Instance.userdata.ContainsKey(message.UserId))
            {
                Singleton<TelegramUserData>.Instance.userdata.Add(message.UserId, new Collection<string>());

            }
            if (message.Text.ToLower().Equals("/help"))
            {
                if (Singleton<DataManager>.Instance.GetCompany(message.UserId) != null)
                {
                    response = "Los comandos disponibles para las empresas son\n\n/buscar_oferta\n\n/vermisdatos\n\n/registrarse\n\n/tipo_de_material\n\n/ver_mapa\n\n/publicar_oferta\n\n/habilitaciones\n\n/rubros\n\n/cancel";
                    return true;
                }
                else
                {
                    if (Singleton<DataManager>.Instance.GetEntrepreneur(message.UserId) != null)
                    {
                        response = "Los comandos disponibles para los emprendedores son\n\n/buscar_oferta\n\n/registrarse\n\n/vermisdatos\n\n/rubros\n\n/ver_mapa\n\n/como_ir\n\n/cancel";
                        return true;
                    }
                    else
                    {
                        response = "Para comenzar indique el comando /start";
                        return true;
                    }

                }

            }
            else
            {
                if (message.Text.ToLower().Equals("/como_ir"))
                {

                    if (Singleton<DataManager>.Instance.GetEntrepreneur(message.UserId) != null)
                    {
                        Singleton<TelegramUserData>.Instance.userdata[message.UserId].Add(message.Text);//agrego /mostrar_mapa
                        string answer = "";
                        Singleton<OfferManager>.Instance.LoadFromJsonOffer();
                        foreach (Offer item in Singleton<OfferManager>.Instance.getLista())
                        {
                            answer += $"{item.Idd}- {item.Name}\n";

                        }
                        response = $"Ingrese número de oferta para ver ruta\n " + answer;
                        return true;
                    }
                }
                if (Singleton<TelegramUserData>.Instance.userdata[message.UserId].Count >= 1)
                {
                    Singleton<TelegramUserData>.Instance.userdata[message.UserId].Add(message.Text);

                    if (Singleton<TelegramUserData>.Instance.userdata[message.UserId].Count >= 1)
                    {
                        double ll = 0;
                        double llo = 0;
                        Singleton<OfferManager>.Instance.LoadFromJsonOffer();
                        foreach (Offer item in Singleton<OfferManager>.Instance.getLista())
                        {
                            if (item.Idd == Convert.ToDouble(Singleton<TelegramUserData>.Instance.userdata[message.UserId][1]))
                            {

                                ll = item.Location.Latitude;
                                llo = item.Location.Longitude;

                            }
                        }
                        LocationApiClient loc = new LocationApiClient();
                        double lat = 0;
                        double log = 0;
                        string path = @"route.png";
                        List<Entrepreneur> list = new List<Entrepreneur>();
                        Singleton<DataManager>.Instance.LoadFromJsonEntrepreneur();
                        list = Singleton<DataManager>.Instance.DataEntrepeneur();
                        foreach (var item in list)
                        {
                            lat = item.Location.Latitude;
                            log = item.Location.Longitude;
                        }
                        response = $"";
                        loc.DownloadRoute(lat, log, ll, llo, path);
                        AsyncContext.Run(() => SendProfileImageRout(message));
                        Singleton<TelegramUserData>.Instance.userdata[message.UserId].Clear();
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
                            double lat = 0;
                            double log = 0;
                            int zoomLevel = 15;
                            string path = @"map.png";
                            List<Company> list = new List<Company>();
                            list = Singleton<DataManager>.Instance.DataCompany();
                            foreach (var item in list)
                            {
                                lat = item.Location.Latitude;
                                log = item.Location.Longitude;
                            }
                            response = $"";
                            loc.DownloadMap(lat, log, path, zoomLevel);
                            AsyncContext.Run(() => SendProfileImage(message));
                            return true;
                        }
                        else
                        {
                            if (Singleton<DataManager>.Instance.GetEntrepreneur(message.UserId) != null)
                            {
                                LocationApiClient loc = new LocationApiClient();
                                double lat = 0;
                                double log = 0;
                                int zoomLevel = 15;
                                string path = @"map.png";
                                List<Entrepreneur> list = new List<Entrepreneur>();
                                list = Singleton<DataManager>.Instance.DataEntrepeneur();
                                foreach (var item in list)
                                {
                                    lat = item.Location.Latitude;
                                    log = item.Location.Longitude;
                                }
                                response = $"";
                                loc.DownloadMap(lat, log, path, zoomLevel);
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
        /// Envía una imágen con la dirección de la empresa
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        private async Task SendProfileImage(IMessage message)
        {
            // Can be null during testing
            if (bot != null)
            {
                await bot.SendChatActionAsync(message.ChatId, ChatAction.UploadPhoto);
                const string filePath = @"map.png";
                using var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read);
                var fileName = filePath.Split(Path.DirectorySeparatorChar).Last();
                await bot.SendPhotoAsync(chatId: message.ChatId, photo: new InputOnlineFile(fileStream, fileName), caption: $"Dirección de la Empresa");
            }
        }

        /// <summary>
        /// Envía una imágen con la ruta a la empresa
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        private async Task SendProfileImageRout(IMessage message)
        {
            if (bot != null)
            {
                await bot.SendChatActionAsync(message.ChatId, ChatAction.UploadPhoto);
                const string filePath = @"route.png";
                using var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read);
                var fileName = filePath.Split(Path.DirectorySeparatorChar).Last();
                await bot.SendPhotoAsync(chatId: message.ChatId, photo: new InputOnlineFile(fileStream, fileName), caption: $"Camino a la Empresa");
            }
        }
    }
}