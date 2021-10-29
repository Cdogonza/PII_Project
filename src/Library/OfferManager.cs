using System.Collections.Generic;
using System;
namespace ClassLibrary
{   
    
    public class OfferManager 
    {
        public List<Offer> catalog = new List<Offer>();
         public OfferManager()
        {
            
        }
        
       
       public void SaveOffer(Offer offer)
        {   
            this.catalog.Add(offer);
        }
        public void PublishOffer(int id)
        {
           Offer offer = this.catalog[id];
            offer.Availability = true;
        }
        public void DiseableOffer(int id)
        {
           Offer offer = this.catalog[id];
            offer.Availability = false;
        }
    
        public void PrintmyOfferts(Company company)
        {

            foreach (Offer offer in this.catalog)
            {
                if(offer.Company == company)
                {
                    Console.WriteLine($"{offer.id} {offer.Name} Costo {offer.Cost} Fecha y hora de publicacion {offer.PublicationDate}");
                }
                
            }
        }
        public void PrintOffertsAvilitiy(Company company)
        {
            foreach (Offer offer in this.catalog)
            {
                if(offer.Company == company)
                {
                    if(offer.Availability)
                    {
                    Console.WriteLine($"{offer.id} {offer.Name} Costo {offer.Cost} Fecha y hora de publicacion {offer.PublicationDate}");
                    }else Console.WriteLine("No tienes Ofertas habilitadas para mostrar");
                }
                
            }
        }
        public void buyoffer(Entrepreneur buyer,int index)
        {
            this.catalog[index].getOffert(buyer);

        }
    }

}