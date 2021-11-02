using System.Collections.Generic;
using System;
namespace ClassLibrary
<<<<<<< Updated upstream:src/Library/CompanyBase.cs
{
    public abstract class CompanyBase
=======
{   
        
    /// <summary>
    /// Esta clase representa las caractiricas que comparten los diferentes tipos de usuarios de la empresa (EMPRESA/ENTRENEUR)
    /// </summary>
    public abstract class UserBase
>>>>>>> Stashed changes:src/Library/UserBase.cs
    { 
        /// <summary>
        /// Popriedad nombre de la empresa
        /// </summary>
        public string Name { get;  set; }
<<<<<<< Updated upstream:src/Library/CompanyBase.cs
        public string Location { get; set;}     
        
=======
        public string Phone { get; set;}   
>>>>>>> Stashed changes:src/Library/UserBase.cs

        /// <summary>
        /// Al macena la lista de permision que posee la empresa
        /// </summary>
        private List<Permission> permissions = new List<Permission>();

<<<<<<< Updated upstream:src/Library/CompanyBase.cs
        protected CompanyBase(string name)
=======
        protected UserBase(string name, string phone)
>>>>>>> Stashed changes:src/Library/UserBase.cs
        {
            this.Name = name;
            this.Location = Location;
        }

        /// <summary>
        /// Permite agregar una permiso a la empresa
        /// </summary>
        public void AddPermission(string permission)
        {
<<<<<<< Updated upstream:src/Library/CompanyBase.cs
            // Permission newPermission = new Permission(permission);
            // permissions.Add(newPermission);
=======
            Permission newPermission = new Permission(permission);
            permissions.Add(newPermission);
        }
        /// <summary>
        /// Permite remover un permiso a la empresa
        /// </summary>
        public void RemovePermission(int index)
        {
            this.permissions.RemoveAt(index);
>>>>>>> Stashed changes:src/Library/UserBase.cs
        }

        /// <summary>
        /// Permite obtener la lsita de permisos de la empresa
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