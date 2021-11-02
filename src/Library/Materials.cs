

using System;

namespace ClassLibrary
{
    /// <summary>
    /// 
    /// </summary>
    /// <value></value>
    public class Materials
    {
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public string Name{get; set;}
        public MaterialType Type{get;set;}
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

        public Materials(string name, MaterialType type, string quantity, string cost, string location)
        {
            this.Name = name;
            this.Type = type;
            this.Quantity = quantity;
            this.Cost = cost;
            this.Location = location;
        }
    }
}