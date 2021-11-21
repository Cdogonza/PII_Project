namespace ClassLibrary
{
    /// <summary>
    /// Estados posibles de los handlers.
    /// </summary>
    public enum StateEnum
    {
        Initial,
        AwaitingForUserChoice,
        AwaitingForCompanyRegistration,
        AwaitingForEntrepreneurRegistration,
        AwaitingForCompanyData
    }
}