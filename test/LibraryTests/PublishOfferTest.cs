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
        /// Id de compania para test
        /// </summary>
        private string CompanyId = "12345";
        
        /// <summary>
        /// Id de emprendedor para test
        /// </summary>
        /// <summary>
        /// lista de permisos para pruebas
        /// </summary>
        private List<Permission> Offerpermissions;
        private string EntrepreneurId = "67890";

        private List<Offer> Catalogo;
        /// <summary>
        /// Compania para la empresa
        /// </summary>
        /// 
        private Company company;

        /// <summary>
        /// Buscador para pruebas
        /// </summary>
        private Search searcher ;
        private Offer offer ;
        private Location LocationOffer;
        private Location LocatioCompany;
        private Location LocatioEntrepreneur;

        /// <summary>
        /// Crea las intancias utiilzadas en los test
        /// </summary>
              
        [SetUp]
        public void Setup()
        {
            
            //COMPANIA
            Singleton<DataManager>.Instance.AddCompany(this.CompanyId,"compania 1", "098239339","Burdeos 2728","Montevideo","Montevideo","Construcción");
            //OFERTA
            LocationApiClient Loc = new LocationApiClient();
            List<string> tags  = new List<string>();
            tags.Add("tag1");
            tags.Add("tag");              
            
            DateTime publicationDate = new DateTime(2008, 3, 1, 7, 0, 0);
            DateTime deliverydate = new DateTime();
            
            
            this.Offerpermissions  =  new List<Permission>();
            this.Offerpermissions.Add(new Permission("Materiales Peligrosos"));
            Singleton<OfferManager>.Instance.AddOffer("Promocion de tablas",new Material("Maderas",Singleton<DataManager>.Instance.GetMaterialTypeByIndex(0),"kg"), 100, 1200,"Burdeos 2728", "Montevideo", "Montevideo", this.Offerpermissions, false, tags,deliverydate, publicationDate, company);
            Singleton<OfferManager>.Instance.PublishOffer(0);
            
            this.Catalogo = Singleton<OfferManager>.Instance.catalog;

        }

        /// <summary>
        /// Prueba de creacion de offerManager
        ///</summary>
        [Test]
        public void CompanyTest()
        {
            Assert.AreEqual(Singleton<DataManager>.Instance.GetCompanyInstance(this.CompanyId).Name,"compania 1");
            Assert.That(Singleton<DataManager>.Instance.GetCompanyInstance(this.CompanyId).Location.FormattedAddress, Contains.Substring("Montevideo"));
            Assert.AreEqual(Singleton<DataManager>.Instance.GetCompanyInstance(this.CompanyId).Phone,"098239339");
        }

        /// <summary>
        /// Prueba de creación de oferta
        ///</summary>
        [Test]
        public void OfferTest()
        {
            Assert.That(this.Catalogo[0].Location.AddresLine, Contains.Substring("Burdeos 2728"));
            Assert.AreEqual(this.Catalogo[0].Cost,1200);
            Assert.AreEqual(this.Catalogo[0].Availability,true);
            Assert.AreEqual(this.Catalogo[0].Name,"Promocion de tablas");
            ArrayList tags  = new ArrayList();
            tags.Add("tag1");
            tags.Add("tag");              
            Assert.AreEqual(this.Catalogo[0].Tags,tags);
        }



    }
} 