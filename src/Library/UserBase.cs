using System.Collections.Generic;
using System;
namespace ClassLibrary
{
    public abstract class UserBase
    { 
        public string Name { get;  set; }
        public string Phone { get; set;}  
        public string Location{get; set;}
        

        private List<Permission> permissions = new List<Permission>();

        protected UserBase(string name, string phone, string location)
        {
            this.Name = name;
            
            this.Phone = phone;

            this.Location = location;
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
    }
}