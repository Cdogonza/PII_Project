using System;
namespace ClassLibrary
{
    /// <summary>
    /// El handler inicial, el cual modifica el estado del pedido según lo necesitado.
    /// </summary>
    public class InitialHandler : AbstractHandler<UserRequest>
    {
        public InitialHandler(ICondition<UserRequest> condition) : base(condition)
        {
        }
        protected override UserRequest HandleRequest(UserRequest request)
        {
            UserTelegramBot currentUser = UsersManager.Instance.GetTelegramUser(request.Id);
            
            if(currentUser.authenticated == false && request.State == StateEnum.Initial){
                request.State = StateEnum.AwaitingForUserChoice;
                request.OutgoingMsg = "Usted no se encuentra ingresado en la appliación , ingrese 1 Empresa o 2 para Emprendedor";
                return request;
            }
            return request;

            // this._nextHandler.HandleRequest(request);

            
        }
    }
}