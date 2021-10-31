using System.Collections.Generic;
using System;
namespace ClassLibrary
{
    public abstract class UserBase
    { 
        public string Name { get;  set; }
        public string Location { get; set;}   
        public int Phone { get; set;}   
        

        private List<Permission> permissions = new List<Permission>();

        protected UserBase(string name, int phone)
        {
            this.Name = name;
            
            this.Phone = phone;
        }


        public void AddPermission(string permission)
        {
            Permission newPermission = new Permission(permission);
            permissions.Add(newPermission);
        }

        public void RemovePermission(int index)
        {
            this.permissions.RemoveAt(index);
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