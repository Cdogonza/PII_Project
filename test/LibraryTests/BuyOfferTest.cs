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
    public class BuyOffer
    {
        /// <summary>
        /// emprededor para pruebas
        /// </summary>
        private Entrepreneur entrepreneur;
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
            this.offerAdmin.SaveOffer(this.offer);

            this.entrepreneur = new Entrepreneur("Empre2","091234567","Galicia 1234","Construcción","Trabajo en altura");
        }

        /// <summary>
        // /// Prueba de creacion de offerManager
        ///</summary>
        [Test]
        public void Buy()
        {
            this.offerAdmin.BuyOffer(this.entrepreneur,0);
            Assert.AreEqual(this.offerAdmin.catalog[0].Entrepreneur,this.entrepreneur);
        }
    }
} 