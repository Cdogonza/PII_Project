using System.Collections.Generic;
using System;
namespace ClassLibrary
{   
    /// <summary>
    /// Esta clase contiene las propiedas y metodos que comparten los diferentes usuarios dle programa (company/entrepreneur)
    /// </summary>
    
    public abstract class UserBase
    { 
        /// <summary>
        /// Propiedad nombre de la compania
        /// </summary>
        public string Name { get;  set; }

        /// <summary>
        /// Propiedad Phone
        /// </summary>
        public string Phone { get; set;}   
        
        /// <summary>
        /// Lista de permisos de la empresa
        /// </summary>

        private List<Permission> permissions = new List<Permission>();

        /// <summary>
        /// Crea una instancia de una instancia de esta clase
        /// </summary>

        protected UserBase(string name, string phone)
        {
            this.Name = name;
            
            this.Phone = phone;
        }

        /// <summary>
        /// Permite agregar una permiso a la lista de permisos de esta compania
        /// </summary>
        /// <param name="permission"></param>
        
        public void AddPermission(string permission)
        {
            Permission newPermission = new Permission(permission);
            permissions.Add(newPermission);
        }
        /// <summary>
        /// Permite eliminar una permiso a la lista de permisos de esta compania
        /// </summary>
        /// <param name="index"></param>
        public void RemovePermission(int index)
        {
            this.permissions.RemoveAt(index);
        }

    }
}