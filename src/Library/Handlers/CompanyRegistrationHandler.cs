using System;
using System.Collections.Generic;

namespace ClassLibrary
{
    /// <summary>
    /// El handler inicial, el cual modifica el estado del pedido según lo necesitado.
    /// </summary>
    public class CompanyRegistrationHandler : AbstractHandler<UserRequest>
    {
        //public int contador = 0;
        public CompanyRegistrationHandler(ICondition<UserRequest> condition) : base (condition)
        {
        
        }
        protected override UserRequest HandleRequest(UserRequest request)
        {
            UserTelegramBot currentUser = UsersManager.Instance.GetTelegramUser(request.Id);

            //int contador = 0;
            if (request.State == StateEnum.AwaitingForCompanyRegistration){
                if (currentUser.companyInfo.Count == 0)
                {
                    currentUser.companyInfo.Add(request.ArrivedMsg);
                }
                //contador+=1;
                foreach (var item in currentUser.companyInfo){
                    Console.WriteLine($"{item} ");
                }

                Console.WriteLine($"Count: {currentUser.companyInfo.Count}");
           
                if (currentUser.companyInfo.Count == 1)
                { 
             
                    request.OutgoingMsg = "Ingrese un telefono";
                    currentUser.companyInfo.Add(request.ArrivedMsg);
                    Console.WriteLine($"Count TEL: {currentUser.companyInfo.Count}");
                    // contador++;
                    return request;
                }
                if (currentUser.companyInfo.Count == 2)
                {
                    request.OutgoingMsg = "Ingrese calle y numero (Ej: Berro 1231)";
                    currentUser.companyInfo.Add(request.ArrivedMsg);
                    //contador++;
                    return request;    
                }              
    
            return request;
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