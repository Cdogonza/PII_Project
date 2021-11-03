using System.Collections.Generic;
using System;
namespace ClassLibrary
{   
    /// <summary>
    /// Clase experta en el manejo de las ofertas
    /// </summary>
    public class OfferManager 
    {
        /// <summary>
        /// Catalogo de ofertas de nuestra aplicacion
        /// </summary>
        /// <typeparam List="Offer"></typeparam>
        /// <returns></returns>
        public List<Offer> catalog = new List<Offer>();
        /// <summary>
        /// Este es el constructor de la clase
        /// </summary>
         public OfferManager()
        {
            
        }
        /// <summary>
        /// Este metodo lo que hace es, una vez creada la oferta se guarda en el catalogo de la aplicacion
        /// </summary>
        /// <param name="offer"></param>
       public void SaveOffer(Offer offer)
        {   
            catalog.Add(offer);
        }
        /// <summary>
        /// Este metodo se utiliza para re publicar ofertas que son priodicas 
        /// </summary>
        /// <param name="id"></param>
        public void PublishOffer(int id)
        {
           Offer offer = catalog[id];
            offer.Availability = true;
        }
        /// <summary>
        /// Este metodo desabilita una oferta del catalogo
        /// </summary>
        /// <param name="id"></param>
        public void DiseableOffer(int id)
        {
           Offer offer = catalog[id];
            offer.Availability = false;
        }

        /// <summary>
        /// Este metodo retorna las ofertas del catalogo que estan habilitadas
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
        /// El metodo siguiente permite comprar la oferta al emprendedor
        /// </summary>
        /// <param name="buyer"></param>
        /// <param name="index"></param>
        public void BuyOffer(Entrepreneur buyer,int index)
        {
            catalog[index].getOffer(buyer);

        }
    }

}