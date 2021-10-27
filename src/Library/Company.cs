using System.Collections.Generic;
using System;
using System.Collections;

namespace ClassLibrary
{   
    
    public class Company : CompanyBase
    {
        public AreaOfWork AreaOfWork {get; set;}
        public Company(string name,string area) : base (name)
        {
            this.AreaOfWork = new AreaOfWork(area);   

        }

        
    

    }

}