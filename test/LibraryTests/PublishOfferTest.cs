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
    public class TrainTests
    {
        /// <summary>
        /// Catalogo para pruebas.
        /// </summary>
        private OfferManager oferAdmin;
        
        /// <summary>
        /// Compania para la empresa
        /// </summary>
        private Company company;

        /// <summary>
        /// Buscador para pruebas
        /// </summary>
        private Search searcher ;
        private Offer myOffer ;

        /// <summary>
        /// Crea las intancias utiilzadas en los test
        /// </summary>
        [SetUp]
        public void Setup()
        {
            this.oferAdmin =  new OfferManager();
            this.searcher =  new Search(oferAdmin);
            this.company = new Company("compania1","Las Piedras","098239334","Construcción");
             ArrayList tags  = new ArrayList();
            tags.Add("tag1");
            tags.Add("tag");              
            DateTime publicationDate = new DateTime(2008, 3, 1, 7, 0, 0);
            DateTime deliverydate = new DateTime();
            MaterialType materialType  =  new MaterialType("Tela", "Recortes de tela de 1x1");
            Material material = new Material("Tela",materialType,"200","100","Berro 1231");
            this.myOffer = new Offer("Promocion de verano",material,"Berro1231",200.00,true,tags,deliverydate,publicationDate,this.company);
        }

        /// <summary>
        // /// Prueba de creacion de offerManager
        ///</summary>
        [Test]
        public void CompaniTest()
        {
            Assert.AreEqual(this.company.Name,"compania1");
            Assert.AreEqual(this.company.Location,"Las Piedras");
            Assert.AreEqual(this.company.Phone,"098239334");
            
            Assert.AreEqual(this.company.AreaOfWork.Name,"Construcción");
        }

        [Test]
        /// <summary>
        // /// Prueba de creacion de oferta
        ///</summary>
        public void OfferTest()
        {

            Assert.AreEqual(this.myOffer.Location,"Berro1231");
            Assert.AreEqual(this.myOffer.Cost,200.00);
            Assert.AreEqual(this.myOffer.Availability,true);
            Assert.AreEqual(this.myOffer.Name,"Promocion de verano");

            MaterialType materialType  =  new MaterialType("Tela", "Recortes de tela de 1x1");
            Material material = new Material("Tela",materialType,"200","100","Berro 1231");
            Assert.AreEqual(this.myOffer.Material.Name,"Tela");
            ArrayList tags  = new ArrayList();
            tags.Add("tag1");
            tags.Add("tag");               
            Assert.AreEqual(this.myOffer.Tags,tags);
            Assert.AreEqual(this.myOffer.Company.Name,this.company.Name);

        }

    }
} 