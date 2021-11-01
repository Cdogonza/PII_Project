using System;

namespace ClassLibrary
{
    /// <summary>
    /// 
    /// </summary>
    public class MaterialType
    {
        private string Name{get;set;}
        private string Description{get;set;}
        /// <summary>
        /// 
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




