using System.Collections.Generic;
using System;
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
        public string Location{get;set;}
        
        /// <param name="name"></param>
        /// <param name="phone"></param>
        /// <param name="location"></param>
        /// <param name="area"></param>
        /// <param name="specialization"></param>
        /// <returns></returns>
        public Entrepreneur(long id,string name,string phone,string location,string area,string specialization) : base (id,name,phone,area)
        {
            this.Specialization = specialization;
            this.Location=location;
            Console.WriteLine("Cree Emprendedor");
            Console.WriteLine(specialization);
        }
        
    }

}