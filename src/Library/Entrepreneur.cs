using System.Collections.Generic;

namespace ClassLibrary
{
    public class Entrepreneur : UserBase
    {
        public Search search;
        public List <Offer> mylist = new List<Offer>();
        public Entrepreneur(string name,int phone) : base (name,phone)
        {
            

        }
        public List<Offer> SearchByCategory(string category)
        {
            this.search = new Search();
            mylist = search.GetOfferByCategory(category);
            return mylist;
        }

        public List<Offer> SearchByLocation(string location)
        {
            this.search = new Search();
            mylist = search.GetOfferByLocation(location);
            return mylist;
        } 
        public List<Offer> SearchByWord(string word)
        {
            this.search = new Search();
            mylist = search.GetOfferByWord(word);
            return mylist;
        }                
       
    }

}