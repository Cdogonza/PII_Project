using System.Collections.Generic;
using System.Collections;
using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telegram.Bot.Requests;

namespace ClassLibrary
{
    /// <summary>
    /// Esta clase esteblece los parametros necesarios para la creacion de la oferta/.
    /// Implementa el patron SRP ya que tiene una unica razon de cambio
    /// </summary>
    public class Offer : IJsonConvertible
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="Offer"></typeparam>
        /// <returns></returns>
        public List<Offer> catalog = new List<Offer>();
        /// <summary>
        /// Nombre de la oferta
        /// </summary>
        /// <value></value>
        public string Name {get;set;}
        /// <summary>
        /// Cantidad de unidades a ofrecer 
        /// </summary>
        /// <value></value>
        public int Quantity {get; set;}
        /// <summary>
        /// Costo en caso de que tenga
        /// </summary>
        /// <value></value>
        public double Cost{get;set;}
        /// <summary>
        /// Ubicacion donde la company tiene el material de la oferta
        /// </summary>
        /// <value></value>
        public Location Location{get;set;}
        /// <summary>
        /// Establece si la oferta esta disponible para algun emprendedor o simplemente esta creada pero no disponible
        /// </summary>
        /// <value></value>
        public bool Availability{get;set;}
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public bool RegularOffers{get;set;}
        /// <summary>
        /// Palabras claves para darle la facilidad al emprendedor de encontrar la oferta
        /// </summary>
        /// <value></value>
        public List<String> Tags{get;set;}
        /// <summary>
        /// Fecha de compra de la oferta
        /// </summary>
        /// <value></value>
        public DateTime DeliveryDate{get;set;}
        /// <summary>
        /// Fecha de la publicacion de la oferta
        /// </summary>
        /// <value></value>
        public DateTime PublicationDate{get;set;}
        /// <summary>
        /// Company que creo la oferta
        /// </summary>
        /// <value></value>
        public Company Company {get;set;}
        /// <summary>
        /// Este parametro esta vacio hasta un emprendedor adquiere la oferta
        /// </summary>
        /// <value></value>
        //public Entrepreneur Entrepreneur {get;set;}
        /// <summary>
        /// Establece el material de la oferta
        /// </summary>
        /// <value></value>
        public Material Material{get;set;}
        /// <summary>
        /// La lista de permisos que tiene que tener el emprendedor para adquirir la la oferta
        /// </summary>
        /// <typeparam List="Permission"></typeparam>
        /// <returns></returns>
        public List<Permission> Offerpermissions {get;set;}
        /// <summary>
        /// El id lo utilizamos para identificar cada oferta en el catalogo
        /// </summary>
        /// <value></value>
        public long Idd {get;set;}
        public string Entrepreneur{get;set;}
        /// <summary>
        /// Este es el constructor de la oferta que recibe los parametros para crear la misma
        /// </summary>
        /// <param name="name"></param>
        /// <param name="material"></param>
        /// <param name="location"></param>
        /// <param name="cost"></param>
        /// <param name="regularoffers"></param>
        /// <param name="tags"></param>
        /// <param name="deliverydate"></param>
        /// <param name="publicationdate"></param>
        /// <param name="offer"></param>
        
         [JsonConstructor]
         public Offer()
         {

         }
         public Offer(long id,string name, Material material, int quantity, double cost, Location location, List<Permission> offerpermissions, bool regularoffers, List<string> tags, DateTime deliverydate, DateTime publicationdate, Company offer)
        {
            this.Idd = id;
            this.Name = name;
            this.Material = material;
            this.Location = location;
            this.Quantity = quantity;
            this.Cost = cost;
            this.Offerpermissions = offerpermissions;
            this.Availability = true;
            this.Entrepreneur="";
            this.Tags = tags;
            this.DeliveryDate = deliverydate;
            this.PublicationDate = publicationdate;
            this.Company =  offer;
            this.RegularOffers = regularoffers;
        }
      
        public void AddPermission(string permission)
        {
            Permission newPermission = new Permission(permission);
            Offerpermissions.Add(newPermission);
        }
        /// <summary>
        /// Metodo que retorna los datos de la empresa para ser enviados al emprendedor que compro la oferta
        /// A su vez deja como no disponible la oferta en el catalogo
        /// y coloca el nombre del emprendedor a la oferta
        /// </summary>
        /// <param name="entrepreneur"></param>
        /// <returns></returns>
        public List<string> getOffer(Entrepreneur entrepreneur)
        {
            Singleton<OfferManager>.Instance.LoadFromJsonOffer();
            this.catalog = Singleton<OfferManager>.Instance.catalog; 
            if (this.Availability)
            {
               // this.Entrepreneur = entrepreneur;
                this.Availability = false;          
            }
            return null;
           
        }
        public string ConvertToJsonCompany()
        {
            return null;
        }
        public string ConvertToJsonEntrepreneur()
        {return null;}
        public string ConvertToJsonOffer()
        {
           return JsonSerializer.Serialize(this);
        }
        public string ConvertToJsonPermissions()
        {return null;}
        public string ConvertToJsonMaterialTypes()
        {return null;}
        public string ConvertToJsonAreaOfWork()
        {return null;}
    }
}