using System.Collections.Generic;
using System;
using System.Collections;

namespace ClassLibrary
{   
<<<<<<< Updated upstream
    
    public class Company : CompanyBase
=======
        
        /// <summary>
        /// Esta clase representa una compania e hereda comportamiento de la clase base UserBase
        /// </summary>

    public class Company : UserBase
>>>>>>> Stashed changes
    {
        /// <summary>
        /// Propiedad que resprensenta el rubro en el que trabaja la comapania
        /// </summary>

        public AreaOfWork AreaOfWork {get; set;}
<<<<<<< Updated upstream
        public Company(string name,string area) : base (name)
=======
        /// <summary>
        /// Propiedad que almacena la ubicación de la compania
        /// </summary>
        public string Location{get; set;}
        /// <summary>
        /// Metodo constructor de la clase
        /// </summary>
        public Company(string name,string location,string phone,string area) : base (name,phone)
>>>>>>> Stashed changes
        {
            this.AreaOfWork = new AreaOfWork(area);   

<<<<<<< Updated upstream
=======
        /// <summary>
        /// Permite obtener la información de la compania
        /// </summary>
        public List<string> DataCompany()
        {
            List <string> data = new List<string>();  
            data.Add(this.Name);
            data.Add(Convert.ToString(this.Phone));
            data.Add(this.Location);
            return data;
>>>>>>> Stashed changes
        }

        
    

    }

}