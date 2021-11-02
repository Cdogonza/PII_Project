using System;

namespace ClassLibrary
{

    // DIP
    public class ConsolePrinter //: IPrinter
    {
        //public Company Company {get;set;}

        public void PrintOffertsAvailability(OfferManager texttoprint)
        {
            Console.WriteLine(texttoprint.GetOffertsAvailability());
        }
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