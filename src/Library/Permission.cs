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
        /// <summary>
        /// Contructor de la persistencia de Permissions
        /// </summary>

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
        /// Constructor de la clase Permission
        /// </summary>
        /// <param name="name"></param>
        public Permission(string name)
        {
            this.Name = name;
        }


        /// <summary>
        /// Metodo de agregado de la interfaz IJsonConvertible que no lleva implementacion para esta clase
        /// </summary>
        /// <returns></returns>
        public string ConvertToJsonCompany()
        {return null;}

        /// <summary>
        /// Metodo de agregado de la interfaz IJsonConvertible que no lleva implementacion para esta clase
        /// </summary>
        /// <returns></returns>
        public string ConvertToJsonEntrepreneur()
        {return null;}

        /// <summary>
        /// Metodo de agregado de la interfaz IJsonConvertible que no lleva implementacion para esta clase
        /// </summary>
        /// <returns></returns>
        public string ConvertToJsonOffer()
        {return null;}

        /// <summary>
        /// Metodo de agregado de la interfaz IJsonConvertible que serializa los datos de la clase Permissions
        /// </summary>
        /// <returns></returns>
        public string ConvertToJsonPermissions()
        {
            return JsonSerializer.Serialize(this);
        }

        /// <summary>
        /// Metodo de agregado de la interfaz IJsonConvertible que no lleva implementacion para esta clase
        /// </summary>
        /// <returns></returns>
        public string ConvertToJsonMaterialTypes()
        {return null;}

        /// <summary>
        /// Metodo de agregado de la interfaz IJsonConvertible que no lleva implementacion para esta clase
        /// </summary>
        /// <returns></returns>
        public string ConvertToJsonAreaOfWork()
        {return null;}
    }
}