using System.Collections.Generic;

namespace ClassLibrary
{
    /// <summary>
    /// 
    /// </summary>
    
    public class Entrepreneur : UserBase
    {
        /// <summary>
        /// 
        /// </summary>
        public Search search;
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam List="Offer"></typeparam>
        /// <returns></returns>
        
        public List <Offer> mylist = new List<Offer>();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="phone"></param>
        /// <returns></returns>
        public Entrepreneur(string name,int phone) : base (name,phone)
        {

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        public List<Offer> SearchByCategory(string category)
        {
            this.search = new Search();
            mylist = search.GetOfferByCategory(category);
            return mylist;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="location"></param>
        /// <returns></returns>
        public List<Offer> SearchByLocation(string location)
        {
            this.search = new Search();
            mylist = search.GetOfferByLocation(location);
            return mylist;
        } 
        /// <summary>
        /// 
        /// </summary>
        /// <param name="word"></param>
        /// <returns></returns>
        public List<Offer> SearchByWord(string word)
        {
            this.search = new Search();
            mylist = search.GetOfferByWord(word);
            return mylist;
        }                
       
    }

}