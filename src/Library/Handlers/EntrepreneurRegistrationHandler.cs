using Telegram.Bot.Types;
using System;
namespace ClassLibrary
{
    public class EntrepreneurRegistrationHandler: AbstractHandler<UserRequest>
    {
        bool estado = false;
        private Location LocationOffer;
        public EntrepreneurRegistrationHandler()
        {
         
        }
        protected override UserRequest HandleRequest(UserRequest request)
        {
        
            UserTelegramBot currentUser = UsersManager.Instance.GetTelegramUser(request.Id);
      
            if (request.State == StateEnum.AwaitingForEntrepreneurRegistration){
                request.Status=false;
                
                switch (currentUser.companyInfo.Count)
                {
                    case 0:
                        currentUser.companyInfo.Add(request.ArrivedMsg);
                        break;
                    case 1:
                        request.OutgoingMsg = "Ingrese un teléfono.";
                        currentUser.companyInfo.Add(request.ArrivedMsg);
                        break;
                    case 2:
                        request.OutgoingMsg = "Ingrese Calle y Nro de puerta.";
                        currentUser.companyInfo.Add(request.ArrivedMsg);
                        break;
                    case 3:
                        request.OutgoingMsg = "Ingrese Ciudad.";
                        currentUser.companyInfo.Add(request.ArrivedMsg);
                        break;
                    case 4:
                        request.OutgoingMsg = "Ingrese Departamento.";
                        currentUser.companyInfo.Add(request.ArrivedMsg);
                        break;
                    case 5:
                        request.OutgoingMsg = "Ingrese el Rubro.";
                        currentUser.companyInfo.Add(request.ArrivedMsg);
                        break;
                    case 6:
                        request.OutgoingMsg = "Ingrese su especialización.";
                        currentUser.companyInfo.Add(request.ArrivedMsg);
                        LocationApiClient Loc = new LocationApiClient();
                        LocationOffer=Loc.GetLocation(currentUser.companyInfo[2],currentUser.companyInfo[3],currentUser.companyInfo[4]);
                        Entrepreneur emp = new Entrepreneur(request.Id,currentUser.companyInfo[0],currentUser.companyInfo[1],LocationOffer,currentUser.companyInfo[5],currentUser.companyInfo[6]);
                        
                        break;               
                }
        return request;

            }
           
        return request;      
        }

   
    }
}