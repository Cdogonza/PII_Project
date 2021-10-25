using System.Collections.Generic;
using System;
namespace ClassLibrary
{
    public abstract class CompanyBase
    { 
        public string Name { get;  set; }
        public string Location { get; set;}     
        public string AreaOfWork {get; set;}

        private List<IPermissions> permissions = new List<IPermissions>();

        protected CompanyBase(string name)
        {
            this.Name = name;
            this.Location = Location;
        }

        // en el program tenemos que hacer el chequeo si existe el areaofwork y lo agregamos.
        public void AddAreaOfWork(string area)
        {
             this.AreaOfWork = area;            
        }

        public void AddPermission(IPermissions permission)
        {
            permissions.Add(permission);
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
        public Boolean SearchP(IPermissions permissions)
        {
            return this.permissions.Contains(permissions);
        }

    }
}