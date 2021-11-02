using System.Collections.Generic;

namespace ClassLibrary
{
        /// <summary>
        ///  Esta clase representa al emprendedor el cual hereda metodos y atributos de la clase UserBase
        /// </summary>
    public class Entrepreneur : UserBase
    {
        /// <summary>
        /// Constructor de la clase Entrepreneur
        /// </summary>
        /// <returns>Entrepreneur</returns>
        public Entrepreneur(string name,int phone) : base (name,phone)
        {
            
        }
    }

}