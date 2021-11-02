using System.Collections.Generic;
using System.Collections;
using System;
namespace ClassLibrary
{
    /// <summary>
    /// ESTA CLASE ESTEBLECE LOS PARAMETROS NECESARIOS PARA LA CREACION DE LA OFERTA
    /// </summary>
    public class Offer
    {
        //public string Material{get;set;}
        /// <summary>
        /// NOMBRE DE LA OFERTA
        /// </summary>
        /// <value></value>
        public string Name {get;set;}
        /// <summary>
        /// COSTO EN CASO DE QUE TENGA 
        /// </summary>
        /// <value></value>
        public double Cost{get;set;}
        /// <summary>
        /// UBICACION DONDE LA COMPANY TIENE EL MATERIAL DE LA OFERTA
        /// </summary>
        /// <value></value>
        public string Location{get;set;}
        /// <summary>
        /// ESTABLECE SI LA OFERTA ESTA DISPONIBLE PARA ALGUN EMPRENDEDOR O SIMPLEMENTE ESTA CREADA
        /// </summary>
        /// <value></value>
        public bool Availability{get;set;}
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public bool RegularOffers{get;set;}
        /// <summary>
        /// PALABRAS CLAVES PARA DARLE FACILIDAD AL EMPRENDEDOR DE ENCONTRAR LA OFERTA
        /// </summary>
        /// <value></value>
        public ArrayList Tags{get;set;}
        /// <summary>
        /// FECHA DE COMPRA DE LA OFERTA
        /// </summary>
        /// <value></value>
        public DateTime DeliveryDate{get;set;}
        /// <summary>
        /// FECHA DE PUBLICACION DE LA OFERTA
        /// </summary>
        /// <value></value>
        public DateTime PublicationDate{get;set;}
        /// <summary>
        /// COMPANY QUE CREO LA OFERTA
        /// </summary>
        /// <value></value>
        public Company Company {get;set;}
        /// <summary>
        /// ESTE PARAMETRO ESTA VACIO HASTA UN EMPRENDEDOR ADQUIERE LA OFERTA
        /// </summary>
        /// <value></value>
        public Entrepreneur Entrepreneur {get;set;}
        /// <summary>
        ///CORRESPONDE AL MATERIAL DE LA OFERTA
        /// /// </summary>
        /// <value></value>
        public Materials Material{get;set;}
        /// <summary>
        /// LOS PERMISOS NECESARIOS QUE DEBE DE TENER EL EMPRENDEDOR PARA PODER ADQUIRIR ESTA OFERTA
        /// </summary>
        /// <typeparam List="Permission"></typeparam>
        /// <returns></returns>
        public List<Permission> permissions = new List<Permission>();
        /// <summary>
        /// EL ID LO UTILIZAMOS PARA IDENTIFICAR CADA OFERTA EN EL CATALOGO
        /// </summary>
        /// <value></value>
        public int id {get;}
        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="material"></param>
        /// <param name="location"></param>
        /// <param name="cost"></param>
        /// <param name="availability"></param>
        /// <param name="tags"></param>
        /// <param name="deliverydate"></param>
        /// <param name="publicationdate"></param>
        /// <param name="offer"></param>
        /// <param name="regularoffers"></param>
        public Offer(string name, Materials material, string location, double cost,bool availability, bool regularoffers, ArrayList tags, DateTime deliverydate, DateTime publicationdate, Company offer)
        {
            this.id = id +1; 
            this.Name = name;
            this.Material = material;
            this.Location = location;
            this.Cost = cost;
            this.Availability = availability;
            this.Tags = tags;
            this.DeliveryDate = deliverydate;
            this.PublicationDate = publicationdate;
            this.Company =  offer;
            this.RegularOffers = regularoffers;
        }
        /// <summary>
        /// PERMITE AGREGAR PERMISOS A LA OFERTA 
        /// </summary>
        /// <param name="permission"></param>
        public void AddPermission(string permission)
        {
            Permission newPermission = new Permission(permission);
            permissions.Add(newPermission);
        }
        /// <summary>
        /// METODO QUE RETORNA LOS DATOS DE LA EMPRERSA PARA SER ENVIADOS AL EMPRENDEDOR QUE COMPRO LA OFERTA
        /// A SU VEZ DEJA COMO NO DISPONIBLE LA OFERTA EN EL CATALOGO
        /// Y COLOCA EL NOMBRE DEL EMPRENDEDOR A LA OFERTA
        /// </summary>
        /// <param name="entrepreneur"></param>
        /// <returns></returns>
        public List<string> getOffert(Entrepreneur entrepreneur)
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