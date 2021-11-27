

using System;

namespace ClassLibrary
{
    /// <summary>
    /// Esta clase es la encargada de crear instancias de materiales
    /// </summary>
    public class Material
    {
        /// <summary>
        /// String del nombre del material
        /// </summary>
        /// <value></value>
        public string Name{get; set;}

        /// <summary>
        /// Instancia de MaterialType que representa el tipo del material
        /// </summary>
        /// <value></value>
        public MaterialType Type{get;set;}

        /// <summary>
        /// String de la cantidad del material 
        /// </summary>
        /// <value></value>
        public string Quantity{get;set;}

        /// <summary>
        /// Constructor de la clase
        /// </summary>
        /// <param name="name"></param>
        /// <param name="type"></param>
        /// <param name="quantity"></param>
        /// <param name="cost"></param>
        /// <param name="location"></param>
        public Material(string name, MaterialType type, string quantity)
        {
            this.Name = name;
            this.Type = type;
            this.Quantity = quantity;
        }
    }
}