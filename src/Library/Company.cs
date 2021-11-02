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
        /// Instancia de clase AreaOfWork que representa una categoria de la empresa
        /// </summary>
        public AreaOfWork AreaOfWork {get; set;}
        /// <summary>
        /// Propiedad que almacena la ubicación de la empresa
        /// </summary>
        public string Location{get; set;}
        /// <summary>
        /// Permite crear instancias de usuarios del tipo Company
        /// </summary>
        public Company(string name,string location,int phone,string area) : base (name,phone)
        {
            this.AreaOfWork = new AreaOfWork(area);
        }

        /// <summary>
        /// Devuelve una lista con la información de una compania
        /// </summary>
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