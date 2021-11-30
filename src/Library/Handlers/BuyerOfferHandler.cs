using System.Collections.ObjectModel;
using System;
using Telegram.Bot.Types;
using System.Data;
using System.Text;
using System.Collections;
using System.Collections.Generic;

namespace ClassLibrary
{
    public class BuyerOfferHandler : BaseHandler
    {
        /// <summary>
        /// Lista de ofertas vacías, se utiliza para guardar las ofertas compradas
        /// </summary>
        /// <typeparam name="Offer"></typeparam>
        /// <returns></returns>
        List<Offer> emptyList = new List<Offer>();

        /// <summary>
        /// Este handler implementa el patrón Chain of Responsability y es el encargado de manejar el comando /obtener_oferta
        /// Al ingresar ese comando se elige la oferta a adquirir y luego la misma aparece como inhabilitada y con el emprendedor que la adquirió en sus datos.
        /// </summary>
        /// <param name="next"></param>
        /// <returns></returns>
        public BuyerOfferHandler(BaseHandler next) : base(next)
        {
            this.Keywords = new string[] { "/obtener_oferta" };
        }

        /// <summary>
        /// Este método es el encargado de procesar el mensaje que le llega de telegram y enviar una respuesta
        /// </summary>
        /// <param name="message"></param>
        /// <param name="response"></param>
        /// <returns></returns>
        protected override bool InternalHandle(IMessage message, out string response)
        {
            if (!Singleton<TelegramUserData>.Instance.userdata.ContainsKey(message.UserId))
            {
                Singleton<TelegramUserData>.Instance.userdata.Add(message.UserId, new Collection<string>());
            }
            if (message.Text.ToLower().Equals("/obtener_oferta"))
            {
                if (Singleton<Search>.Instance.purchased.Count == 0)
                {
                    response = "Debes listar las ofertas para comprarlas utiliza\n /buscar_oferta";
                    return true;
                }
                if (Singleton<DataManager>.Instance.GetCompany(message.UserId) != null)
                {
                    response = "Como Empresa no tienes permiso para obtener ofertas";
                    return true;
                }
                if (Singleton<DataManager>.Instance.GetEntrepreneur(message.UserId) != null)
                {
                    Singleton<TelegramUserData>.Instance.userdata[message.UserId].Add(message.Text);   //Agrego /buscar_oferta
                    response = "Ingrese el número de compra que desea obtener";
                    return true;
                }
            }
            if (Singleton<TelegramUserData>.Instance.userdata[message.UserId].Count >= 1 && Singleton<TelegramUserData>.Instance.userdata[message.UserId].Count < 2)
            {
                Singleton<TelegramUserData>.Instance.userdata[message.UserId].Add(message.Text);   //Agrego /buscar_oferta
                if (Singleton<TelegramUserData>.Instance.userdata[message.UserId][0].ToLower().Contains("/obtener_oferta"))
                {
                    string data = $"";
                    int cont = 0;
                    foreach (Offer offer in Singleton<Search>.Instance.purchased)
                    {
                        cont++;
                        if (offer.Idd == Convert.ToInt64(Singleton<TelegramUserData>.Instance.userdata[message.UserId][1]))
                        {
                            data += $"{offer.Idd}) Oferta:{offer.Name}\n  - Material: {offer.Material.Name}\n  - Costo: {offer.Cost}\n  - Fecha de publicación: {offer.PublicationDate}\n  - Dirección: {offer.Location.FormattedAddress}";
                        }
                        else if (cont == Singleton<Search>.Instance.purchased.Count)
                        {
                            response = $"No encuentro el número ingresado /buscar_oferta";
                            Singleton<TelegramUserData>.Instance.userdata[message.UserId].Clear();
                            return true;
                        }
                    }
                    response = $"Confirma que desea obtener esta oferta?\n {data}\n\n Si/No";
                    Singleton<Search>.Instance.purchased = emptyList;
                    return true;
                }
            }
            if (Singleton<TelegramUserData>.Instance.userdata[message.UserId].Count >= 1 && Singleton<TelegramUserData>.Instance.userdata[message.UserId][0].ToLower().Contains("/obtener_oferta"))
            {

                Singleton<TelegramUserData>.Instance.userdata[message.UserId].Add(message.Text.ToLower());

                if (Singleton<TelegramUserData>.Instance.userdata[message.UserId][2].ToLower().Contains("si"))
                {
                    Singleton<OfferManager>.Instance.BuyOffer(Singleton<TelegramUserData>.Instance.user(), Convert.ToInt64(Singleton<TelegramUserData>.Instance.userdata[message.UserId][1]));
                    Singleton<TelegramUserData>.Instance.userdata[message.UserId].Clear();
                    response = $"Felicitaciones! Su compra ha sido realizada con éxito\n/help para continuar\n /como_ir para mostrar mapa";
                    return true;
                }
                else if (Singleton<TelegramUserData>.Instance.userdata[message.UserId][2].ToLower().Equals("no"))
                {
                    response = $"Operación Cancelada";
                    Singleton<TelegramUserData>.Instance.userdata[message.UserId].Clear();
                    return true;
                }
            }

            response = String.Empty;
            return false;
        }
    }
}


