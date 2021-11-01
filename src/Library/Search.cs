using System;
using System.Collections.Generic;
namespace ClassLibrary
{
    public class Search

    {
        public List<Offer> catalog = new List<Offer>();

        public Search()
        {
            this.catalog = OfferManager.catalog;
        }
        public List<Offer> GetOfferByLocation(string location)
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

        public List<Offer> GetOfferByWord(string word)
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

        public List<Offer> GetOfferByCategory(string category)
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