using System;
using System.Collections.Generic;

namespace ClassLibrary
{
    /// <summary>
    /// 
    /// </summary>
    public class Search

   {
        private List<Offer> catalog = new List<Offer>();
        /// <summary>
        /// 
        /// </summary> <summary>
        /// 
        /// </summary> <summary>
        /// 
        /// </summary>
        
        public Search()
        {
            this.catalog = OfferManager.catalog;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="location"></param>
        /// <returns></returns>
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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="word"></param>
        /// <returns></returns>
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
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