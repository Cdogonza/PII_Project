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
            request.OutgoingMsg = "Bienvenid@!\nIngrese el código de invitacion para registrarse como Empresa de lo contrario \n ingrese 1 para ingresar como emprendedor";
            if(request.ArrivedMsg==null)
            {
            request.OutgoingMsg = "Bienvenid@!\nIngrese el código de invitacion para registrarse como Empresa de lo contrario \n ingrese 1 para ingresar como emprendedor";
            }else
            {
                if(request.ArrivedMsg=="1")
                {
                    request.Command ="emprendedor";
                }else
                {
                  if(request.ArrivedMsg=="1234")
                  {
                    request.Command ="company";   
                  }else
                  {
                      request.Command ="no definido";
                  }     
                }  
            }           
        }
        
    }
}
