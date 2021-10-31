using System;

namespace ClassLibrary
{

    // DIP
    public class ConsolePrinter : IPrinter
    {
        //public Company Company {get;set;}

        public void PrintOffertsAvailability(OfferManager texttoprint)
        {
            Console.WriteLine(texttoprint.PrintOffertsAvailability());
        }
        public void PrintMyOffertsAvailability(OfferManager texttoprint, Company company)
        {
            Console.WriteLine(texttoprint.PrintMyOffertsAvailability(company));
        }
        public void PrintMyOfferts(OfferManager texttoprint, Company company)
        {
            Console.WriteLine(texttoprint.PrintMyOfferts(company));
        }
    

    
    }

}