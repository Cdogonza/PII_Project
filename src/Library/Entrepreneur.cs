using System.Collections.Generic;

namespace ClassLibrary
{
        /// <summary>
        ///  Esta clase representa al emprendedor el cual hereda metodos y atributos de la clase UserBase
        /// </summary>
    public class Entrepreneur : UserBase
    {
        /// <summary>
        /// String de la especializacion
        /// </summary>
        /// <value></value>
        public string Specialization {get; set;}
        
        
        /// <param name="name"></param>
        /// <param name="phone"></param>
        /// <param name="location"></param>
        /// <param name="area"></param>
        /// <param name="specialization"></param>
        /// <returns></returns>
        public Entrepreneur(long id,string name,string phone,Location location,string area,string specialization) : base (id,name,phone,location,area)
        {
            this.Specialization = specialization;
        }
    }

}