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
            if(message.Text.ToLower().Equals("/vermisdatos"))
            {
             if (Singleton<DataManager>.Instance.GetCompany(message.UserId) != null)
                {
                   
                    response= Singleton<DataManager>.Instance.GetCompany(message.UserId);
                return true;
                }else
                {
                    if(Singleton<DataManager>.Instance.GetEntrepreneur(message.UserId) != null)
                    {
                        
                        response= Singleton<DataManager>.Instance.GetEntrepreneur(message.UserId);
                        return true;
                     }
                }         
            }
            response= String.Empty ;
            return false;
        }
}
}