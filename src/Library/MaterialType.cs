using System;

namespace ClassLibrary
{
    /// <summary>
    /// Esta clase representa los tipos de materiales.
    /// </summary>
    public class MaterialType
    {
        /// <summary>
        /// String del nombre del tipo de material
        /// </summary>
        /// <value></value>
        private string Name{get;set;}

        /// <summary>
        /// String de la descripcion sobre el tipo de material
        /// </summary>
        /// <value></value>
        private string Description{get;set;}

        /// <summary>
        /// Constructor de la clase MaterialType
        /// </summary>
        /// <param name="name"></param>
        /// <param name="description"></param>
        public MaterialType(string name, string description)
        {
            this.Name = name;
            this.Description = description;
        }


    }




}




