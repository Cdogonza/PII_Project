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
            Console.WriteLine(texttoprint.PrintOffertsAvailability());
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="texttoprint"></param>
        /// <param name="company"></param>
        public void PrintMyOffertsAvailability(OfferManager texttoprint, Company company)
        {
            Console.WriteLine(texttoprint.PrintMyOffertsAvailability(company));
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="texttoprint"></param>
        /// <param name="company"></param>
        public void PrintMyOfferts(OfferManager texttoprint, Company company)
        {
            Console.WriteLine(texttoprint.PrintMyOfferts(company));
        }
    

    
    }

}