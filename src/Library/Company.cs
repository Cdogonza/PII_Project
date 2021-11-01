using System.Collections.Generic;
using System;
using System.Collections;

namespace ClassLibrary
{   
    /// <summary>
    /// 
    /// </summary>
    public class Company : UserBase
    {
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public AreaOfWork AreaOfWork {get; set;}
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public string Location{get; set;}
        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="location"></param>
        /// <param name="phone"></param>
        /// <param name="area"></param>
        /// <returns></returns>
        public Company(string name,string location,int phone,string area) : base (name,phone)
        {
            this.AreaOfWork = new AreaOfWork(area);   
            this.Location = location;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>  
        public List<string> DataCompany()
        {
            List <string> data = new List<string>();  
            data.Add(this.Name);
            data.Add(Convert.ToString(this.Phone));
            data.Add(this.Location);
            return data;
        }
    

    }

}