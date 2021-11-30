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
        /// Compania para test
        /// </summary>
        private Company company;
        /// <summary>
        /// Id de comapania para test
        /// </summary>
        private string CompanyId = "12345";
        /// <summary>
        /// Id de emprendedor para test
        /// </summary>
        private string EntrepreneurId = "67890";
        /// <summary>
        /// Lista de ofertas para test
        /// </summary>
        private List<Offer> Catalogo;
        
        private Location LocatioEntrepreneur;
        /// <summary>
        /// Lista de permisos de un emprendedor para pruebas
        /// </summary>
        private List<Permission> EntrepreneurPermission;

        /// <summary>
        /// Lista de permisos de una  oferta para pruebas
        /// </summary>
        private List<Permission> Offerpermissions;

        /// <summary>
        /// Crea las intancias utiilzadas en los test
        /// </summary>
        [SetUp]
        public void Setup()
        {
            
            
           //COMPANIA
            Singleton<DataManager>.Instance.AddCompany(this.CompanyId,"compania 1", "098239339","Burdeos 2728","Montevideo","Montevideo","Construcción");
            //EMPRENDEDOR
            this.EntrepreneurPermission  =  new List<Permission>();
            this.EntrepreneurPermission.Add(new Permission("Materiales Peligrosos"));
            Singleton<DataManager>.Instance.AddEntrepreneur(this.EntrepreneurId,"Emprendimiento dummy","091239339","Grecias 1412","Montevideo","Montevideo","Construccion","Construccion sustentable",EntrepreneurPermission);
            
            
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
        }

        /// <summary>
        /// Prueba de creacion de offerManager
        /// </summary>
        [Test]
        public void Buy()
        {
            // GetOfferByEntrepreneur(string entrepreneurId);
            this.Catalogo = Singleton<OfferManager>.Instance.catalog;
            Singleton<OfferManager>.Instance.BuyOffer(this.EntrepreneurId,1);
            Console.WriteLine(this.Catalogo[0].Entrepreneur);
            Assert.AreEqual(this.Catalogo[0].Entrepreneur,this.EntrepreneurId);
        }
    }
} 