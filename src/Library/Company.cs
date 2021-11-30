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
        /// Constructor de la clase Company
        /// </summary>
        /// <param name="id">Id de la Compania, obetenido del UserId de Telegram</param>
        /// <param name="name">Nombre de la Compania</param>
        /// <param name="phone">Telefono de la Compania</param>
        /// <param name="location">Ubicacion de la Compania, de tipo Location</param>
        /// <param name="area">Rubro al cual pertenece la Compania</param>
        /// <returns></returns>
        /// 
        public Company(string id ,string name,string phone,Location location,string area) : base (id,name,phone,location,area)
        {

        }
    }
}