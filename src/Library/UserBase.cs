using System.Collections.Generic;
using System;
namespace ClassLibrary
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class UserBase
    { 
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public string Name { get;  set; }
  
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public int Phone { get; set;}   
        

        private List<Permission> permissions = new List<Permission>();

/// <summary>
/// 
/// </summary>
/// <param name="name"></param>
/// <param name="phone"></param>
        protected UserBase(string name, int phone)
        {
            this.Name = name;
            
            this.Phone = phone;
        }
/// <summary>
/// 
/// </summary>
/// <param name="permission"></param>

        public void AddPermission(string permission)
        {
            Permission newPermission = new Permission(permission);
            permissions.Add(newPermission);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>

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
 /// <summary>
 /// 
 /// </summary>
 /// <param name="permissions"></param>
 /// <returns></returns>
        public Boolean SearchP(Permission permissions)
        {
            return this.permissions.Contains(permissions);
        }

    }
}