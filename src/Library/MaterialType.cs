using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ClassLibrary
{
    /// <summary>
    /// Esta clase representa los tipos de materiales
    /// </summary>
    public class MaterialType : IJsonConvertible
    {

        /// <summary>
        /// String del nombre del tipo de material
        /// </summary>
        /// <value></value>
        public string Name{get;set;}

        /// <summary>
        /// String de la descripcion sobre el tipo de material
        /// </summary>
        /// <value></value>

        public string Description{get;set;}

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
        
        [JsonConstructor]
        public MaterialType()
        {

        }

        public string ConvertToJsonCompany()
        {return null;}
        public string ConvertToJsonEntrepreneur()
        {return null;}
        public string ConvertToJsonOffer()
        {return null;}
        public string ConvertToJsonPermissions()
        {return null;}
        public string ConvertToJsonMaterialTypes()
        {
            return JsonSerializer.Serialize(this);
        }

    }




}




