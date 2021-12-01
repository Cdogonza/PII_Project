using System.Collections.ObjectModel;
using System;
using Telegram.Bot.Types;
using System.Data;
using System.Text;
using System.Collections;
using System.Collections.Generic;

namespace ClassLibrary
{
    public class SearchOffersHandler : BaseHandler
    {
        /// <summary>
        /// StringBuilder con respuestas temporales, para ir guardando texto
        /// </summary>
        /// <returns></returns>
        private StringBuilder responsetemp = new StringBuilder();

        /// <summary>
        /// Lista de ofertas vacía
        /// </summary>
        /// <typeparam name="Offer"></typeparam>
        /// <returns></returns>
        List<Offer> matVacia = new List<Offer>();

        /// <summary>
        /// Lista de emprendedores vacía
        /// </summary>
        /// <typeparam name="Entrepreneur"></typeparam>
        /// <returns></returns>
        List<Entrepreneur> entVacia = new List<Entrepreneur>();

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="PermissionsHandler"/>.
        /// Procesa los mensajes /buscar_oferta, /todas_las_ofertas, /ofertas_por_palabra, /oferta_por_departamento, /oferta_por_categoria, /mis_ofertas_adquiridas, /ofertas_por_empresa, /mis_ofertas y /mis_ofertas_por_emprendimiento
        /// </summary>
        /// <param name="next">El próximo "handler".</param>
        public SearchOffersHandler(BaseHandler next) : base(next)
        {
            this.Keywords = new string[] { "/buscar_oferta", "/todas_las_ofertas", "/ofertas_por_palabra", "/oferta_por_departamento", "/oferta_por_categoria", "/mis_ofertas_adquiridas", "/ofertas_por_empresa", "/mis_ofertas", "/mis_ofertas_por_emprendimiento" };
        }
        /// <summary>
        /// Este metodo es el encargado de procesar el mensaje que le llega de telegram y enviar una respuesta
        /// </summary>
        /// <param name="message"></param>
        /// <param name="response"></param>
        /// <returns>Ofertas</returns>
        protected override bool InternalHandle(IMessage message, out string response)
        {
            if (!Singleton<TelegramUserData>.Instance.userdata.ContainsKey(message.UserId))
            {
                Singleton<TelegramUserData>.Instance.userdata.Add(message.UserId, new Collection<string>());

            }
            if (message.Text.ToLower().Equals("/buscar_oferta"))
            {
                if (Singleton<DataManager>.Instance.GetCompany(message.UserId) != null)
                {
                    Singleton<TelegramUserData>.Instance.userdata[message.UserId].Add(message.Text);
                    response = "Como empresa tienes las siguientes opciones\n/mis_ofertas_por_emprendimiento\n/mis_ofertas\n\nPara realizar otra búsqueda ingrese /buscar_oferta nuevamente";
                    return true;
                }
                if (Singleton<DataManager>.Instance.GetEntrepreneur(message.UserId) != null)
                {
                    Singleton<TelegramUserData>.Instance.userdata[message.UserId].Add(message.Text);
                    response = "Como emprendimiento tienes las siguientes opciones\n/todas_las_ofertas\n/ofertas_por_palabra\n/oferta_por_departamento\n/oferta_por_categoria\n/mis_ofertas_adquiridas\n/ofertas_por_empresa\n\nPara realizar otra búsqueda ingrese /buscar_oferta nuevamente";

                    return true;
                }
            }
            if (Singleton<TelegramUserData>.Instance.userdata[message.UserId].Count >= 1)
            {
                if (Singleton<TelegramUserData>.Instance.userdata[message.UserId][0].ToLower().Contains("/buscar_oferta"))
                {
                    Singleton<TelegramUserData>.Instance.userdata[message.UserId].Add(message.Text);//Agrego el comando ingresado por el usuario
                    if (Singleton<DataManager>.Instance.GetCompany(message.UserId) != null)
                    {
                        if (Singleton<TelegramUserData>.Instance.userdata[message.UserId][1].ToLower().Contains("/mis_ofertas_por_emprendimiento"))
                        {
                            if (Singleton<TelegramUserData>.Instance.userdata[message.UserId].Count == 3)
                            {
                                response = "Ingrese el nombre del emprendimiento";
                                return true;
                            }
                            Singleton<TelegramUserData>.Instance.userdata[message.UserId].Add(message.Text);
                            Singleton<TelegramUserData>.Instance.userdata[message.UserId].Clear();
                            string check = "";
                            Console.WriteLine("hola");
                            Singleton<DataManager>.Instance.LoadFromJsonEntrepreneur();
                            List<Entrepreneur> ent = Singleton<DataManager>.Instance.entrepreneurs;
                            if(ent.Count >= 1)
                            {
                            foreach (Entrepreneur item in ent)
                            {
                                Console.WriteLine("mierda");
                                if (item.Name.Contains(message.Text))
                                {
                                    Console.WriteLine("gfhd");
                                    check = item.Id;
                                }
                            }
                            }else
                            {
                                response = "Ningun emprendedor ha comprado ofertas se su empresa";
                                return true;
                            }
                            response = Singleton<Search>.Instance.GetMyOffersByEntrepreneur(check, message.UserId);
                            return true;
                        }
                        else if (Singleton<TelegramUserData>.Instance.userdata[message.UserId][1].ToLower().Contains("/mis_ofertas"))
                        {
                            if (Singleton<TelegramUserData>.Instance.userdata[message.UserId].Count == 3)
                            {
                                Singleton<TelegramUserData>.Instance.userdata[message.UserId].Clear();
                                response = Singleton<Search>.Instance.GetOfferByCompany(message.UserId);
                                return true;
                            }
                        }
                    }
                    if (Singleton<DataManager>.Instance.GetEntrepreneur(message.UserId) != null)
                    {
                        if (Singleton<TelegramUserData>.Instance.userdata[message.UserId][1].ToLower().Trim().Contains("/ofertas_por_palabra"))
                        {
                            if (Singleton<TelegramUserData>.Instance.userdata[message.UserId].Count == 3)
                            {
                                Singleton<OfferManager>.Instance.LoadFromJsonOffer();
                                string tags = "";
                                int cont = 0;
                                foreach (Offer item in Singleton<OfferManager>.Instance.getLista())
                                {
                                    if (item.Availability)
                                    {
                                        foreach (var item2 in item.Tags)
                                        {
                                            tags += $"{cont}-{item2}\n";
                                            cont++;
                                        }
                                    }
                                }
                                response = $"Aqui tiene algunas palabras posibles:\n" + tags;
                                return true;
                            }
                            Singleton<TelegramUserData>.Instance.userdata[message.UserId].Add(message.Text);
                            response = $"{Singleton<Search>.Instance.GetOfferByWord(message.Text.ToLower())}";
                            Singleton<TelegramUserData>.Instance.userdata[message.UserId].Clear();
                            return true;

                        }
                        else if (Singleton<TelegramUserData>.Instance.userdata[message.UserId][1].ToLower().Trim().Contains("/oferta_por_departamento"))
                        {
                            if (Singleton<TelegramUserData>.Instance.userdata[message.UserId].Count == 3)
                            {
                                response = "Ingrese el departamento";
                                return true;
                            }
                            Singleton<TelegramUserData>.Instance.userdata[message.UserId].Add(message.Text);
                            response = $"{Singleton<Search>.Instance.GetOfferByDepartment(message.Text)} ";
                            Singleton<TelegramUserData>.Instance.userdata[message.UserId].Clear();
                            return true;

                        }
                        else if (Singleton<TelegramUserData>.Instance.userdata[message.UserId][1].ToLower().Contains("/oferta_por_categoria"))
                        {

                            if (Singleton<TelegramUserData>.Instance.userdata[message.UserId].Count == 3)
                            {
                                string check = "";
                                string datosMaterial = "";
                                Singleton<OfferManager>.Instance.LoadFromJsonOffer();
                                List<Offer> mat = Singleton<OfferManager>.Instance.catalog;
                                foreach (Offer item in mat)
                                {
                                    if (!check.Equals(item.Material.Type.Name))
                                    {
                                        datosMaterial += $"{item.Idd} - {item.Material.Type.Name}\n";
                                    }
                                    check = item.Material.Type.Name;
                                }

                                mat = matVacia;
                                response = $"Seleccione el numero de una Categoria\n{datosMaterial}";
                                return true;
                            }
                            if (Singleton<TelegramUserData>.Instance.userdata[message.UserId].Count == 3)
                            {
                                Singleton<TelegramUserData>.Instance.userdata[message.UserId].Add(message.Text); //obtengo la cat qeu el user quiere      
                                response = "";

                                return true;
                            }
                            Singleton<TelegramUserData>.Instance.userdata[message.UserId].Add(message.Text);
                            Singleton<OfferManager>.Instance.LoadFromJsonOffer();
                            List<Offer> mat2 = Singleton<OfferManager>.Instance.catalog;
                            foreach (Offer item in mat2)
                            {
                                if (item.Idd == Int32.Parse(Singleton<TelegramUserData>.Instance.userdata[message.UserId][3]))
                                {
                                    response = Singleton<Search>.Instance.GetOfferByID(item.Idd);
                                    Singleton<TelegramUserData>.Instance.userdata[message.UserId].Clear();
                                    return true;
                                }
                            }
                            mat2 = matVacia;
                        }
                        else if (Singleton<TelegramUserData>.Instance.userdata[message.UserId][1].ToLower().Contains("/mis_ofertas_adquiridas"))
                        {
                            if (Singleton<TelegramUserData>.Instance.userdata[message.UserId].Count == 3)
                            {
                                Singleton<TelegramUserData>.Instance.userdata[message.UserId].Clear();
                                response = Singleton<Search>.Instance.GetOfferByEntrepreneur(message.UserId);
                                return true;
                            }
                        }
                        else if (Singleton<TelegramUserData>.Instance.userdata[message.UserId][1].ToLower().Contains("/ofertas_por_empresa"))
                        {
                            if (Singleton<TelegramUserData>.Instance.userdata[message.UserId].Count == 3)
                            {
                                response = "Ingrese el nombre de la empresa";
                                return true;
                            }
                            Singleton<TelegramUserData>.Instance.userdata[message.UserId].Add(message.Text);
                            Singleton<TelegramUserData>.Instance.userdata[message.UserId].Clear();
                            response = $"{Singleton<Search>.Instance.GetOffersPublicatedByCompany(message.Text)}  ";
                            return true;
                        }
                        else if (Singleton<TelegramUserData>.Instance.userdata[message.UserId][1].ToLower().Contains("/todas_las_ofertas"))
                        {
                            if (Singleton<TelegramUserData>.Instance.userdata[message.UserId].Count == 3)
                            {
                                Singleton<TelegramUserData>.Instance.userdata[message.UserId].Clear();
                                response = $"{Singleton<Search>.Instance.GetOffers()}   ";
                                return true;
                            }
                        }
                    }
                    else
                    {
                        response = "Debe estar ingresad@ como empresa o como emprendimiento para poder buscar ofertas\n/help";
                        return true;
                    }


                }

            }
            response = String.Empty;
            return false;

        }

    }
}