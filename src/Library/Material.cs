

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
        public string Name { get; set; }

        /// <summary>
        /// Instancia de MaterialType que representa el tipo del material
        /// </summary>
        /// <value></value>
        public MaterialType Type { get; set; }

        /// <summary>
        /// String de la unidad del material 
        /// </summary>
        /// <value></value>
        public string Unit { get; set; }

        /// <summary>
        /// Constructor de Material
        /// </summary>
        /// <param name="name">Nombre del Material</param>
        /// <param name="type">Tipo de Material, del tipo MaterialType</param>
        /// <param name="unit">Unidad que representa al material</param>
        public Material(string name, MaterialType type, string unit)
        {
            this.Name = name;
            this.Type = type;
            this.Unit = unit;
        }
    }
}