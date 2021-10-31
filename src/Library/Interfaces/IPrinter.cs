namespace ClassLibrary
{
    public interface IPrinter
    {
        void PrintOffertsAvailability(OfferManager texttoprint);
        void PrintMyOffertsAvailability(OfferManager texttoprint, Company company);
    }
}