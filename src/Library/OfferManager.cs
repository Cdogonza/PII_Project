using System.Collections.Generic;
using System;
namespace ClassLibrary
{   
    /// <summary>
    /// CLASE EXPERTA EN EL MANEJO DE LAS OFERAS
    /// </summary>
    public class OfferManager 
    {
        /// <summary>
        /// CATALOGO DE OFERTAS DEL PROGRAMA
        /// </summary>
        /// <typeparam List="Offer"></typeparam>
        /// <returns></returns>
        public List<Offer> catalog = new List<Offer>();
        /// <summary>
        /// 
        /// </summary>
         public OfferManager()
        {
            
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="offer"></param>
       public void SaveOffer(Offer offer)
        {   
            catalog.Add(offer);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        public void PublishOffer(int id)
        {
           Offer offer = catalog[id];
            offer.Availability = true;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        public void DiseableOffer(int id)
        {
           Offer offer = catalog[id];
            offer.Availability = false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
       public string GetOffersAvailability()
        {
            string data = $"Las ofertas habilitadas son: \n";
            foreach (Offer offer in catalog)
            {
                if(offer.Availability)
                {
                    data = data + $"{offer.id} {offer.Name} Costo {offer.Cost} Fecha y hora de publicacion {offer.PublicationDate} \n";
                }
                else
                {
                    data = "No tienes Ofertas habilitadas para mostrar";
                }
                
            }
            return data;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="buyer"></param>
        /// <param name="index"></param>
        public void BuyOffer(Entrepreneur buyer,int index)
        {
            catalog[index].getOffer(buyer);

        }
    }

}