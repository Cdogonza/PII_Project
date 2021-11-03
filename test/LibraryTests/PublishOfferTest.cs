//--------------------------------------------------------------------------------
// <copyright file="TrainTests.cs" company="Universidad Católica del Uruguay">
//     Copyright (c) Programación II. Derechos reservados.
// </copyright>
//--------------------------------------------------------------------------------

using ClassLibrary;
using NUnit.Framework;
using System;
using System.Collections;

namespace Tests
{
    /// <summary>
    /// Prueba de la clase <see cref="OfferManager"/>.
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

        /// <summary>
        /// Crea las intancias utiilzadas en los test
        /// </summary>
        [SetUp]
        public void Setup()
        {
            this.offerAdmin =  new OfferManager();
            this.searcher =  new Search();
            this.company = new Company("compania1","098239334","Las Piedras","Construcción");
             ArrayList tags  = new ArrayList();
            tags.Add("tag1");
            tags.Add("tag");              
            DateTime publicationDate = new DateTime(2008, 3, 1, 7, 0, 0);
            DateTime deliverydate = new DateTime();
            MaterialType materialType  =  new MaterialType("Tela", "Recortes de tela de 1x1");
            this.material =  new Material("Tela",materialType,"200",100,"Berro 1231");
            this.offer = new Offer("Promocion de verano",this.material,"Berro1231",200.00,true,tags,deliverydate,publicationDate,this.company);
        }

        /// <summary>
        /// Prueba de creacion de offerManager
        ///</summary>
        [Test]
        public void CompanyTest()
        {
            Assert.AreEqual(this.company.Name,"compania1");
            Assert.AreEqual(this.company.Location,"Las Piedras");
            Assert.AreEqual(this.company.Phone,"098239334");
            
            Assert.AreEqual(this.company.AreaOfWork.Name,"Construcción");
        }

        /// <summary>
        /// Prueba de creacion de oferta
        ///</summary>
        [Test]
        public void OfferTest()
        {

            Assert.AreEqual(this.offer.Location,"Berro1231");
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
        /// Prueba de creacion de oferta
        /// </summary>
        [Test]
        public void PublishTest()
        {

            this.offerAdmin.SaveOffer(this.offer);
            Assert.AreEqual(this.offerAdmin.catalog[0],this.offer);
        }

    }
} 