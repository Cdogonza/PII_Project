using System.Collections.Generic;
namespace ClassLibrary
{
    /*
    Singleton: Utilizamos el patrón Singleton ya que de esta manera esta instancia sería única, 
    por lo que los usuarios no usarían distintas instancias de este objeto,
    y también esto nos posibilita acceder a todo lo relacionado con esta clase desde 
    cualquier otra clase.
    */

    /// <summary>
    /// Esta clase se encarga de aplicar la lógica correspondiente a la inicialización 
    /// del programa y la administración de los Handlers.
    /// De igual manera, se encarga de crear los mismos y corresponderlos con la función
    /// SetNext(), también se encarga de crear una instancia para el Sender
    /// (recibidor de mensajes) y para el Sender(enviador de mensajes).
    /// 
    /// Esta clase posee una unica instancia creada mediante un Singleton, por lo que es accesible desde todo el programa.
    /// </summary>
    public class BotBase
    {
       // #region Singleton
        
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
      //  #endregion

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
            AbstractHandler<UserRequest> initialHandler = new InitialHandler();
            AbstractHandler<UserRequest> userChoiceCreation = new UserChoiceCreationHandler();
            AbstractHandler<UserRequest> CompanyRegistrationHandler = new CompanyRegistrationHandler();
            AbstractHandler<UserRequest> EntrepreneurRegistrationHandler = new EntrepreneurRegistrationHandler();
            initialHandler.SetNext(userChoiceCreation);
            userChoiceCreation.SetNext(EntrepreneurRegistrationHandler);
            EntrepreneurRegistrationHandler.SetNext(CompanyRegistrationHandler);
            
            ISend telegramSender = new TelegramSend();
            UserRequest userRequest = GetRequestById(id, message);
            UserRequest response = initialHandler.Handle(userRequest);
            UserRequest response2 = userChoiceCreation.Handle(userRequest);
            UserRequest response3 = EntrepreneurRegistrationHandler.Handle(userRequest);
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