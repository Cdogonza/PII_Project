using System.Collections.Generic;
using System.Collections;
using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ClassLibrary
{
    /// <summary>
    /// Esta clase representa los permisos de las empresas, ofertas y emprendedores
    /// </summary>
    public class Permission : IJsonConvertible
    {
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        /// <param name="name"></param>
        public Permission(string name)
        {
            this.Name = name;
        }

        [JsonConstructor]
        public Permission()
        {

        }

        /// <summary>
        /// String con el nombre del permiso
        /// </summary>
        /// <value></value>
        public string Name { get ; set; }
        


        public string ConvertToJsonCompany()
        {
            return null;
        }
        public string ConvertToJsonEntrepreneur()
        {return null;}
        public string ConvertToJsonOffer()
        {return null;}
        public string ConvertToJsonPermissions()
        {
            return JsonSerializer.Serialize(this);
        }
        public string ConvertToJsonMaterialTypes()
        {return null;}
    }
}