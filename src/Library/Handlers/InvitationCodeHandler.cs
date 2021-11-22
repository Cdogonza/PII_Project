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
            UserTelegramBot currentUser = UsersManager.Instance.GetTelegramUser(request.Id);
            if(currentUser.authenticated == false && request.State == StateEnum.AwaitingForCode){
                if (request.ArrivedMsg == "1234"){
                    request.State = StateEnum.Initial;
                    Console.WriteLine(request.State);
                    request.Status = false;
                    return request;
                }else{
                
                request.State = StateEnum.WrongCode;
                request.Status = false;
                return request;
                }
            }
            request.Status = false;
            return request;
        }
    }
}
