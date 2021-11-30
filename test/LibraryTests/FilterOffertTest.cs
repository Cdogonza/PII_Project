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
    /// Prueba de la clase <see cref="Search"/>.
    /// </summary>
    [TestFixture]
    public class SearchTest
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
        /// Id de compania para test
        /// </summary>
        private string CompanyId = "12345";
        /// <summary>
        /// Id de emprendedor para test
        /// </summary>
        private string EntrepreneurId = "67890";
        /// <summary>
        /// lista de permisos para pruebas
        /// </summary>
        private List<Permission> Offerpermissions;
        /// <summary>
        /// Catalago para pruebas
        /// </summary>
        private List<Offer> Catalogo;

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
        /// Prueba de filtrado por ubicación
        /// </summary>
        [Test]
        public void FilterByLocation(){
            
            Assert.That(Singleton<Search>.Instance.GetOfferByDepartment("Montevideo"),Contains.Substring("Montevideo"));
           
        }

        /// <summary>
        /// Test Filtrado por distancia
        /// </summary>
        // [Test]
        // public void FilterByDistance()
        // {
        //     Assert.That(Singleton<Search>.Instance.GetOfferByDistance(Singleton<DataManager>.Instance.entrepreneurs[0],500),Contains.Substring("Montevideo"));

        //     // Assert.That(this.searcher.GetOfferByDistance(this.entrepreneur,10) ,Contains.Substring("Tela"));
           
        //     // Assert.AreEqual(Singleton<OfferManager>.Instance.catalog[0].Entrepreneur,this.entrepreneur);
        // }

        /// <summary>
        /// Prueba de filtrado por palabra (tag)
        /// </summary>
        [Test]
        public void FilterByWord()
        {
            Assert.That(Singleton<Search>.Instance.GetOfferByWord("tag1"),Contains.Substring("Promocion de tablas"));
            
            Assert.AreEqual(Singleton<OfferManager>.Instance.catalog[0].Entrepreneur,this.EntrepreneurId);
        }

    }
} 