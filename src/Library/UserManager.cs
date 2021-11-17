using System.Collections.Generic;
using System.Collections.ObjectModel;
namespace ClassLibrary
{
    public class UsersManager
    {
        private static UsersManager instance;
        public static UsersManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new UsersManager();
                }

                return instance;
            }
        }
      private UsersManager()
        {
        }
        private List<UserTelegramBot> userList = new List<UserTelegramBot>();
        public ReadOnlyCollection<UserTelegramBot> GetUserList()
        {
            //De esta manera se protege la encapsulación.        
            return userList.AsReadOnly();
        }
        public UserTelegramBot GetUsuarioTelegram(long id) 
        {
            foreach (UserTelegramBot user in userList)
            {
                if (user.Id == id)
                {
                    return user;
                }
            }
            UserTelegramBot newUser = new UserTelegramBot(id);
            userList.Add(newUser);
            return newUser;
        }
    
    
    
    
    }



}