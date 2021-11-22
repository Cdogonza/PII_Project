using System.Collections.Generic;
namespace ClassLibrary

{
    public class UserTelegramBot
    {
        public long Id{get; private set;}

        public bool authenticated {get; private set;}
        public List<string> companyInfo = new List<string>();
        public bool code{get; private set;}
        public string userMode {get; set;}

        public UserBase currentCompany{get; set;}
        public UserTelegramBot(long id)
        {
            this.Id = id;
        }

        public void login()
        {
            
        }

        public void addCompany(UserBase company){
            this.currentCompany  =  company;
        }


    }
}