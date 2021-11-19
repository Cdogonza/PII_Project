using System;
using System.Collections.Generic;
namespace ClassLibrary

{
    
    public class UserRequest
    {
        public long Id {get; set; }
        public string Message {get; set; }
        public StateEnum State {get; set; }
        public string Title {get; set; }
        public string Type {get; set; }
        
        public UserRequest(long id, string message)
        {
            this.Id = id;
            this.Message = message;
            this.State = StateEnum.Initial;
        }
    }
}