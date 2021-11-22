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
          UserTelegramBot currentUser = UsersManager.Instance.GetTelegramUser(request.Id);

            if(currentUser.authenticated == false && request.State == StateEnum.Initial){
                request.Status =false;
                request.State = StateEnum.AwaitingForUserChoice;
                request.OutgoingMsg = "Usted no se encuentra ingresado en la apliación, ingrese 1 para Empresa o 2 para Emprendedor";
                return request;
            }
            request.Status = false;
            return request;

        }
    }
        
}

