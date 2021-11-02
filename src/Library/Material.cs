

using System;

namespace ClassLibrary
{
    /// <summary>
    /// Esta clase es la encargada de crear instancias de materiales
    /// </summary>
    public class Material
    {
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public string Name{get; set;}

        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public MaterialType Type{get;set;}

        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public string Quantity{get;set;}

        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public string Cost{get;set;}

        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public string Location{get;set;}

        /// <summary>
        /// Crea instancias de la clase Material
        /// </summary>
        /// <param name="name"></param>
        /// <param name="type"></param>
        /// <param name="quantity"></param>
        /// <param name="cost"></param>
        /// <param name="location"></param>
        public Material(string name, MaterialType type, string quantity, string cost, string location)
        {
            this.Name = name;
            this.Type = type;
            this.Quantity = quantity;
            this.Cost = cost;
            this.Location = location;
        }
    }
}