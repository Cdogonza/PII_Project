
﻿//--------------------------------------------------------------------------------
// <copyright file="Program.cs" company="Universidad Católica del Uruguay">
//     Copyright (c) Programación II. Derechos reservados.
// </copyright>
//--------------------------------------------------------------------------------

using System;
using ClassLibrary;
using System.Collections;
using System.Collections.Generic;
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

        }
    }
}

           /* OfferManager catalogo = new OfferManager();
            // almacenar.AddAreaOfWork("construccion");
            // almacenar.AddAreaOfWork("carpinteria");

                   
//             // AreaOfWork carpinteria = new AreaOfWork("carpinteria");

//             // AreaOfWork herreria = new AreaOfWork("herreria");       
                            
//             Company Compania1 = new Company("compania1","Las Piedras",0910101011,"Construccíon");

//             bool salida = true;
//             while (salida)
//             {
//             Console.WriteLine("1 -  Ingresar una oferta  2-Ver Informacion de la empres ");
//             string opcion=Console.ReadLine();
//             if (opcion == "1")
//             {
//                 Console.WriteLine("Ingrese nombre de al Oferta");

//                 string OfferName=Console.ReadLine();
//                 Console.WriteLine("Ingrese nombre de los materiales que desea publicar en la oferta");
//                 string materialname=Console.ReadLine();
//                 Console.WriteLine("Ingrese la descripcion de los materiales");
//                 string materialdescription=Console.ReadLine();
//                 Console.WriteLine("Ingrese el costo");
//                 int cost=Int32.Parse(Console.ReadLine());
//                 ArrayList tags  = new ArrayList();
//                 tags.Add("tag1");
//                 tags.Add("tag");              
//                 DateTime publicationDate = new DateTime(2008, 3, 1, 7, 0, 0);
//                 DateTime deliverydate = new DateTime();
//                 Console.WriteLine("Desea que la oferta quede publicada?");
//                 Console.WriteLine("1-Si/2-No");
//                 string answer=Console.ReadLine();
//                 bool availability;
//                 if (answer == "1")
//                 { 
//                     availability=true;                  
//                     Offer myoffer = new Offer(OfferName,materialname,"Berro 1231",materialdescription,cost,availability,tags,deliverydate,publicationDate,Compania1);
//                     catalogo.SaveOffer(myoffer);
                    
//                 }
//                 else
//                 {
//                     availability = false;
//                     Offer myoffer = new Offer(OfferName,materialname,"Berro 1231",materialdescription,cost,availability,tags,deliverydate,publicationDate,Compania1);  
//                     catalogo.SaveOffer(myoffer);  
                    
//                 }   

//                 Console.WriteLine("Desea Salir?");
//                 Console.WriteLine("1-Si/2-No");
//                 string answer2=Console.ReadLine();
//                 if (answer2 == "1")
//                 {
//                     salida = false;
//                 }

//             }
     
//         }

//             IPrinter printer1 = new ConsolePrinter();
//             printer1.PrintOffertsAvailability(catalogo);
//             //IPrinter printer2 = new ConsolePrinter();
//             printer1.PrintMyOffertsAvailability(catalogo, Compania1); 

//             Company Compania2 = new Company("compania1","Las Piedras",0910101011,"Construccíon");
//             bool salida2 = true;
//             while (salida2)
//             {
//             Console.WriteLine("1 -  Ingresar una oferta  2-Ver Informacion de la empres ");
//             string opcion2=Console.ReadLine();
//             if (opcion2 == "1"){
//                 Console.WriteLine("Ingrese nombre de al Oferta");
//                 string OfferName=Console.ReadLine();
//                 Console.WriteLine("Ingrese nombre del los materiales que desea publicar en la oferta");
//                 string materialname=Console.ReadLine();
//                 Console.WriteLine("Ingrese la descripcion de los materiales");
//                 string materialdescription=Console.ReadLine();
//                 Console.WriteLine("Ingrese el costo");
//                 int cost=Int32.Parse(Console.ReadLine());
//                 ArrayList tags  = new ArrayList();
//                 tags.Add("tag1");
//                 tags.Add("tag");              
//                 DateTime publicationDate = new DateTime(2008, 3, 1, 7, 0, 0);
//                 DateTime deliverydate = new DateTime();
//                 Console.WriteLine("Desea que la oferta se quede publicada?");
//                 Console.WriteLine("1-Si/2-No");
//                 string answer=Console.ReadLine();
//                 bool availability;
//                 if (answer == "1")
//                 { 
//                     availability=true;                  
//                     Offer myoffer = new Offer(OfferName,materialname,materialdescription,cost,availability,tags,deliverydate,publicationDate,Compania2);
//                     catalogo.SaveOffer(myoffer);
                    
//                 }
//                 else
//                 {
//                     availability = false;
//                     Offer myoffer = new Offer(OfferName,materialname,materialdescription,cost,availability,tags,deliverydate,publicationDate,Compania2);  
//                     catalogo.SaveOffer(myoffer);  
                    
//                 }   
//                 Console.WriteLine("Desea Salir?");
//                 Console.WriteLine("1-Si/2-No");
//                 string answer3=Console.ReadLine();
//                 if (answer3 == "1")
//                 {
//                     salida = false;
//                 }  
          
//               //      IPrinter printer1 = new ConsolePrinter();
//                     printer1.PrintOffertsAvailability(catalogo);
//                     //IPrinter printer2 = new ConsolePrinter();
//                     printer1.PrintMyOffertsAvailability(catalogo, Compania2); 

//             }
                
          

//           /*
//                     catalogo.PrintOffertsAvailability(Compania1);
//                     Console.WriteLine("Ingrese el numero de la Oferta que quiere publicar");
//                     int answerr=Int32.Parse(Console.ReadLine());
//                     catalogo.PublishOffer(answerr);
//                     catalogo.PrintmyOfferts(Compania1);          
               

//                 catalogo.PrintOffertsAvilitiy(Compania1);
//                 Console.WriteLine("Ingrese el numero de la Oferta que quiere publicar");
//                 int answerr=Int32.Parse(Console.ReadLine());
//                 //catalogo.PublishOffer(answerr);
//                 //catalogo.PrintmyOfferts(Compania1);

//                 Search busqueda1 = new Search();
//                 List<Offer> categoryList = busqueda1.GetOfferByCategory(catalogo.catalog, "Construccíon");
//                 foreach (Offer off in categoryList)
//                 {
//                     Console.WriteLine(off.Name);
//                 }

    
//                 Search busqueda2 = new Search();
//                 List<Offer> locationList = busqueda2.GetOfferByLocation(catalogo.catalog, "Berro 1231");
//                 foreach (Offer off in locationList)
//                 {
//                     Console.WriteLine(off.Name);
//                 }
                
//                 Search busqueda3 = new Search();
//                 List<Offer> wordList = busqueda3.GetOfferByWord(catalogo.catalog, "tag");
//                 foreach (Offer off in wordList)
//                 {
//                     Console.WriteLine(off.Name);
//                 }

//                 //seba
                
//                 OfferManager catalogo = new OfferManager();
//                 Company Compania1 = new Company("compania1","Las Piedras",0910101011,"Construccíon");

//                 ArrayList Tags = new ArrayList ();
//                 Tags.Add("promociones");
//                 Tags.Add("Descuentos");
//                 DateTime publicationDate = new DateTime(2008, 3, 1, 7, 0, 0);
//                 DateTime deliverydate = new DateTime();


//                 Offer myoffer = new Offer("Papas","demo","Berro 1231","demo", 12.12 , true , Tags , deliverydate ,publicationDate,Compania1);
//                 catalogo.SaveOffer(myoffer); 
//                 Entrepreneur Entrepeneur1 = new Entrepreneur("Belen", 09917293);

//                 foreach(Offer offer in catalogo.catalog)
//                 {
//                     Console.WriteLine(catalogo.catalog.IndexOf(offer) + " " + offer.Name);
//                 }
//                 Console.WriteLine("Seleccione una oferta");
//                 string index = Console.ReadLine();
//                 catalogo.buyoffer(Entrepeneur1,Int32.Parse(index));


//             }*/


            
            
//             // string rubro=Console.ReadLine();

//             // if (AreaOfWork.CheckAreaOfWork(Convert.ToInt16(rubro)))
//             // {
//             // }
//             // else
//             // {
//             //     Console.WriteLine("No exite el rubro Ingresado");
//             // }

//             // Console.WriteLine($"{Compania1.AreaOfWork}");

//             // IPermissions permiso1 = new PermissionHazardous("permiso1");
//             // IPermissions permiso2 = new PermissionBase("permiso2");
//             // IPermissions permiso3 = new PermissionBase("permiso3");

//         //     Compania1.AddPermission(permiso1);
//         //     Compania1.AddPermission(permiso2);
            
//         //    // Compania1.GetPermissions();
//         //     Console.WriteLine(Compania1.SearchP(permiso1));
//         //     Console.WriteLine(Compania1.SearchP(permiso3));
            

//         }
//     }
// }
