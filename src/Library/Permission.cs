using System.Collections.Generic;
using System.Collections;
using System;
namespace ClassLibrary
{
    /// <summary>
    /// 
    /// </summary>
    public class Permission
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        public Permission(string name)
        {
            this.Name = name;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public string Name { get ; set; }
        
    }
}