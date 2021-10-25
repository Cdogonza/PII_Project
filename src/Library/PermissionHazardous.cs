using System.Collections.Generic;
using System.Collections;
using System;
namespace ClassLibrary
{
    public class PermissionHazardous : IPermissions
    {

        public PermissionHazardous(string name)
        {
            this.Name = name;
        }
        public string Name { get ; set; }
        
    }
}