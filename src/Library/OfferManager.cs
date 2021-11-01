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
    
        public string PrintMyOfferts(Company company)
        {

            string data = $"Las ofertas de la compania son: \n";

            foreach (Offer offer in catalog)
            {
                if(offer.Company == company)
                {
                    data = data + $"ID: {offer.id} Name: {offer.Name} - Material: {offer.Material} - Cost: {offer.Cost}  Fecha y hora de publicacion {offer.PublicationDate} \n";
                }
            }
            return data;
        }
        public string PrintMyOffertsAvailability(Company company)
        {

            string data = $"Las ofertas habilitadas Para la compania son: \n";

            foreach (Offer offer in catalog)
            {
                if(offer.Company == company)
                {
                    if(offer.Availability)
                    {
                        data = data + $"ID: {offer.id} Name: {offer.Name} - Material: {offer.Material} - Cost: {offer.Cost}  Fecha y hora de publicacion {offer.PublicationDate} \n";
                    }
                    else
                    {
                        data = "No tienes Ofertas habilitadas para mostrar";
                    }
                }
            }
            return data;
        }

       public string PrintOffertsAvailability()
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