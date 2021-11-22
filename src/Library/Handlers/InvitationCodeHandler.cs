using System;
namespace ClassLibrary
{
    
    public class InvitationCodeHandler : AbstractHandler<UserRequest>
    {
        public InvitationCodeHandler()
        {
        }
        protected override UserRequest HandleRequest(UserRequest request)
        {
            Console.WriteLine("entre aca");
            UserTelegramBot currentUser = UsersManager.Instance.GetTelegramUser(request.Id);
            if(currentUser.authenticated == false && request.State == StateEnum.AwaitingForCode){
                if (request.ArrivedMsg == "1234"){
                    request.State = StateEnum.Initial;
                    request.OutgoingMsg = "ok";
                    request.Status =false;
                    return request;
                }
                request.OutgoingMsg = "Código Incorrecto";
                request.Status =false;
                return request;
            }
            request.Status =false;
            return request;
        }
    }
}
