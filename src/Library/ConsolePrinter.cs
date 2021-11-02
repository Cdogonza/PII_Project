using System;

namespace ClassLibrary
{

    // DIP
    /// <summary>
    /// 
    /// </summary>
    public class ConsolePrinter : IPrinter
    {
        //public Company Company {get;set;}
        /// <summary>
        /// 
        /// </summary>
        /// <param name="texttoprint"></param>
               
        public void PrintOffertsAvailability(OfferManager texttoprint)
        {
            Console.WriteLine(texttoprint.GetOffertsAvailability());
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="texttoprint"></param>
        /// <param name="company"></param>
        public void PrintMyOffertsAvailability(OfferManager texttoprint, Company company)
        {
            Console.WriteLine(texttoprint.GetMyOffertsAvailability(company));
        }
        public void PrintOffertsByCompany(Search texttoprint, Company company)
        {
            Console.WriteLine(texttoprint.GetByCompany(company));
        }
    

    
    }

}