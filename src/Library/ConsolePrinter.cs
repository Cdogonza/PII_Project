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
        public void PrintMyOffertsAvailability(Search texttoprint, Company company)
        {
            Console.WriteLine(texttoprint.GetAvailableOffersByCompany(company));
        }
        public void PrintOffertsByCompany(Search texttoprint, Company company)
        {
            Console.WriteLine(texttoprint.GetByCompany(company));
        }
    

    
    }

}