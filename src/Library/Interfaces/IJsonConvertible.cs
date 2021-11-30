using System.Text.Json;

namespace ClassLibrary
{
    /// <summary>
    /// Define el tipo que tienen los objetos que pueden ser serializados en y deserializados desde texto en formato
    /// Json.
    /// </summary>
    public interface IJsonConvertible
    {
        /// <summary>
        /// Convierte el objeto a texto en formato Json. El objeto puede ser reconstruido a partir del texto en formato
        /// Json utilizando JsonSerializer.Deserialize.
        /// </summary>
        /// <returns>El objeto Company convertido a texto en formato Json.</returns>
        string ConvertToJsonCompany();

        /// <summary>
        /// Convierte el objeto a texto en formato Json. El objeto puede ser reconstruido a partir del texto en formato
        /// Json utilizando JsonSerializer.Deserialize.
        /// </summary>
        /// <returns>El objeto Entrepreneur convertido a texto en formato Json.</returns>
        string ConvertToJsonEntrepreneur();

        /// <summary>
        /// Convierte el objeto a texto en formato Json. El objeto puede ser reconstruido a partir del texto en formato
        /// Json utilizando JsonSerializer.Deserialize.
        /// </summary>
        /// <returns>El objeto Offer convertido a texto en formato Json.</returns>
        string ConvertToJsonOffer();

        /// <summary>
        /// Convierte el objeto a texto en formato Json. El objeto puede ser reconstruido a partir del texto en formato
        /// Json utilizando JsonSerializer.Deserialize.
        /// </summary>
        /// <returns>El objeto Permissions convertido a texto en formato Json.</returns>
        string ConvertToJsonPermissions();

        /// <summary>
        /// Convierte el objeto a texto en formato Json. El objeto puede ser reconstruido a partir del texto en formato
        /// Json utilizando JsonSerializer.Deserialize.
        /// </summary>
        /// <returns>El objeto MaterialTypes convertido a texto en formato Json.</returns>
        string ConvertToJsonMaterialTypes();

        /// <summary>
        /// Convierte el objeto a texto en formato Json. El objeto puede ser reconstruido a partir del texto en formato
        /// Json utilizando JsonSerializer.Deserialize.
        /// </summary>
        /// <returns>El objeto AreaOfWork convertido a texto en formato Json.</returns>
        string ConvertToJsonAreaOfWork();
        
    }
}