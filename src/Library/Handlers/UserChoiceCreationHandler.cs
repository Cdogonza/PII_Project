using System;
namespace ClassLibrary
{
    /// <summary>
    /// El handler inicial, el cual modifica el estado del pedido según lo necesitado.
    /// </summary>
    public class UserChoiceCreationHandler : AbstractHandler<UserRequest>
    {
        public UserChoiceCreationHandler()
        {
        }
        protected override UserRequest HandleRequest(UserRequest request)
        {
            
            UserTelegramBot currentUser = UsersManager.Instance.GetTelegramUser(request.Id);
            request.Status=false;
            if (request.State == StateEnum.AwaitingForUserChoice)
            {
           
                if(request.ArrivedMsg == "1"){
                    currentUser.userMode = "1";
                    request.State = StateEnum.AwaitingForCompanyRegistration;
                    request.OutgoingMsg = "Ingrese Nombre de empresa";
                   
                    return request;
                }   
                else if (request.ArrivedMsg == "2") {
                    currentUser.userMode = "2";
                                      
                    request.State = StateEnum.AwaitingForEntrepreneurRegistration; 
                    return request;
                }
                else{
                    request.OutgoingMsg = "Opcion no valida, ingrese opcion 1 para empresa o 2 para emprendedor";
                    return request;
                }
                
                
            }
            return request;   
        }
    }
}