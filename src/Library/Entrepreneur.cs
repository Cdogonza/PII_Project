using System.Collections.Generic;
using System.Text.Json.Serialization;
namespace ClassLibrary
{
        /// <summary>
        ///  Esta clase representa al emprendedor el cual hereda metodos y atributos de la clase UserBase
        /// EXPERT :  Esta clase es una clase base del programa que contiene toda la información y metodos de los emprendedores por lo que se justifica con el principio expert..
        /// </summary>
    public class Entrepreneur : UserBase
    {
        /// <summary>
        /// String de la especializacion
        /// </summary>
        /// <value></value>]
        public string Specialization {get; set;}
        public List<Permission> Permissions {get; set;}

        /// <param name="name"></param>
        /// <param name="phone"></param>
        /// <param name="location"></param>
        /// <param name="area"></param>
        /// <param name="specialization"></param>
        /// <returns></returns>
        
        [JsonConstructor]
        public Entrepreneur()
        {

        }
        public Entrepreneur(string id,string name,string phone,Location location,string area,string specialization, List<Permission> permission) : base (id,name,phone,location,area)
        {
            this.Specialization = specialization;
            this.Permissions = permission;
        }
    }

}