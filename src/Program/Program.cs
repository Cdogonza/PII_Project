//--------------------------------------------------------------------------------
// <copyright file="Program.cs" company="Universidad Católica del Uruguay">
//     Copyright (c) Programación II. Derechos reservados.
// </copyright>
//--------------------------------------------------------------------------------

using System;
using ClassLibrary;
using System.Collections;
namespace ConsoleApplication
{
    /// <summary>
    /// Programa de consola de demostración.
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// Punto de entrada al programa principal.
        /// </summary>
        public static void Main()
        {

            OfferManager catalogo = new OfferManager();
            // almacenar.AddAreaOfWork("construccion");
            // almacenar.AddAreaOfWork("carpinteria");
            
            
            // AreaOfWork carpinteria = new AreaOfWork("carpinteria");
            // AreaOfWork herreria = new AreaOfWork("herreria");
            
                            
            Company Compania1 = new Company("compania1","Construccíon");
            Console.WriteLine("Ingrese Rubro: ");
            string rubro=Console.ReadLine();

            Console.WriteLine("1 -  Ingresar una oferta  2-Ver Informacion de la empres ");
            string opcion=Console.ReadLine();
            if (opcion == "1"){
                Console.WriteLine("Ingrese nombre del producto");
                string productName=Console.ReadLine();
                
                ArrayList tags  = new ArrayList();
                tags.Add("tag1");
                tags.Add("tag");
                
                DateTime publicationDate = new DateTime(2008, 3, 1, 7, 0, 0);

                DateTime deliverydate = new DateTime();
                catalogo.PublishOffer(productName,120.5,true,"L-V",tags,deliverydate,publicationDate,Compania1);
                
                catalogo.PublishOffer("Recortes de barilla",120.5,true,"L-V",tags,deliverydate,publicationDate,Compania1);
                
                catalogo.PrintOfferts();
                
            }
            
            
            // string rubro=Console.ReadLine();
            
            // if (AreaOfWork.CheckAreaOfWork(Convert.ToInt16(rubro)))
            // {
            // }
            // else
            // {
            //     Console.WriteLine("No exite el rubro Ingresado");
            // }

            // Console.WriteLine($"{Compania1.AreaOfWork}");

            // IPermissions permiso1 = new PermissionHazardous("permiso1");
            // IPermissions permiso2 = new PermissionBase("permiso2");
            // IPermissions permiso3 = new PermissionBase("permiso3");

        //     Compania1.AddPermission(permiso1);
        //     Compania1.AddPermission(permiso2);
            
        //    // Compania1.GetPermissions();
        //     Console.WriteLine(Compania1.SearchP(permiso1));
        //     Console.WriteLine(Compania1.SearchP(permiso3));
            

        }
    }
}