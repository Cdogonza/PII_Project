using System.Collections.Generic;
using System;
using System.Collections;

namespace ClassLibrary
{   
    /// <summary>
    /// Clase que representa a un usuario del tipo compania dentro del programa
    /// </summary>
    public class Company : UserBase
    {
    /// <summary>
    /// Constructor de company
    /// </summary>
    /// <param name="name"></param>
    /// <param name="phone"></param>
    /// <param name="location"></param>
    /// <param name="area"></param>
    /// <returns></returns>
        public Company(string name,string phone,Location location,string area) : base (name,phone,location,area)
        {

        }
        
        /// <summary>
        /// Devuelve una lista con la información de una compania
        /// </summary>
        public List<string> DataCompany()
        {
            List <string> data = new List<string>();  
            data.Add(this.Name);
            data.Add(Convert.ToString(this.Phone));
            data.Add(this.Location.AddresLine);
            data.Add(this.Location.CountryRegion);
            data.Add(this.Location.Locality);
            data.Add(this.Location.PostalCode);
            return data;
        }
    

    }

}