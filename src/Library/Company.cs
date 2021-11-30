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
        /// Contructor de la persistencia de company
        /// </summary>
        [JsonConstructor]
        public Company()
        {

        }
        /// <summary>
        /// Constructor de company
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="phone"></param>
        /// <param name="location"></param>
        /// <param name="area"></param>
        /// <returns></returns>
/// 
        public Company(string id ,string name,string phone,Location location,string area) : base (id,name,phone,location,area)
        {

        }
    }
}