using System.Collections.Generic;
using System.Text.Json.Serialization;
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
        /// <value></value>]
        public string Specialization {get; set;}

        /// <summary>
        /// lista con permisos del tipo permission
        /// </summary>
        /// <value></value>
        public List<Permission> Permissions {get; set;}

        /// <summary>
        /// Contructor de la persistencia de Entrepreneur
        /// </summary>
        
        [JsonConstructor]
        public Entrepreneur()
        {

        }

        /// <summary>
        /// Constructor de Entrepreneur
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="phone"></param>
        /// <param name="location"></param>
        /// <param name="area"></param>
        /// <param name="specialization"></param>
        /// <param name="permission"></param>
        /// <returns></returns>
        public Entrepreneur(string id,string name,string phone,Location location,string area,string specialization, List<Permission> permission) : base (id,name,phone,location,area)
        {
            this.Specialization = specialization;
            this.Permissions = permission;
        }
    }

}