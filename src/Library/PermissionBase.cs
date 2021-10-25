using System.Collections.Generic;
using System.Collections;
using System;
namespace ClassLibrary
{
    public class PermissionBase : IPermissions
    {

        public PermissionBase(string name)
        {
            this.Name = name;
        }
        public string Name { get ; set; }
        
    }
}