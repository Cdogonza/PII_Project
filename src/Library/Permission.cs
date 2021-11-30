using System.Collections.Generic;
using System.Collections;
using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ClassLibrary
{
    /// <summary>
    /// Esta clase representa los permisos de las empresas, ofertas y emprendedores
    /// EXPERT : Esta clase es una clase base del programa que contiene toda la información y metodos de los permisos de las compañías por lo que se justifica con el principio expert.
    /// 
    /// </summary>
    public class Permission : IJsonConvertible
    {

        [JsonConstructor]
        public Permission()
        {

        }


        /// <summary>
        /// String con el nombre del permiso
        /// </summary>
        /// <value></value>
        public string Name { get ; set; }
        

        /// <summary>
        /// Constructor de la clase
        /// </summary>
        /// <param name="name"></param>
        public Permission(string name)
        {
            this.Name = name;
        }



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
        public string ConvertToJsonAreaOfWork()
        {return null;}
    }
}