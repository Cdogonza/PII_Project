

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
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public string Category{get;set;}
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
        /// 
        /// </summary>
        /// <value></value>
        public Materials(string name, string category,string quantity, string cost, string location)
        {
            this.Name = name;
            this.Category = category;
            this.Quantity = quantity;
            this.Cost = cost;
            this.Location = location;
        }
    }
}