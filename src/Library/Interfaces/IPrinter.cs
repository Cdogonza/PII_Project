namespace ClassLibrary
{
    /// <summary>
    /// 
    /// </summary>
    public interface IPrinter
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="texttoprint"></param>
        void PrintOffertsAvailability(OfferManager texttoprint);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="texttoprint"></param>
        /// <param name="company"></param>
        void PrintMyOffertsAvailability(OfferManager texttoprint, Company company);
        void PrintOffertsByCompany(Search texttoprint, Company company);

    }
}