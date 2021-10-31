using System.Collections.Generic;

namespace ClassLibrary
{
    public class Entrepreneur : UserBase
    {
        public Search search;
        public Entrepreneur(string name,int phone) : base (name,phone)
        {
            this.search = new Search();

        }
        
       
    }

}