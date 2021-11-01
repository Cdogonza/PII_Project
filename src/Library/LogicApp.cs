using System;
using ClassLibrary;
using System.Collections;
using System.Collections.Generic;
namespace ConsoleApplication
{
    /// <summary>
    /// 
    /// </summary>
    public class LogicApp
    {        
        
        /// <summary>
        /// 
        /// 
        /// </summary>
        
        public static void  StartAppi()
        {
            string useranswer;
            OfferManager catalogo = new OfferManager();
            Company Compania1 = new Company("compania1","Las Piedras",0910101011,"Construccíon");
            bool salida = true;
            while (salida)
            {
                Console.WriteLine("1 -  Ingresar una oferta  2- salir");
                useranswer=Console.ReadLine();
                if (useranswer == "1")
                {
                    Console.WriteLine("Ingrese nombre de al Oferta");
                    string OfferName=Console.ReadLine();
                    Console.WriteLine("Ingrese nombre de los materiales que desea publicar en la oferta");
                    string materialname=Console.ReadLine();
                    Console.WriteLine("Ingrese la descripcion de los materiales");
                    string materialdescription=Console.ReadLine();
                    Console.WriteLine("Ingrese el costo");
                    int cost=Int32.Parse(Console.ReadLine());
                    ArrayList tags  = new ArrayList();
                    tags.Add("tag1");
                    tags.Add("tag");              
                    DateTime publicationDate = new DateTime(2008, 3, 1, 7, 0, 0);
                    DateTime deliverydate = new DateTime();
                    Console.WriteLine("Desea disponibilizar la oferta inmediatamente?");
                    Console.WriteLine("1-Si/2-No");
                    useranswer=Console.ReadLine();
                    bool availability;
                    if (useranswer == "1")
                    { 
                        availability=true;                  
                        Offer myoffer = new Offer(OfferName,materialname,"Berro 1231",materialdescription,cost,availability,tags,deliverydate,publicationDate,Compania1);
                        catalogo.SaveOffer(myoffer);                  
                    }
                    else
                    {
                        availability = false;
                        Offer myoffer = new Offer(OfferName,materialname,"Berro 1231",materialdescription,cost,availability,tags,deliverydate,publicationDate,Compania1);  
                        catalogo.SaveOffer(myoffer);  
                    } 
                    Console.WriteLine("Desea Salir?");
                    Console.WriteLine("1-Si/2-No");
                    useranswer=Console.ReadLine();
                    if (useranswer == "1")
                    {
                        salida = false;
                    }else
                    {
                        Console.WriteLine("1 -  Imprimir mis Ofertas  2-Imprimir Todas las ofertas");
                        useranswer=Console.ReadLine();
                        if(useranswer =="1")
                        {
                            IPrinter printer1 = new ConsolePrinter();
                            printer1.PrintOffertsAvailability(catalogo);
                        }else
                        {
                            IPrinter printer2 = new ConsolePrinter();
                            printer2.PrintMyOffertsAvailability(catalogo, Compania1); 
                        }
                        Console.WriteLine("Desea Salir?");
                        Console.WriteLine("1-Si/2-No");
                        useranswer=Console.ReadLine();
                        if (useranswer == "1")
                        {
                            Entrepreneur Entrepeneur1 = new Entrepreneur("Belen", 09917293);
                            Entrepeneur1.SearchByCategory("Cubiertas");
                            foreach(Offer offer in Entrepeneur1.mylist)
                            {
                                Console.WriteLine(offer.id + " " + offer.Name);
                            }
                            Console.WriteLine("Seleccione una oferta");
                            string index = Console.ReadLine();                          
                                bool wait=true;
                                while(wait)
                                {
                                    if(index.Length>0)
                                    {
                                        wait=false;
                                    }
                                }                            
                            catalogo.buyoffer(Entrepeneur1,Int32.Parse(index));
                            
                            Console.WriteLine(Entrepeneur1.mylist[Int32.Parse(index)].Entrepreneur);
                           
                        }
                    }
                }
            }


            
        }





    }







}