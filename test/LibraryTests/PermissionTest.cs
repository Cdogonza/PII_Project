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
        /// Buscador para pruebas
        /// </summary>
        private Search searcher ;
        private Permission permission ;
        private DataManager dataManager;
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
            this.company = new Company("1","compania1","098239334",LocatioCompany,"Construcción");
            
            
            this.permission  = new Permission("Materiales inflamables");
            
            // ABANICO DE PERMISSIONS
            DataManager dataManager  = new DataManager();
            this.dataManager =  dataManager;
            this.dataManager.AddPermission("Materiales Peligrosos");
            //AGREGA A LA COMPANIA UN PERMISO
            this.company.AddPermission(dataManager.GetPermissions()[0]);
            ArrayList tags  = new ArrayList();
            tags.Add("tag1");
            tags.Add("tag");              
            DateTime publicationDate = new DateTime(2008, 3, 1, 7, 0, 0);
            DateTime deliverydate = new DateTime();
            MaterialType materialType  =  new MaterialType("Tela", "Recortes de tela de 1x1");
            this.material =  new Material("Tela",materialType,"200");
            this.LocationOffer =Loc.GetLocation("Berro 1231","Montevideo","Montevideo");
            this.offer = new Offer(7,"Promocion de verano",this.material,1,100,LocationOffer,Offerpermissions,true,tags,deliverydate,publicationDate,this.company);
            this.offerAdmin.SaveOffer(this.offer);
            LocatioEntrepreneur =Loc.GetLocation("Colorado 2326","Montevideo","Montevideo");
            this.entrepreneur = new Entrepreneur("3","Empre2","091234567",LocatioEntrepreneur,"Construcción","Trabajo en altura","especializacion");
        }

        /// <summary>
        /// Prueba de asignación de permisos con datamanager
        /// </summary>
        [Test]
        public void Permission()
        {
            Assert.That(this.company.GetPermissions(),Contains.Substring("Materiales inflamables"));
            
        }
    }
} 