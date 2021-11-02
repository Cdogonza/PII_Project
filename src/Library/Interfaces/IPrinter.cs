namespace ClassLibrary
{
    /// <summary>
    /// 
    /// </summary>
    public interface IPrinter
    {
        void PrintOffertsAvailability(OfferManager offermanager);
        void PrintMyOffertsAvailability(OfferManager offermanager, Company company);
        void PrintOffertsByLocation(Search search, string location);
        void PrintOffertsByWord(Search search, string word);
        void PrintOffertsByCategory(Search search, string category);
        void PrintOffertsByEntrepreneur(Search search, Entrepreneur entrepreneur);
        void PrintOffertsByCompany(Search search, Company company);
        void PrintPermissions(DataManager datamanager);
        void PrintAreaOfWork(DataManager datamanager);
        void PrintMaterialType(DataManager datamanager);

    }
}