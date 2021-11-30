using System.Collections.Generic;
using System;
namespace ClassLibrary
{
    /// <summary>
    /// Esta clase representa al administrador del Bot
    /// </summary>
    public class Admin
    {
        /// <summary>
        /// Propiedad nombre del Administrador
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Constructor de la clase Admin
        /// </summary>
        /// <param name="name"></param>
        public Admin(string name)
        {
            if (String.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException(name);
            }
            this.Name = name;
        }
        /// <summary>
        /// Metodo que se utilizara para invitar a las Empresas al sistema.
        /// </summary>
        /// <param name="company"></param>
        public void InviteCompany(string company)
        {

        }
    }
}
