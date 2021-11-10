using System.Collections.Generic;
using System.Collections;
using System;
namespace ClassLibrary
{
    /// <summary>
    /// Esta clase esteblece los parametros necesarios para la creacion de la oferta/.
    /// Implementa el patron SRP ya que tiene una unica razon de cambio
    /// </summary>
    public class Offer
    {
        /// <summary>
        /// Nombre de la oferta
        /// </summary>
        /// <value></value>
        public string Name {get;set;}
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
        public ArrayList Tags{get;set;}
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
        public Entrepreneur Entrepreneur {get;set;}
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
        public List<Permission> offerpermissions = new List<Permission>();
        /// <summary>
        /// El id lo utilizamos para identificar cada oferta en el catalogo
        /// </summary>
        /// <value></value>
        public int id {get;}
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
        public Offer(string name, Material material, Location location, double cost, bool regularoffers, ArrayList tags, DateTime deliverydate, DateTime publicationdate, Company offer)
        {
            this.id = id +1;
            this.Name = name;
            this.Material = material;
            this.Location = location;
            this.Cost = cost;
            this.Availability = true;
            this.Tags = tags;
            this.DeliveryDate = deliverydate;
            this.PublicationDate = publicationdate;
            this.Company =  offer;
            this.RegularOffers = regularoffers;
        }
        /// <summary>
        /// Permite agregar permisos a la oferta
        /// </summary>
        /// <param name="permission"></param>
        public void AddPermission(string permission)
        {
            Permission newPermission = new Permission(permission);
            offerpermissions.Add(newPermission);
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
            if (this.Availability)
            {
                this.Entrepreneur = entrepreneur;
                this.Availability = false;          
            }
            return this.Company.DataCompany();
        }
      
        
    }
}