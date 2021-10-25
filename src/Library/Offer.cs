using System.Collections.Generic;
using System.Collections;
using System;
namespace ClassLibrary
{
    public class Offer
    {
        public string Material{get;set;}
        public double Cost{get;set;}
        public bool Availability{get;set;}
        public string RegularOffers{get;set;}
        public ArrayList Tags{get;set;}
        public DateTime DeliveryDate{get;set;}
        public DateTime PublicationDate{get;set;}
    

        public Offer(string material,double cost,bool availability, string regularoffers, ArrayList tags, DateTime deliverydate, DateTime publicationdate)
        {
            this.Material = material;
            this.Cost = cost;
            this.Availability = availability;
            this.Tags = tags;
            this.DeliveryDate = deliverydate;
            this.PublicationDate = publicationdate;
        }
    
    }
}