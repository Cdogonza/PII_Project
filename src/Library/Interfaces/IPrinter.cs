namespace ClassLibrary
{
    /// <summary>
    /// Esta interfaz define las operaciones necesarias para imprimir los diferentes textos del programa
    /// </summary>
    public interface IPrinter
    {
        /// <summary>
        /// Este metodo retorna las ofertas en estado disponible 
        /// </summary>
        /// <param name="offermanager"></param>
        void PrintOffersAvailability(OfferManager offermanager);
        /// <summary>
        /// Este metodo retorna 
        /// </summary>
        /// <param name="offermanager"></param>
        /// <param name="company"></param>
        void PrintMyOffersAvailability(Search search, Company company);
        void PrintOffersByLocation(Search search, string location);
        void PrintOffersByWord(Search search, string word);
        void PrintOffersByCategory(Search search, string category);
        void PrintOffersByEntrepreneur(Search search, Entrepreneur entrepreneur);
        void PrintOffersByCompany(Search search, Company company);
        void PrintPermissions(DataManager datamanager);
        void PrintAreaOfWork(DataManager datamanager);
        void PrintMaterialType(DataManager datamanager);

    }
}