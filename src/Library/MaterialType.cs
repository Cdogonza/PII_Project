using System;

namespace ClassLibrary
{
    public class MaterialType
    {
        public string Name{get;set;}
        private string Description{get;set;}
        public MaterialType(string name, string description)
        {
            this.Name = name;
            this.Description = description;
        }


    }




}




