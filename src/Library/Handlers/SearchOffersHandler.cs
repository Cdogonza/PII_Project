using System.Collections.ObjectModel;
using System;
using Telegram.Bot.Types;
using System.Data;
using System.Text;
using System.Collections;
using System.Collections.Generic;

namespace ClassLibrary
{
    public class SearchOffersHandler : BaseHandler
    {
        
        List<Offer> matVacia = new List<Offer>();
        public SearchOffersHandler(BaseHandler next) : base(next)
        {
            this.Keywords = new string[] {"/todas_las_ofertas","/oferta_por_palabra","/oferta_por_departamento","oferta_por_distancia","/oferta_por_categoria","/oferta_por_emprendedor","/oferta_por_company","/mis_ofertas"};
        }
            protected override bool InternalHandle(IMessage message, out string response)
            {
                if(!Singleton<TelegramUserData>.Instance.userdata.ContainsKey(message.UserId))
                {
                    Singleton<TelegramUserData>.Instance.userdata.Add(message.UserId,new Collection<string>());
                    
                }
                if(message.Text.ToLower().Equals("/buscar_oferta"))
                {
                    
                    
                    if(Singleton<DataManager>.Instance.GetCompany(message.UserId) != null)
                    {
                        Singleton<TelegramUserData>.Instance.userdata[message.UserId].Add(message.Text); //Agrego /buscar_oferta
                        response = "Como Company tienes las siguientes opciones\n /oferta_por_emprendedor\n/mis_ofertas";
                        return true;
                    }
                    if(Singleton<DataManager>.Instance.GetEntrepreneur(message.UserId) != null)
                    {
                        Singleton<TelegramUserData>.Instance.userdata[message.UserId].Add(message.Text);   //Agrego /buscar_oferta
                        response = "Como Entrepreneur tienes las siguientes opciones\n /todas_las_ofertas\n /oferta_por_palabra\n/oferta_por_departamento\n/oferta_por_distancia\n/oferta_por_categoria\n/oferta_por_emprendedor\n/oferta_por_company";                     
                         
                        return true; 
                    }
                }
                        if(Singleton<TelegramUserData>.Instance.userdata[message.UserId].Count >= 1)
                        {
                            if(Singleton<TelegramUserData>.Instance.userdata[message.UserId][0].ToLower().Contains("/buscar_oferta"))
                            {
                                Singleton<TelegramUserData>.Instance.userdata[message.UserId].Add(message.Text);//Agrego el comando ingresado por el usuario

                            if(Singleton<TelegramUserData>.Instance.userdata[message.UserId][1].ToLower().Contains("/oferta_por_emprendedor"))
                                {
                                    //codigo para buscar ofertas por emprendedorBELENNNN
                                    response = "";
                                    return true;
                                }                               
                            if(Singleton<TelegramUserData>.Instance.userdata[message.UserId][1].ToLower().Contains("/mis_ofertas"))
                                {
                                        //buscar ofertas propias
                                        response = "";
                                        return true;
                                } 
                             if(Singleton<TelegramUserData>.Instance.userdata[message.UserId][1].ToLower().Trim().Contains("/oferta_por_palabra"))
                            {
                                
                                //codigo para buscar ofertas por palabra
                                response = "";
                                return true;
                            }else if(Singleton<TelegramUserData>.Instance.userdata[message.UserId][1].ToLower().Trim().Contains("/oferta_por_departamento"))
                            {
                               if(Singleton<TelegramUserData>.Instance.userdata[message.UserId].Count == 2)
                               {
                                response = "Ingrese el departamento";
                                return true;
                               }                                 
                                Singleton<TelegramUserData>.Instance.userdata[message.UserId].Add(message.Text);                                                             
                                response=Singleton<Search>.Instance.GetOfferByDepartment(message.Text);
                                Singleton<TelegramUserData>.Instance.userdata[message.UserId].Clear();                             
                                return true;
                                                          
                            }
                            else if(Singleton<TelegramUserData>.Instance.userdata[message.UserId][1].ToLower().Trim().Contains("/oferta_por_distancia"))
                            {
                            //codigo para buscar ofertas por distancia
                            response = "";
                            return true;
                            }
                             else  if(Singleton<TelegramUserData>.Instance.userdata[message.UserId][1].ToLower().Contains("/oferta_por_categoria"))
                            {
                                                              
                                if(Singleton<TelegramUserData>.Instance.userdata[message.UserId].Count == 2)
                               {
                                string check="";
                                string datosMaterial="";
                                Singleton<OfferManager>.Instance.LoadFromJsonOffer();
                                List<Offer> mat = Singleton<OfferManager>.Instance.catalog;
                                foreach (Offer item in mat )
                                {
                                    if(!check.Equals(item.Material.Type.Name)){
                                    datosMaterial += $"{item.Idd} - {item.Material.Type.Name}\n"; 
                                    }
                                    check =item.Material.Type.Name;                                  
                                }
                                
                                mat = matVacia;
                                response= $"Seleccione el numero de una Categoria\n{datosMaterial}";
                                return true;
                               }
                                if(Singleton<TelegramUserData>.Instance.userdata[message.UserId].Count == 2)
                               {
                                Singleton<TelegramUserData>.Instance.userdata[message.UserId].Add(message.Text); //obtengo la cat qeu el user quiere      
                                response="";
                                                                                           
                                return true;
                               }
                                Singleton<TelegramUserData>.Instance.userdata[message.UserId].Add(message.Text);
                                Singleton<OfferManager>.Instance.LoadFromJsonOffer();
                                List<Offer> mat2 = Singleton<OfferManager>.Instance.catalog;
                                foreach (Offer item in mat2)
                                {                  
                                    if (item.Idd == Int32.Parse(Singleton<TelegramUserData>.Instance.userdata[message.UserId][3]))
                                    { 
                                        response=Singleton<Search>.Instance.GetOfferByID(item.Idd);
                                        Singleton<TelegramUserData>.Instance.userdata[message.UserId].Clear(); 
                                        return true;
                                    }                                   
                                }
                             mat2 = matVacia;
                            }
                            else  if(Singleton<TelegramUserData>.Instance.userdata[message.UserId][1].ToLower().Contains("/oferta_por_emprendedor"))
                            {   
                                //codigo para buscar ofertas por emprendedor
                                response = "";
                                return true;
                                }
                                else if(Singleton<TelegramUserData>.Instance.userdata[message.UserId][1].ToLower().Contains("/oferta_por_company"))
                                {   
                                    //codigo para buscar ofertas por company BELNNN
                                     response = "";
                                     return true;
                                }
                                else if(Singleton<TelegramUserData>.Instance.userdata[message.UserId][1].ToLower().Contains("/todas_las_ofertas"))
                                {   
                                    //codigo para buscar ofertas por habilitadas
                                    response = "";
                                    return true;
                                    }
                            
                        

                }    
                        }        
            response = String.Empty ;
            return false;
     }        
    }

}
