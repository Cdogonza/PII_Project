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
        /// <param name="name">Nombre del tipo de material</param>
        /// <param name="description">Descripcion del tipo de material</param>
        public MaterialType(string name, string description)
        {
            if (String.IsNullOrWhiteSpace(name)){
                throw new ArgumentNullException(name);
            }
            if (String.IsNullOrWhiteSpace(description)){
                throw new ArgumentNullException(description);
            }

            this.Name = name;
            this.Description = description;
        }
        /// <summary>
        /// Contructor de la persistencia de Material Type
        /// </summary>
        
        [JsonConstructor]
        public MaterialType()
        {

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
        public string ConvertToJsonAreaOfWork()
        {return null;}
        
        /// <summary>
        /// Metodo de agregado de la interfaz IJsonConvertible que serializa los datos de la clase MaterialTypes
        /// </summary>
        /// <returns></returns>
        public string ConvertToJsonMaterialTypes()
        {
            return JsonSerializer.Serialize(this);
        }

    }




}




