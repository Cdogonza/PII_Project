using Telegram.Bot.Types;
using System;
namespace ClassLibrary
{
    public class EntrepreneurRegister: AbstractHandler<UserRequest>
    {
        public EntrepreneurRegister()
        {
         
        }
        protected override UserRequest HandleRequest(UserRequest request)
        {
        
            UserTelegramBot currentUser = UsersManager.Instance.GetTelegramUser(request.Id);
      
            Console.WriteLine("Te digo que no entra aca lpm");
            if (request.State == StateEnum.AwaitingForEntrepreneurRegistration){
                request.Status=false;
                
                switch (currentUser.companyInfo.Count)
                {
                    case 0:
                        currentUser.companyInfo.Add(request.ArrivedMsg);
                        break;
                    case 1:
                        request.OutgoingMsg = "Ingrese un telefono";
                        currentUser.companyInfo.Add(request.ArrivedMsg);
                        break;
                    case 2:
                        request.OutgoingMsg = "Ingrese Calle y Nro";
                        currentUser.companyInfo.Add(request.ArrivedMsg);
                        break;
                    case 3:
                        request.OutgoingMsg = "Ingrese Ciudad";
                        currentUser.companyInfo.Add(request.ArrivedMsg);
                        break;
                    case 4:
                        request.OutgoingMsg = "Ingrese Departamento";
                        currentUser.companyInfo.Add(request.ArrivedMsg);
                        break;
                    case 5:
                        request.OutgoingMsg = "Ingrese el Rubro";
                        currentUser.companyInfo.Add(request.ArrivedMsg);
                        break;
                    case 6:
                        request.OutgoingMsg = "Ingrese su especializacion";
                        currentUser.companyInfo.Add(request.ArrivedMsg);
                        
                        break;
                
                }

        return request;

        }
        request.Status =false;
        return request;
    }
}
}