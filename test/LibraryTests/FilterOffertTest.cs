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
            LocatioCompany =Loc.GetLocation("Berro 1231","Montevideo","Montevideo");
            this.company = new Company("2","compania1","098239334",LocatioCompany,"Construcción");
            DataManager dataManager  = new DataManager();
            dataManager.AddPermission("Materiales inflamables");
            dataManager.AddPermission("Residuos medicos");
            
            this.company.AddPermission(dataManager.GetPermissions()[0]);
            

            List<string> tags  = new List<string>();
            tags.Add("tag1");
            tags.Add("tag");              
            DateTime publicationDate = new DateTime(2008, 3, 1, 7, 0, 0);
            DateTime deliverydate = new DateTime();
            MaterialType materialType  =  new MaterialType("Tela", "Recortes de tela de 1x1");
            this.material =  new Material("Tela",materialType,"200");
            LocationOffer =Loc.GetLocation("Berro 1231","Montevideo","Montevideo");
            Offerpermissions.Add(new Permission("Materiales Peligrosos"));
            this.offer = new Offer(7,"Promocion de verano",this.material,1,100,LocationOffer,Offerpermissions,true,tags,deliverydate,publicationDate,this.company);
            Singleton<OfferManager>.Instance.SaveOffer(this.offer);
            LocatioEntrepreneur =Loc.GetLocation("Colorado 2326","Montevideo","Montevideo");
            Permission permissionC = new Permission("Materiales inflamables");
            
            this.entrepreneur = new Entrepreneur("3","Empre2","091234567",LocatioEntrepreneur,"Construcción","Trabajo en altura","especializacion");
            Singleton<OfferManager>.Instance.BuyOffer(this.entrepreneur,0);
        }

        /// <summary>
        /// Prueba de filtrado por ubicación
        /// </summary>
        [Test]
        public void FilterByLocation()
        {
            Assert.That(this.searcher.GetOfferByDepartment("Montevideo") ,Contains.Substring("Montevideo"));
           
            // Assert.AreEqual(Singleton<OfferManager>.Instance.catalog[0].Entrepreneur,this.entrepreneur);
        }

        /// <summary>
        /// Test Filtrado por distancia
        /// </summary>
        [Test]
        public void FilterByDistance()
        {
            Assert.That(this.searcher.GetOfferByDistance(this.entrepreneur,10) ,Contains.Substring("Tela"));
           
            // Assert.AreEqual(Singleton<OfferManager>.Instance.catalog[0].Entrepreneur,this.entrepreneur);
        }

        /// <summary>
        /// Prueba de filtrado por palabra (tag)
        /// </summary>
        [Test]
        public void FilterByWord()
        {
            Assert.That(this.searcher.GetOfferByWord("tag1"),Contains.Substring("Promoción de verano"));
            
            // Assert.AreEqual(Singleton<OfferManager>.Instance.catalog[0].Entrepreneur,this.entrepreneur);
        }

    }
} 