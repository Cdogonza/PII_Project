using System;
using System.Collections.Generic;

namespace ClassLibrary
{
    /// <summary>
    /// El handler inicial, el cual modifica el estado del pedido según lo necesitado.
    /// </summary>
    public class CompanyRegistrationHandler : AbstractHandler<UserRequest>
    {
        List<string> companyInfo = new List<string>();
        public CompanyRegistrationHandler(ICondition<UserRequest> condition) : base (condition)
        {
        }
        protected override UserRequest HandleRequest(UserRequest request)
        {
            request.OutgoingMsg = "Ingrese nombre Empresa";
            companyInfo.Add(request.ArrivedMsg);
            if (request.State == StateEnum.AwaitingForCompanyRegistration && companyInfo.Count == 0){
                request.OutgoingMsg = "Ingrese un telefono";  
              //  request.State = StateEnum.AwaitingForCompanyData;
            }
            if (request.State == StateEnum.AwaitingForCompanyRegistration && companyInfo.Count == 1){
                companyInfo.Add(request.ArrivedMsg);
                request.OutgoingMsg = "Ingrese dir";


            }
            return request;
            
        }
    }
}