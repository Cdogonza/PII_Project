using System;
namespace ClassLibrary
{
    /// <summary>
    /// El handler inicial, el cual modifica el estado del pedido según lo necesitado.
    /// </summary>
    public class InitialHandler : AbstractHandler<UserRequest>
    {
        public InitialHandler()
        {
        }
        protected override UserRequest HandleRequest(UserRequest request)
        {
            request.OutgoingMsg = "Buenas";
            UserTelegramBot currentUser = UsersManager.Instance.GetTelegramUser(request.Id);
            
            if(currentUser.authenticated == false && request.State != StateEnum.AwaitingForCompanyChoice){
                
                request.OutgoingMsg = "Usted no se encuentra ingresado en la appliación , ingrese 1 Empresa o 2 para Emmprendedor";
                request.State = StateEnum.AwaitingForCompanyChoice;
            }
            else if(currentUser.authenticated == false && request.State == StateEnum.AwaitingForCompanyChoice){
                if(request.ArrivedMsg == "1"){
                    currentUser.userMode = "1";
                    request.State = StateEnum.AwaitingForCompanyInput;
                }   
                else if (request.ArrivedMsg == "2") {
                    currentUser.userMode = "2";
                    request.State = StateEnum.AwaitingForCompanyInput;
                }
            }
            return request;

            // this._nextHandler.HandleRequest(request);

            
        }
    }
}