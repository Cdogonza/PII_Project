using System.Collections.Generic;
using System;
namespace ClassLibrary
{
    public abstract class CompanyBase
    { 
        public string Name { get;  set; }
        public string Location { get; set;}     
        

        private List<Permission> permissions = new List<Permission>();

        protected CompanyBase(string name)
        {
            this.Name = name;
            this.Location = Location;
        }


        public void AddPermission(string permission)
        {
            // Permission newPermission = new Permission(permission);
            // permissions.Add(newPermission);
        }
/* 
        public void GetPermissions()
        {
            foreach (var permission in permissions)
            {
                Console.WriteLine(permission.Name);
            }
        }
 */
        public Boolean SearchP(Permission permissions)
        {
            return this.permissions.Contains(permissions);
        }

    }
}