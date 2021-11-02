using System.Collections.Generic;
using System;
using System.Collections;

namespace ClassLibrary
{   
    
    public class Company : UserBase
    {
        public AreaOfWork AreaOfWork {get; set;}
        public Company(string name,string phone,string location,string area) : base (name,phone,location)
        {
            this.AreaOfWork = new AreaOfWork(area);
        }

        public List<string> DataCompany()
        {
            List <string> data = new List<string>();  
            data.Add(this.Name);
            data.Add(Convert.ToString(this.Phone));
            data.Add(this.Location);
            return data;
        }
    

    }

}