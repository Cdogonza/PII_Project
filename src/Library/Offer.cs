using System.Collections.Generic;
using System.Collections;
using System;
namespace ClassLibrary
{
    /// <summary>
    /// 
    /// </summary>
    public class Offer
    {
        //public string Material{get;set;}
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public string Name {get;set;}
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public double Cost{get;set;}
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public string Location{get;set;}
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public bool Availability{get;set;}
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public string RegularOffers{get;set;}
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public ArrayList Tags{get;set;}
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public DateTime DeliveryDate{get;set;}
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public DateTime PublicationDate{get;set;}
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public Company Company {get;set;}
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public Entrepreneur Entrepreneur {get;set;}
        public Materials Material{get;set;}
        public List<Permission> permissions = new List<Permission>();
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public int id {get;}
        
        public Offer(string name, Materials material, string location, double cost,bool availability, /*string regularoffers*/ ArrayList tags, DateTime deliverydate, DateTime publicationdate, Company offer)
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
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="permission"></param>
        public void AddPermission(string permission)
        {
            Permission newPermission = new Permission(permission);
            permissions.Add(newPermission);
        }
        /// <summary>
        /// 
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