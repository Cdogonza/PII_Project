using System;

namespace ClassLibrary
{

    /// <summary>
    /// Esta clase implementa el tipo Iprinter y tiene como responsabilidad imprirmir 
    /// por pantalla la informacion que recibe de las otras clases.
    /// </summary>
    public class ConsolePrinter : IPrinter
    {
        /// <summary>
        /// Este metodo se encarga de imprimir en pantalla lo que devuelve GetOffertsAvailability de OfferManager
        /// </summary>
        /// <param name="offermanager"></param>
        public void PrintOffersAvailability(OfferManager offermanager)
        {
            Console.WriteLine(offermanager.GetOffersAvailability());
        }

        /// <summary>
        ///  Este metodo se encarga de imprimir en pantalla lo que devuelve GetMyOffertsAvailability de OfferManager
        /// </summary>
        /// <param name="search"></param>
        /// <param name="company"></param>
        public void PrintMyOffersAvailability(Search search, Company company)
        {
            Console.WriteLine(search.GetAvailableOffersByCompany(company));
        }

        /// <summary>
        ///  Este metodo se encarga de imprimir en pantalla lo que devuelve GetOfferByLocation de Search
        /// </summary>
        /// <param name="search"></param>
        /// <param name="location"></param>
        public void PrintOffersByLocation(Search search, string location)
        {
            Console.WriteLine(search.GetOfferByLocation(location));
        }
        
        /// <summary>
        /// Este metodo se encarga de imprimir en pantalla lo que devuelve GetOfferByWord de Search
        /// </summary>
        /// <param name="search"></param>
        /// <param name="word"></param>
        public void PrintOffersByWord(Search search, string word)
        {
            Console.WriteLine(search.GetOfferByWord(word));
        }

        /// <summary>
        /// Este metodo se encarga de imprimir en pantalla lo que devuelve GetOfferByCategory de Search
        /// </summary>
        /// <param name="search"></param>
        /// <param name="category"></param>
        public void PrintOffersByCategory(Search search, string category)
        {
            Console.WriteLine(search.GetOfferByCategory(category));
        }
        
        /// <summary>
        /// Este metodo se encarga de imprimir en pantalla lo que devuelve GetOfferByEntrepreneur de Search
        /// </summary>
        /// <param name="search"></param>
        /// <param name="entrepreneur"></param>
        public void PrintOffersByEntrepreneur(Search search, Entrepreneur entrepreneur)
        {
            Console.WriteLine(search.GetOfferByEntrepreneur(entrepreneur));
        }
        
        /// <summary>
        /// Este metodo se encarga de imprimir en pantalla lo que devuelve GetOfferByCompany de Search
        /// </summary>
        /// <param name="search"></param>
        /// <param name="company"></param>
        public void PrintOffersByCompany(Search search, Company company)
        {
            Console.WriteLine(search.GetOfferByCompany(company));
        }
    
        /// <summary>
        /// Este metodo se encarga de imprimir en pantalla lo que devuelve GetTextToPrintPermission de Datamanager
        /// </summary>
        /// <param name="datamanager"></param>    
        public void PrintPermissions(DataManager datamanager)
        {
            Console.WriteLine(datamanager.GetTextToPrintPermission());
        }

        /// <summary>
        /// Este metodo se encarga de imprimir en pantalla lo que devuelve GetTextToPrintPermission de Datamanager
        /// </summary>
        /// <param name="datamanager"></param>
        public void PrintAreaOfWork(DataManager datamanager)
        {
            Console.WriteLine(datamanager.GetTextToPrintAreaOfWork());
        }

        /// <summary>
        /// Este metodo se encarga de imprimir en pantalla lo que devuelve GetTextToPrintMaterialType de Datamanager
        /// </summary>
        /// <param name="datamanager"></param>
        public void PrintMaterialType(DataManager datamanager)
        {
            Console.WriteLine(datamanager.GetTextToPrintMaterialType());
        }

        /// <summary>
        /// Metodo para imprimir por pantalla los permisos que posee el usuario
        /// </summary>
        /// <param name="userbase"></param>
        public void PrintUserPermissions(UserBase userbase)
        {
            Console.WriteLine(userbase.GetPermissions());
        }
    }
}