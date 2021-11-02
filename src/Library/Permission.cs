using System.Collections.Generic;
using System.Collections;
using System;
namespace ClassLibrary
{
    /// <summary>
    /// Esta clase representa los permisos de las empresas y emprendedores
    /// </summary>
    public class Permission
    {
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        /// <param name="name"></param>
        public Permission(string name)
        {
            this.Name = name;
        }

        /// <summary>
        /// String con el nombre del permiso
        /// </summary>
        /// <value></value>
        public string Name { get ; set; }
        
    }
}