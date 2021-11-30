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
        /// Constructor de la clase Entrepreneur
        /// </summary>
        /// <param name="id">Id del Emprendedor, obtenido del UserId de Telegram</param>
        /// <param name="name">Nombre del Emprendedor</param>
        /// <param name="phone">Telefono del Emprendedor</param>
        /// <param name="location">Ubicacion del Emprendedor, de tipo Location</param>
        /// <param name="area">Rubro al cual Pertenece el emprendedor</param>
        /// <param name="specialization">Espacializacion del emprendedor</param>
        /// <param name="permission">Lista de permisos que posee el empdendedor</param>
        /// <returns></returns>
        public Entrepreneur(string id,string name,string phone,Location location,string area,string specialization, List<Permission> permission) : base (id,name,phone,location,area)
        {
            this.Specialization = specialization;
            this.Permissions = permission;
        }
    }

}