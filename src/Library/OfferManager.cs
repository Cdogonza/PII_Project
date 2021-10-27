using System.Collections.Generic;
using System;
using System.Collections;

namespace ClassLibrary
{   
    
    public class OfferManager 
    {
        public List<Offer> history = new List<Offer>();
         public OfferManager()
        {
        }
        
        public void PublishOffer(string material,double cost,bool availability,string regularoffers,ArrayList tags,DateTime deliverydate,DateTime publicationdate,Company company)
        {
            Offer oferta =  new Offer(material,cost,availability,regularoffers,tags,deliverydate,publicationdate,company);
            this.history.Add(oferta);
        }
    
        public void PrintOfferts(){
            foreach (Offer offer in this.history)
            {
                Console.WriteLine($"{offer.Material}  {offer.Cost} {offer.PublicationDate}");
            }
        }
    }

}