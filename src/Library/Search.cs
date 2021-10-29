using System;
using System.Collections.Generic;
namespace ClassLibrary
{
    public class Search
    {
        public List<Offer> byLocation = new List<Offer>();

        public List<Offer> byWord = new List<Offer>();

        public List<Offer> byCategory = new List<Offer>();
        public List GetOfferByLocation(List<Offer> catalogo, string location)
        {
            foreach (Offer offer in catalogo)
            {
                if (offer )
                {
                    byLocation.Add(offer);
                }
            }
            return 
        }

        public List GetOfferByWord(string word)
        {

        }

        public List GetOfferByCategory(ztring category)
        {

        }
    }
}