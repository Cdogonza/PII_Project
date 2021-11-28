using System;
using System.Collections.Generic;

namespace ClassLibrary
{
    /// <summary>
    /// Esta clase es la responsable en las busquedas dentro del catalogo de ofertas de la aplicacion
    /// </summary>
    
    public class Search
    {
        /// <summary>
        /// Crea una lista de ofertas vacía
        /// </summary>
        public List<Offer> catalog = new List<Offer>();
        /// <summary>
        /// Carga una copia del catalogo de ofertas a la lista
        /// </summary>
        public Search()
        {
             Singleton<OfferManager>.Instance.LoadFromJsonOffer();
            
        }
        /// <summary>
        /// Filtra el catálogo de búsquedas según su ubicación
        /// </summary>
        /// <param name="department"></param>
        /// <returns>Retorna un string con una lista de ofertas</returns>
        public string GetOfferByDepartment(string department)
        {
            
            this.catalog = Singleton<OfferManager>.Instance.catalog;
            
            string data="";
            string title = $"Las ofertas en {department} son:";
            int cont=0;

            foreach (Offer offer in this.catalog)
            {   
               
                if (offer.Location.Locality == department)
                {                  
                    data += $"{offer.Idd}- Oferta:{offer.Name}-\n Material: {offer.Material.Name}-\nCosto: {offer.Cost}-\nFecha de publicación: {offer.PublicationDate}-\nDireccion: {offer.Location.FormattedAddress}\n - /Obtener_Oferta";
                    
                    cont++;
                }
            }
          
           if(data =="")
           {
               data ="No hay Ofertas por el departamento ingresado /help";  
               return data;        
           }else
           {
               return title + data;
           }
        }

               /// <summary>
        /// Metodo para filtrar las ofertas que estan dentro de un rango de distancia entre la oferta y el emprendedor 
        /// </summary>
        /// <param name="entrepreneur"></param>
        /// <param name="inputdistance"></param>
        /// <returns>Retorna un string con una lista de ofertas</returns>
        public string GetOfferByDistance(Entrepreneur entrepreneur, int inputdistance)
        {
            List<Offer> byDistance = new List<Offer>();
            
            LocationApiClient client = new LocationApiClient();
            
            string data = $"Las ofertas encontradas dentro de la distancia ingresada son: \n";

            foreach (Offer offer in catalog)
            {
                Distance distance = client.GetDistance(entrepreneur.Location, offer.Location);

                if ( distance.TravelDistance <= Convert.ToDouble(inputdistance))
                {
                    data = data + $"ID: {offer.Idd} Name: {offer.Name} - Material: {offer.Material.Name} - Cost: {offer.Cost}  Fecha y hora de publicacion {offer.PublicationDate} Ubicación: {offer.Location.FormattedAddress} Distancia: {distance.TravelDistance}km \n ";
                    byDistance.Add(offer);
                }
            }
            return data;
        }

        /// <summary>
        /// Filtra el catálogo de búsquedas según palabras clave
        /// </summary>
        /// <param name="word"></param>
        /// <returns>Retorna un string con una lista de ofertas</returns>
        public string GetOfferByWord(string word)
        {
            List<Offer> byWord = new List<Offer>();

            string data = $"Las ofertas con estas palabras clave son: \n";

            foreach (Offer offer in catalog)
            {
                if (offer.Tags.Contains(word))
                {
                    data = data + $"ID: {offer.Idd} Name: {offer.Name} - Material: {offer.Material.Name} - Cost: {offer.Cost}  Fecha y hora de publicacion {offer.PublicationDate} \n";
                    byWord.Add(offer);
                }
            }
            return data;

        }
       
        /// <summary>
        /// Filtra el catálogo de ofertas según su categoria (tipo de material)
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        public string GetOfferByCategory(string category)
        {
            List<Offer> byCategory = new List<Offer>();

            string data = $"Las ofertas con esta categoria son: \n";

            foreach (Offer offer in catalog)
            {
                if (offer.Material.Type.Name == category)
                {
                    data = data + $"ID: {offer.Idd} Name: {offer.Name} - Material: {offer.Material.Name} - Cost: {offer.Cost}  Fecha y hora de publicacion {offer.PublicationDate} \n";
                    byCategory.Add(offer);
                }
            }
            return data;
        }
        /// <summary>
        /// Filtra el catálogo de búsquedas que compró un emprendedor
        /// </summary>
        /// <param name="entrepreneur"></param>
        /// <returns>Retorna un string con una lista de ofertas</returns>
        public string GetOfferByEntrepreneur(string entrepreneur)
        {
            this.catalog = Singleton<OfferManager>.Instance.catalog;

            string title = $"Las ofertas adquiridas por el emprendimiento {entrepreneur} son: \n";
            string data = "";
            int cont = 0;

           /* foreach (Offer offer in this.catalog)
            {
                if (offer.Entrepreneur.Name == entrepreneur)
                {
                    data += $"{offer.Idd}) Oferta:{offer.Name}\n  - Material: {offer.Material.Name}\n  - Costo: {offer.Cost}\n  - Fecha de publicación: {offer.PublicationDate}\n  - Dirección: {offer.Location.FormattedAddress}";
                    cont ++;
                }
            }

            if (data == "")
            {
                data = $"No hay ofertas adquiridas por el emprendimiento {entrepreneur}";
                return data;
            }else{*/
                return title + data;
            //}
        }
        /// <summary>
        /// Filtra el catálogo de búsquedas que publicó una empresa
        /// </summary>
        /// <param name="company"></param>
        /// <returns>Retorna un string con una lista de ofertas</returns>
        public string GetOfferByCompany(string companyId)
        {
            this.catalog = Singleton<OfferManager>.Instance.catalog;

            string title = $"Sus ofertas son: \n";
            string data = "";
            int cont = 0;

            foreach (Offer offer in this.catalog)
            {
                if (offer.Company.Id == companyId)
                {
                    data += $"{offer.Idd}) Oferta:{offer.Name}\n  - Material: {offer.Material.Name}\n  - Costo: {offer.Cost}\n  - Fecha de publicación: {offer.PublicationDate}\n  - Dirección: {offer.Location.FormattedAddress}";
                    cont ++;
                }
            }

            if (data == "")
            {
                data = $"No tiene ofertas";
                return data;
            }else
            {
                return title + data;
            }
            
        }


        /// <summary>
        /// Filtra el catálogo de ofertas y agrupa las que están disponibles 
        /// y fueron publicadas por determinada compañia
        /// </summary>
        /// <param name="company"></param>
        /// <returns>Retorna un string con una lista de ofertas</returns>
        public string GetAvailableOffersByCompany(Company company)
        {

            string data = $"Las ofertas habilitadas para la empresa son: \n";

            foreach (Offer offer in catalog)
            {
                if(offer.Company == company)
                { 
                    if(offer.Availability)
                    {
                        data = data + $"ID: {offer.Idd} Name: {offer.Name} - Material: {offer.Material.Name} - Cost: {offer.Cost}  Fecha y hora de publicacion {offer.PublicationDate} \n";
                    }
                    else
                    {
                        data = "No tienes Ofertas habilitadas para mostrar";
                    }
                }
            }
            return data;
        }
    }
}