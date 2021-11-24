using System.Collections.Generic;
namespace ClassLibrary
{

    public class BotBase
    {

        private BotBase(){}
        private static BotBase instance;
        public static BotBase Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new BotBase();
                }

                return instance;
            }
        }

        private List<UserRequest> requestList = new List<UserRequest>();
        public void Start()
        {
            IRecive reciever = new TelegramReciv();
            reciever.StartRecive();
            while (reciever.IsRecive())
            {
                
            }
        }
        public void GetInput(long id, string message)
        {
            AbstractHandler<UserRequest> welcomeHandler = new WelcomeHandler();
            AbstractHandler<UserRequest> invitationCodeHandler = new InvitationCodeHandler();
            AbstractHandler<UserRequest> initialHandler = new InitialHandler();
            AbstractHandler<UserRequest> userChoiceCreation = new UserChoiceCreationHandler();
            AbstractHandler<UserRequest> CompanyRegistrationHandler = new CompanyRegistrationHandler();
            AbstractHandler<UserRequest> EntrepreneurRegistrationHandler = new EntrepreneurRegistrationHandler();
            
    

            welcomeHandler.SetNext(invitationCodeHandler);
            invitationCodeHandler.SetNext(initialHandler);
            initialHandler.SetNext(userChoiceCreation);
            userChoiceCreation.SetNext(EntrepreneurRegistrationHandler);
            EntrepreneurRegistrationHandler.SetNext(CompanyRegistrationHandler);
            CompanyRegistrationHandler.SetNext(welcomeHandler);
           
            ISend telegramSender = new TelegramSend();
            UserRequest userRequest = GetRequestById(id, message);
            UserRequest response = welcomeHandler.Handle(userRequest);
            UserRequest response0 = invitationCodeHandler.Handle(userRequest);
            UserRequest response1 = initialHandler.Handle(userRequest);
            UserRequest response2 = userChoiceCreation.Handle(userRequest);
            UserRequest response3 = EntrepreneurRegistrationHandler.Handle(userRequest);
            UserRequest response4 = CompanyRegistrationHandler.Handle(userRequest);
           

            telegramSender.SendMessage(response.Id, response.OutgoingMsg);
        }
        public UserRequest GetRequestById(long id, string message) 
        {
            foreach (UserRequest request in requestList)
            {
                if (request.Id == id)
                {                   
                    request.ArrivedMsg = message;
                    return request;                  
                }
            }
            UserRequest newRequest = new UserRequest(id, message);
            requestList.Add(newRequest);
            return newRequest;
        }
    }
}