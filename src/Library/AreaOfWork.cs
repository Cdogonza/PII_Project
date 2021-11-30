using System.Collections.Generic;
using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ClassLibrary
{   
    /// <summary>
    /// Representa una categoria de una empresa
    /// EXPERT :  Esta clase es una clase base del programa que contiene toda la información y metodos de los  area de trabajo de las compañias por lo que se justifica con el principio expert.
    /// </summary>
    public  class AreaOfWork : IJsonConvertible
    {
        /// <summary>
        /// Contructor de la persistencia de AreaOfWork
        /// </summary>
        [JsonConstructor]
        public AreaOfWork()
        {

        }

        /// <summary>
        /// String del nombre del rubro
        /// </summary>
        /// <value></value>
        public string Name{get;set;}
        
        /// <summary>
        /// Crea instancias de este tipo AreaOfWork
        /// </summary>
        /// <param name="name"></param>
        public AreaOfWork(string name)
        {
            if (String.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException(name);
            }
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
        /// Metodo de agregado de la interfaz IJsonConvertible que no lleva implementacion para esta clase
        /// </summary>
        /// <returns></returns>
        public string ConvertToJsonPermissions()
        {return null;}
        
        /// <summary>
        /// Metodo de agregado de la interfaz IJsonConvertible que no lleva implementacion para esta clase
        /// </summary>
        /// <returns></returns>
        public string ConvertToJsonMaterialTypes()
        {return null;}

        /// <summary>
        /// Metodo de agregado de la interfaz IJsonConvertible que serializa los datos de la clase AreaOfWork
        /// </summary>
        /// <returns></returns>
        public string ConvertToJsonAreaOfWork()
        {
            return JsonSerializer.Serialize(this);
        }
        
    }
}
