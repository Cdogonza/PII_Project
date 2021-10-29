using System.Collections.Generic;
using System;
using System.Collections;

namespace ClassLibrary
{   
    
    public class Company : CompanyBase
    {
        public AreaOfWork AreaOfWork {get; set;}
        public string Locacion{get; set;}
        public Company(string name,string location,int telefono,string area) : base (name,telefono)
        {
            this.AreaOfWork = new AreaOfWork(area);   
            this.Locacion = location;
        }

        public List<string> DataCompany()
        {
            List <string> datos = new List<string>();  
            datos.Add(this.Name);
            datos.Add(Convert.ToString(this.Telefono));
            datos.Add(this.Locacion);
            return datos;
        }
    

    }

}