using System.Collections.Generic;
using System;
using System.Text.Json;
using System.Text.Json.Serialization;

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
    /// 
        [JsonConstructor]
        public Company(){

        }
    
        public Company(string id ,string name,string phone,Location location,string area) : base (id,name,phone,location,area)
        {

                 
        }
        
        /// <summary>
        /// Devuelve una lista con la información de una compania
        /// </summary>
        
    

    }

}