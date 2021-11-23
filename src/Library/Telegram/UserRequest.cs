using System;
using System.Collections.Generic;
namespace ClassLibrary

{
    
    public class UserRequest
    {
        public long Id {get; set; }
        public string ArrivedMsg {get; set; }
        public string Command{get; set; }
        public string OutgoingMsg {get; set; }
        public StateEnum State {get; set; }
        public bool Status {get; set; }
        
        public UserRequest(long id, string message)
        {
            this.Id = id;
            this.ArrivedMsg = message;
            this.State = StateEnum.Start;
            this.Status = true;
            

        }
    }
}