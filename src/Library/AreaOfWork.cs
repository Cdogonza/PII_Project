using System.Collections.Generic;
using System;
namespace ClassLibrary
<<<<<<< Updated upstream
{
{  
=======
{   
    /// <summary>
    /// Esta clase representa la categoria de una empresa
    /// </summary>
>>>>>>> Stashed changes
    public  class AreaOfWork
    {   /// <summary>
        /// Propiedad nombre de la categoria
        /// </summary>
        public string Name{get;set;}
<<<<<<< Updated upstream

    public string Name{get;set;}

    public AreaOfWork(string name)
=======
        /// <summary>
        /// Metodo constructor. permite crear instancias de categoria
        /// </summary>
        public AreaOfWork(string name)
>>>>>>> Stashed changes
        {
            this.Name = name;
        }
    }
}
