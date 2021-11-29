using System.Collections.Generic;
using System.Collections;
using System;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
namespace ClassLibrary
{   
    /// <summary>
    /// En esta clase se puede ver el uso del patron Expert, y aque es experto en el manejo
    /// de las ofertas de la aplicacion, incluso cuando se instancia esta clase la instanciamos
    /// a traves de singleton de modo de manejar una unica instancia.
    /// </summary>
    public class OfferManager : IJsonConvertible
    {
        /// <summary>
        /// Catalogo de ofertas de nuestra aplicacion
        /// </summary>
        /// <typeparam List="Offer"></typeparam>
        /// <returns></returns>
        [JsonInclude]
        public List<Offer> catalog = new List<Offer>();
        /// <summary>
        /// Este es el constructor de la clase
        /// </summary>
           [JsonConstructor] 
           public OfferManager()
        {
            this.catalog = new List<Offer>();
        }
        /// <summary>
        /// Este metodo lo que hace es, una vez creada la oferta se guarda en el catalogo de la aplicacion
        /// </summary>
        /// <param name="offer"></param>
       public void SaveOffer(Offer offer)
        {   
            catalog.Add(offer);
        }
        /// <summary>
        /// Este metodo se utiliza para re publicar ofertas que son priodicas 
        /// </summary>
        /// <param name="id"></param>
        public void PublishOffer(int id)
        {
           Offer offer = catalog[id];
            offer.Availability = true;
        }
        /// <summary>
        /// Este metodo desabilita una oferta del catalogo
        /// </summary>
        /// <param name="id"></param>
        public void DiseableOffer(int id)
        {
           Offer offer = catalog[id];
            offer.Availability = false;
        }

        /// <summary>
        /// Este metodo retorna las ofertas del catalogo que estan habilitadas
        /// </summary>
        /// <returns></returns>
       public string GetOffersAvailability()
        {
            string data = $"Las ofertas habilitadas son: \n";
            foreach (Offer offer in catalog)
            {
                if(offer.Availability)
                {
                    data = data + $"{offer.Idd} {offer.Name} Costo {offer.Cost} Fecha y hora de publicacion {offer.PublicationDate} \n";
                }
                else
                {
                    data = "No tienes Ofertas habilitadas para mostrar";
                }
                
            }
            return data;
        }
        /// <summary>
        /// El metodo siguiente permite comprar la oferta al emprendedor
        /// </summary>
        /// <param name="buyer"></param>
        /// <param name="index"></param>
        public void BuyOffer(Entrepreneur buyer,int index)
        {
            catalog[index].getOffer(buyer);

        }

        /// <summary>
        ///  El metodo crea una instacia de la oferta y la agrega al catalogo.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="material"></param>
        /// <param name="street"></param>
        /// <param name="city"></param>
        /// <param name="department"></param>
        /// <param name="cost"></param>
        /// <param name="regularoffers"></param>
        /// <param name="tags"></param>
        /// <param name="deliverydate"></param>
        /// <param name="publicationdate"></param>
        /// <param name="offer"></param>
        public void AddOffer (string name, Material material, int quantity, double cost, string street, string city , string department ,List<Permission> offerpermissions, bool regularoffers, ArrayList tags, DateTime deliverydate, DateTime publicationdate, Company company)
        {
            LocationApiClient Loc = new LocationApiClient();
            Location locationoffer = Loc.GetLocation(street,city,department);
            Singleton<OfferManager>.Instance.LoadFromJsonOffer();
            long valorUltimoId = this.catalog.Count+1;
            this.catalog.Add(new Offer(valorUltimoId, name, material, quantity, cost, locationoffer, offerpermissions, regularoffers, tags, deliverydate, publicationdate, company));
            this.ConvertToJsonOffer();
        }
        public string ConvertToJsonOffer()
        {
            string result = "{\"Items\":[";

            foreach (Offer item in this.catalog)
            {
                result = result + item.ConvertToJsonOffer() + ",";
            }

            result = result.Remove(result.Length - 1);
            result = result + "]}";

            string temp = JsonSerializer.Serialize(this.catalog);
             File.WriteAllText(@"Offer.json", temp);
            return result;
            JsonSerializerOptions options = new()
            {
                ReferenceHandler = MyReferenceHandler.Instance,
                WriteIndented = true
            };

            return JsonSerializer.Serialize(this.catalog, options);            
        }
        public void LoadFromJsonOffer()
        {
            
            string json = File.ReadAllText(@"Offer.json");
            if(json!="")
            {

            JsonSerializerOptions options = new()
            {
                ReferenceHandler = MyReferenceHandler.Instance,
                WriteIndented = true
            };

            this.catalog = JsonSerializer.Deserialize<List<Offer>>(json, options);
           
            }
        }
        public string ConvertToJsonEntrepreneur()
        {return null;}
          public string ConvertToJsonCompany()
        {return null;}

    }

}