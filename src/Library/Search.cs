using System;
using System.Collections.Generic;
namespace ClassLibrary
{
    /// <summary>
    /// Esta clase filtra el catálogo según diferentes términos
    /// </summary>
    public class Search
    {
        /// <summary>
        /// Crea una lista de ofertas vacía
        /// </summary>
        private List<Offer> catalog = new List<Offer>();
        /// <summary>
        /// Constructor - carga una copia del catalogo de ofertas a la lista
        /// </summary>
        public Search()
        {
            this.catalog = OfferManager.catalog;
        }
        /// <summary>
        /// Filtra el catálogo de ofertas según su ubicación
        /// </summary>
        /// <param name="location"></param>
        /// <returns>Retorna un string con una lista de ofertas</returns>
        public string GetOfferByLocation(string location)
        {
            List<Offer> byLocation = new List<Offer>();

            string data = $"Las ofertas con esta ubicación son: \n";

            foreach (Offer offer in catalog)
            {
                if (offer.Location == location)
                {
                    data = data + $"ID: {offer.id} Name: {offer.Name} - Material: {offer.Material} - Cost: {offer.Cost}  Fecha y hora de publicacion {offer.PublicationDate} \n";
                    byLocation.Add(offer);
                }
            }
            return data;
        }
        /// <summary>
        /// Filtra el catálogo de ofertas según palabras clave
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
                    data = data + $"ID: {offer.id} Name: {offer.Name} - Material: {offer.Material} - Cost: {offer.Cost}  Fecha y hora de publicacion {offer.PublicationDate} \n";
                    byWord.Add(offer);
                }
            }
            return data;

        }
        /// <summary>
        /// Filtra el catálogo de ofertas según su categoria
        /// </summary>
        /// <param name="category"></param>
        /// <returns>Retorna un string con una lista de ofertas</returns>
        public string GetOfferByCategory(string category)
        {
            List<Offer> byCategory = new List<Offer>();

            string data = $"Las ofertas con esta categoria son: \n";

            foreach (Offer offer in catalog)
            {
                if (offer.Company.AreaOfWork.Name == category)
                {
                    data = data + $"ID: {offer.id} Name: {offer.Name} - Material: {offer.Material} - Cost: {offer.Cost}  Fecha y hora de publicacion {offer.PublicationDate} \n";
                    byCategory.Add(offer);
                }
            }
            return data;
        }
        /// <summary>
        /// Filtra el catálogo de ofertas y agrupa las que compró un emprendedor
        /// </summary>
        /// <param name="entrepreneur"></param>
        /// <returns>Retorna un string con una lista de ofertas</returns>
        public string GetMyEntrepreneur(Entrepreneur entrepreneur)
        {
            string data = $"Las compras de este emprendedor son: \n";

            foreach (Offer offer in catalog)
            {
                if(offer.Entrepreneur == entrepreneur)
                {
                    data = data + $"ID: {offer.id} Name: {offer.Name} - Material: {offer.Material} - Cost: {offer.Cost}  Fecha y hora de publicacion {offer.PublicationDate} \n";
                }
            }
            return data;
        }

        /// <summary>
        /// Filtra el catálogo de ofertas y agrupa las que publicó una empresa
        /// </summary>
        /// <param name="company"></param>
        /// <returns>Retorna un string con una lista de ofertas</returns>
        public string GetByCompany(Company company)
        {

            string data = $"Las ofertas de la empresa son: \n";

            foreach (Offer offer in catalog)
            {
                if(offer.Company == company)
                {
                    data = data + $"ID: {offer.id} Name: {offer.Name} - Material: {offer.Material} - Cost: {offer.Cost}  Fecha y hora de publicacion {offer.PublicationDate} \n";
                }
            }
            return data;
        }

        /// <summary>
        /// Filtra el catálogo de ofertas y agrupa las que están disponibles 
        /// y fueron publicadas por determinada compañia
        /// </summary>
        /// <param name="company"></param>
        /// <returns>Retorna un string con una lista de ofertas</returns>
        public string GetAvailableOffersByCompany(Company company)
        {

            string data = $"Las ofertas habilitadas para la compania son: \n";

            foreach (Offer offer in catalog)
            {
                if(offer.Company == company)
                {
                    if(offer.Availability)
                    {
                        data = data + $"ID: {offer.id} Name: {offer.Name} - Material: {offer.Material} - Cost: {offer.Cost}  Fecha y hora de publicacion {offer.PublicationDate} \n";
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