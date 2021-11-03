using System.Collections.Generic;
using System;
namespace ClassLibrary
{   
    /// <summary>
    /// Representa una categoria de una empresa
    /// </summary>
    public  class AreaOfWork
    {
        /// <summary>
        /// Propiedad nombre de la categoria de la empresa
        /// </summary>
        public string Name{get;set;}
        /// <summary>
        /// Crea instancias de este tipo
        /// </summary>
        public AreaOfWork(string name)
        {
            if (String.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException(name);
            }
            this.Name = name;
        }
        
    }
}
