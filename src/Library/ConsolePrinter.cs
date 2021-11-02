using System;

namespace ClassLibrary
{

    // DIP
    public class ConsolePrinter //: IPrinter
    {
        //public Company Company {get;set;}

        public void PrintOffertsAvailability(OfferManager offermanager)
        {
            Console.WriteLine(offermanager.GetOffertsAvailability());
        }
        public void PrintMyOffertsAvailability(OfferManager offermanager, Company company)
        {
            Console.WriteLine(offermanager.GetMyOffertsAvailability(company));
        }
        public void PrintOffertsByLocation(Search search, string location)
        {
            Console.WriteLine(search.GetOfferByLocation(location));
        }
        public void PrintOffertsByWord(Search search, string word)
        {
            Console.WriteLine(search.GetOfferByWord(word));
        }
        public void PrintOffertsByCategory(Search search, string category)
        {
            Console.WriteLine(search.GetOfferByCategory(category));
        }
        public void PrintOffertsByEntrepreneur(Search search, Entrepreneur entrepreneur)
        {
            Console.WriteLine(search.GetOfferByEntrepreneur(entrepreneur));
        }
        public void PrintOffertsByCompany(Search search, Company company)
        {
            Console.WriteLine(search.GetOfferByCompany(company));
        }
    
        public void PrintPermissions(DataManager datamanager)
        {
            Console.WriteLine(datamanager.GetTextToPrintPermission());
        }
        public void PrintAreaOfWork(DataManager datamanager)
        {
            Console.WriteLine(datamanager.GetTextToPrintAreaOfWork());
        }

        public void PrintMaterialType(DataManager datamanager)
        {
            Console.WriteLine(datamanager.GetTextToPrintMaterialType());
        }
    
    

    
    }

}