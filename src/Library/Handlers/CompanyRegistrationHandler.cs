using System;
using System.Collections.Generic;

namespace ClassLibrary
{
    /// <summary>
    /// El handler inicial, el cual modifica el estado del pedido según lo necesitado.
    /// </summary>
    public class CompanyRegistrationHandler : AbstractHandler<UserRequest>
    {
        public int contador = 0;
        List<string> companyInfo = new List<string>();
        public CompanyRegistrationHandler(ICondition<UserRequest> condition) : base (condition)
        {
        
        }
        protected override UserRequest HandleRequest(UserRequest request)
        {
            
            if (request.State == StateEnum.AwaitingForCompanyRegistration){
                companyInfo.Add(request.ArrivedMsg);
                contador++;
                if (contador == 1)
                {
                //    foreach (var item in companyInfo){
                //        request.OutgoingMsg = $"{item}";
                //    }
                request.OutgoingMsg = "Ingrese un telefono";
                companyInfo.Add(request.ArrivedMsg);
                contador++;
                //return request; 
                }
                if (contador == 2)
                {
                request.OutgoingMsg = "Ingrese una dir";
                companyInfo.Add(request.ArrivedMsg);
                contador++;
                //return request;    
                }              

            //return request;
   /*         
            else if (request.State == StateEnum.AwaitingForCompanyRegistration && companyInfo.Count == 1){
                companyInfo.Add(request.ArrivedMsg);
                request.OutgoingMsg = "Ingrese una dir";
                return request;  
              //  request.State = StateEnum.AwaitingForCompanyData;
            }
            else if (request.State == StateEnum.AwaitingForCompanyRegistration && companyInfo.Count == 2){
                companyInfo.Add(request.ArrivedMsg);
                request.OutgoingMsg = "Ingrese ciudad";
                return request;
            }
            return request;
            
//              foreach (var item in companyInfo){
  //          request.OutgoingMsg = $"{item}";
*/
        }
        return request;
    }
}
}