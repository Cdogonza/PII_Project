using System.Collections.Generic;
using System;
using System.Collections;

namespace ClassLibrary
{   
    
    public class Company : CompanyBase
    {
        public AreaOfWork AreaOfWork {get; set;}
        public string Location{get; set;}
        public Company(string name,string location,int phone,string area) : base (name,phone)
        {
            this.AreaOfWork = new AreaOfWork(area);   
            this.Location = location;
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