

using System;

namespace ClassLibrary
{
    class Materials
    {
        public string Name{get; set;}
        public string Category{get;set;}
        public string Quantity{get;set;}
        public string Cost{get;set;}
        public string Location{get;set;}

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