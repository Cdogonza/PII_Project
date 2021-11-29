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
        
        List<Offer> matVacia = new List<Offer>();
        public BuyerOfferHandler(BaseHandler next) : base(next)
        {
            this.Keywords = new string[] {"/obtener_oferta"};
        }
            protected override bool InternalHandle(IMessage message, out string response)
            {
                if(!Singleton<TelegramUserData>.Instance.userdata.ContainsKey(message.UserId))
                {
                    Singleton<TelegramUserData>.Instance.userdata.Add(message.UserId,new Collection<string>());                   
                }
                if(message.Text.ToLower().Equals("/obtener_oferta"))
                {
                                       
                    if(Singleton<DataManager>.Instance.GetCompany(message.UserId) != null)
                    {
                        
                        response = "Como Company no tienes permiso para obtener ofertas";
                        return true;
                    }
                    if(Singleton<DataManager>.Instance.GetEntrepreneur(message.UserId) != null)
                    {
                        Singleton<TelegramUserData>.Instance.userdata[message.UserId].Add(message.Text);   //Agrego /buscar_oferta
                        response = "Ingrese el Numero de compra que desea obtener";                       
                        return true; 
                    }
                }
                if(Singleton<TelegramUserData>.Instance.userdata[message.UserId].Count >= 1 && Singleton<TelegramUserData>.Instance.userdata[message.UserId].Count<2)
                    {
                        Singleton<TelegramUserData>.Instance.userdata[message.UserId].Add(message.Text);   //Agrego /buscar_oferta
                        if(Singleton<TelegramUserData>.Instance.userdata[message.UserId][0].ToLower().Contains("/obtener_oferta"))
                        {                          
                            string data = $"";
                            foreach (Offer offer in Singleton<Search>.Instance.purchased)
                            {
                                if (offer.Idd==Int32.Parse(Singleton<TelegramUserData>.Instance.userdata[message.UserId][1]))
                                {
                                
                                 data += $"{offer.Idd}- Oferta:{offer.Name}-\n Material: {offer.Material.Name}-\nCosto: {offer.Cost}-\nFecha Publicacion{offer.PublicationDate}-\nDireccion: {offer.Location.FormattedAddress}";
                                                                
                                }else{response=$"No encuentro el numero ingresado /buscar_oferta";
                                Singleton<TelegramUserData>.Instance.userdata[message.UserId].Clear();
                                return true;
                                }
                            }
                            response=$"Confirma que desea obtener la esta oferta?\n {data} S/N";
                            Console.WriteLine(Singleton<TelegramUserData>.Instance.userdata[message.UserId][1]);
                            return true;
                        }
                    }
                            if(Singleton<TelegramUserData>.Instance.userdata[message.UserId].Count >=1 && Singleton<TelegramUserData>.Instance.userdata[message.UserId][0].ToLower().Contains("/obtener_oferta"))
                            {
                             
                            Singleton<TelegramUserData>.Instance.userdata[message.UserId].Add(message.Text.ToLower());
                            
                            if(Singleton<TelegramUserData>.Instance.userdata[message.UserId][2].ToLower().Contains("s") )
                            {                                                            
                                Singleton<OfferManager>.Instance.BuyOffer(Singleton<TelegramUserData>.Instance.user(),Convert.ToInt64(Singleton<TelegramUserData>.Instance.userdata[message.UserId][1])); 
                                Singleton<TelegramUserData>.Instance.userdata[message.UserId].Clear();
                                
                            
                                response=$"Felicitaciones";
                                return true;
                            }else if(Singleton<TelegramUserData>.Instance.userdata[message.UserId][2].ToLower().Equals("n"))
                            {
                                response=$"Operacion Cancelada";
                                Singleton<TelegramUserData>.Instance.userdata[message.UserId].Clear();
                                return true;
                            }
                        
                            }
                                              
                    





                     
            response = String.Empty ;
            return false;
        }
    }        
}


