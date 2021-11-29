//--------------------------------------------------------------------------------
// <copyright file="TrainTests.cs" company="Universidad Católica del Uruguay">
//     Copyright (c) Programación II. Derechos reservados.
// </copyright>
//--------------------------------------------------------------------------------

using ClassLibrary;
using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Tests
{
    /// <summary>
    /// Prueba de la clase <see cref="Offer"/>.
    /// </summary>
    [TestFixture]
    public class PublishOffer
    {
        /// <summary>
        /// Catalogo para pruebas.
        /// </summary>
        private OfferManager offerAdmin;
        /// <summary>
        /// Material para pruebas
        /// </summary>
        private Material material;
        /// <summary>
        /// Compania para la empresa
        /// </summary>
        private Company company;

        /// <summary>
        /// Buscador para pruebas
        /// </summary>
        private Search searcher ;
        private Offer offer ;
        private Location LocationOffer;
        private Location LocatioCompany;
        private Location LocatioEntrepreneur;
        private List<Permission> Offerpermissions;

        /// <summary>
        /// Crea las intancias utiilzadas en los test
        /// </summary>
              
        [SetUp]
        public void Setup()
        {
            LocationApiClient Loc = new LocationApiClient();
            this.offerAdmin =  new OfferManager();
            this.searcher =  new Search();
            LocatioCompany =Loc.GetLocation("Bulevar del Bicentenario 318","Canelones","Canelones");
            this.company = new Company("1","compania1","098239334",LocatioCompany,"Construcción");
            ArrayList tags  = new ArrayList();
            tags.Add("tag1");
            tags.Add("tag");              
            DateTime publicationDate = new DateTime(2008, 3, 1, 7, 0, 0);
            DateTime deliverydate = new DateTime();
            MaterialType materialType  =  new MaterialType("Tela", "Recortes de tela de 1x1");
            LocationOffer =Loc.GetLocation("Berro 1231","Montevideo","Montevideo");
            this.material =  new Material("Tela",materialType,"200");
            this.offer = new Offer(7,"Promocion de verano",this.material,1,100,LocationOffer,Offerpermissions,true,tags,deliverydate,publicationDate,this.company);
        }

        /// <summary>
        /// Prueba de creacion de offerManager
        ///</summary>
        [Test]
        public void CompanyTest()
        {
            Assert.AreEqual(this.company.Name,"compania1");
            Assert.That(this.company.Location.FormattedAddress, Contains.Substring("Canelones"));
            Assert.AreEqual(this.company.Phone,"098239334");
            Assert.AreEqual(this.company.AreaOfWork.Name,"Construcción");
        }

        /// <summary>
        /// Prueba de creación de oferta
        ///</summary>
        [Test]
        public void OfferTest()
        {

            Assert.That(this.offer.Location.AddresLine, Contains.Substring("Berro 1231"));
            Assert.AreEqual(this.offer.Cost,200.00);
            Assert.AreEqual(this.offer.Availability,true);
            Assert.AreEqual(this.offer.Name,"Promocion de verano");

            
            Assert.AreEqual(this.offer.Material,this.material);
            ArrayList tags  = new ArrayList();
            tags.Add("tag1");
            tags.Add("tag");               
            Assert.AreEqual(this.offer.Tags,tags);
            Assert.AreEqual(this.offer.Company.Name,this.company.Name);

        }


        /// <summary>
        /// Prueba de publicación de oferta
        /// </summary>
        [Test]
        public void PublishTest()
        {

            this.offerAdmin.SaveOffer(this.offer);
            Assert.AreEqual(this.offerAdmin.catalog[0],this.offer);
        }

    }
} 