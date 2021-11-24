using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
namespace ClassLibrary
{

    public class DataManagerHandler: BaseHandler
    {
        
        public DataManagerHandler(BaseHandler next) : base(next)
        {
            this.Keywords = new string[] {"/vermisdatos"};
        }
        protected override bool InternalHandle(IMessage message, out string response)
        {
            
            if(message.Text.ToLower().Equals("/vermisdatos") )
            {
                Console.WriteLine("Entre aca en /vermisdatos");
                
              response = Singleton<DataManager>.Instance.GetCompany(message.UserId).Id;
    
                    
                    //Singleton<DataManager>.Instance.GetCompany(message.UserId);
                    return true;
               
                response="Algo Salio mal1";
                return true;
            }
            response="Algo Salio mal2";
            return true;
        }
    }
}