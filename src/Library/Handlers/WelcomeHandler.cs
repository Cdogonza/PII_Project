using System;
namespace ClassLibrary
{
    
    public class WelcomeHandler : AbstractHandler<UserRequest>
    {
        public WelcomeHandler()
        {
        }
        protected override UserRequest HandleRequest(UserRequest request)
        {
            UserTelegramBot currentUser = UsersManager.Instance.GetTelegramUser(request.Id);
            if(currentUser.authenticated == false && request.State == StateEnum.Start){
                request.State = StateEnum.AwaitingForCode;
                request.OutgoingMsg = "Bienvenid@!\nIngrese el código de invitación";
                request.Status = false;
                return request;
            }else{
                if (request.State == StateEnum.WrongCode){
                    request.OutgoingMsg = "Código Incorrecto. Ingrese uno nuevo.";
                    request.State = StateEnum.AwaitingForCode;
                    request.Status = false;
                    return request;
                }
            }
            request.Status = false;
            return request;
        }
    }
}