using System.Collections.Generic;
using System;
namespace ClassLibrary
{   
    
    public class OfferManager 
    {
        public static List<Offer> catalog = new List<Offer>();
         public OfferManager()
        {
            
        }
        
       
       public void SaveOffer(Offer offer)
        {   
            catalog.Add(offer);
        }
        public void PublishOffer(int id)
        {
           Offer offer = catalog[id];
            offer.Availability = true;
        }
        public void DiseableOffer(int id)
        {
           Offer offer = catalog[id];
            offer.Availability = false;
        }
    
        

       public string GetOffertsAvailability()
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

        public void buyoffer(Entrepreneur buyer,int index)
        {
            catalog[index].getOffert(buyer);

        }
    }

}