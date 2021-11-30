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
    /// Prueba de la clase <see cref="Permission"/>.
    /// 
    /// </summary>
    [TestFixture]
    public class PerrmissionTest
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
        /// Lista de permisos de una oferta para test
        /// </summary>
        private List<Permission> Offerpermissions;
        /// <summary>
        /// Lista de ofertas para test
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
            this.Catalogo = Singleton<OfferManager>.Instance.catalog;
            // this.entrepreneur = new Entrepreneur("3","Empre2","091234567",LocatioEntrepreneur,"Construcción","Trabajo en altura","especializacion");
        }

        /// <summary>
        /// Prueba de asignación de permisos con datamanager
        /// </summary>
        [Test]
        public void Permission()
        {
            Assert.That(this.Catalogo[0].Offerpermissions[0].Name,Contains.Substring("Materiales Peligrosos"));
            
        }
    }
} 