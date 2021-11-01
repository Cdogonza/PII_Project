using System;
using System.Collections.Generic;
namespace ClassLibrary
{
    public class Search
    {
        public List<Offer> GetOfferByLocation(List<Offer> catalog, string location)
        {
            List<Offer> byLocation = new List<Offer>();
            foreach (Offer offer in catalog)
            {
                if (offer.Location == location)
                {
                    byLocation.Add(offer);
                }
            }
            return byLocation;
        }

        public List<Offer> GetOfferByWord(List<Offer> catalog, string word)
        {
            List<Offer> byWord = new List<Offer>();
            foreach (Offer offer in catalog)
            {
                if (offer.Tags.Contains(word))
                {
                    byWord.Add(offer);
                }
            }
            /*foreach (Offer of in byWord)
            {
                return of;
            }*/
            return byWord;
        }

        public List<Offer> GetOfferByCategory(List<Offer> catalog, string category)
        {
            List<Offer> byCategory = new List<Offer>();
            foreach (Offer offer in catalog)
            {
                if (offer.Company.AreaOfWork.Name == category)
                {
                    byCategory.Add(offer);
                }
            }
            return byCategory;
        }
    }
}