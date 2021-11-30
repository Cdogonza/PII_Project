using System.Collections.Generic;
using System;
using System.Text.Json;
using System.Text.Json.Serialization;
namespace ClassLibrary
{   /// <summary>
    /// Esta clase define las propiedas y comportamiento que comparten los diferentes usuarios de la empresa
    /// </summary>
    public abstract class UserBase : IJsonConvertible
    { 
        /// <summary>
        /// Contructor de la persistencia del usuario
        /// </summary>
        [JsonConstructor]

        public UserBase()
        {

        }
        /// <summary>
        /// Propiedad Nombre del usuario
        /// </summary>
        public string Name { get;  set; }
        /// <summary>
        /// Propiedad de la Id del usuario
        /// </summary>
        /// <value></value>
        public string Id { get;  set; }

        /// <summary>
        /// Instancia Location de la empresa que representa su ubicacion
        /// </summary>
        public Location Location{get; set;}

        /// <summary>
        /// Propiedad telefono del usuario
        /// </summary>
        public string Phone { get; set;}  

        /// <summary>
        /// Instancia de clase AreaOfWork que representa una categoria de la empresa
        /// </summary>
        public AreaOfWork AreaOfWork {get; set;}
        
        /// <summary>
        /// Lista de habilitaciones que posee un usario
        /// </summary>
        /// <typeparam list="Permission"></typeparam>
        /// <returns></returns>
        private List<Permission> permissions = new List<Permission>();


        /// <summary>
        /// Permite crear instancias de los usuarios del programa
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="phone"></param>
        /// <param name="location"></param>
        /// <param name="area"></param>

        protected UserBase(string id,string name, string phone, Location location, string area)
        {
            if (String.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException(name);
            }

            if (String.IsNullOrWhiteSpace(phone))
            {
                throw new ArgumentNullException(phone);
            }
            if (String.IsNullOrWhiteSpace(area))
            {
                throw new ArgumentNullException(area);
            }
            this.Id = id;

            this.Name = name;
            
            this.Phone = phone;

            this.Location = location;

            this.AreaOfWork = new AreaOfWork(area);
        }

        /// <summary>
        /// Permite agregar permisios a un usuario
        /// </summary>
        /// <param name="permission"></param>
        public void AddPermission(Permission permission)
        {
            permissions.Add(permission);
        }

        /// <summary>
        /// Permite eliminar un permiso de un usuario
        /// </summary>
        public void RemovePermission(int index)
        {
            this.permissions.RemoveAt(index);
        }

        /// <summary>
        /// permite obtener la lista de permisos de un usuario
        /// </summary>
        public string GetPermissions()
        {
            string data = $"La lista de Permisos del usuario son: \n";

            foreach (var permission in permissions)
            {
                data = data + $"Name: {permission.Name} \n";

            }
            return data;
        }
        public string ConvertToJsonCompany()
        {
            return JsonSerializer.Serialize(this);
        }
         public string ConvertToJsonEntrepreneur()
        {
            return JsonSerializer.Serialize(this);
        }
        public string ConvertToJsonOffer()
        {
            return JsonSerializer.Serialize(this);
        }

        public string ConvertToJsonPermissions()
        {
            return JsonSerializer.Serialize(this);
        }

        public string ConvertToJsonMaterialTypes()
        {
            return JsonSerializer.Serialize(this);
        }
        public string ConvertToJsonAreaOfWork()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}