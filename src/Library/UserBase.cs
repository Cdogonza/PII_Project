using System.Collections.Generic;
using System;
namespace ClassLibrary
{   /// <summary>
    /// Esta clase define las propiedas y comportamiento que comparten los diferentes usuarios de la empresa
    /// </summary>
    public abstract class UserBase
    { 
        /// <summary>
        /// Propiedad Nombre del usuario
        /// </summary>
        public string Name { get;  set; }

        /// <summary>
        /// Propiedad ubicación de la empresa
        /// </summary>
        public string Location{get; set;}

        /// <summary>
        /// Propiedad telefono del usuario
        /// </summary>
        public string Phone { get; set;}  
        
        /// <summary>
        /// Lista de habilitaciones que posee un usario
        /// </summary>
        private List<Permission> permissions = new List<Permission>();


        /// <summary>
        /// Permite crear instancias de los usuarios del programa
        /// </summary>

        protected UserBase(string name, string phone, string location)
        {
            this.Name = name;
            
            this.Phone = phone;

            this.Location = location;
        }

        /// <summary>
        ///Permite agregar permisios a un usuario
        /// </summary>
        public void AddPermission(string permission)
        {
            Permission newPermission = new Permission(permission);
            permissions.Add(newPermission);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>

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
        public void GetPermissions()
        {
            foreach (var permission in permissions)
            {
                Console.WriteLine(permission.Name);
            }
        }
    }
}