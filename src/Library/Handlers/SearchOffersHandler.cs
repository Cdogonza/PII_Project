using System.Collections.ObjectModel;
using System;
using Telegram.Bot.Types;
using System.Collections.ObjectModel;
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
            this.Keywords = new string[] {"/buscar_oferta","/todas_las_ofertas","/ofertas_por_palabra","/oferta_por_departamento","/oferta_por_distancia","/oferta_por_categoria","/mis_ofertas_adquiridas","/ofertas_por_empresa","/mis_ofertas","/mis_ofertas_por_emprendimiento"};
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
                    Singleton<TelegramUserData>.Instance.userdata[message.UserId].Add(message.Text); 
                    response = "Como empresa tienes las siguientes opciones\n/mis_ofertas_por_emprendimiento\n/mis_ofertas";
                    return true;
                }
                if(Singleton<DataManager>.Instance.GetEntrepreneur(message.UserId) != null)
                {
                    Singleton<TelegramUserData>.Instance.userdata[message.UserId].Add(message.Text);   
                    response = "Como emprendimiento tienes las siguientes opciones\n/todas_las_ofertas\n/ofertas_por_palabra\n/oferta_por_departamento\n/oferta_por_distancia\n/oferta_por_categoria\n/mis_ofertas_adquiridas\n/ofertas_por_empresa";                     
                        
                    return true; 
                }
            }
            if(Singleton<TelegramUserData>.Instance.userdata[message.UserId].Count >= 1)
            {
                if(Singleton<TelegramUserData>.Instance.userdata[message.UserId][0].ToLower().Contains("/buscar_oferta"))
                {
                    Singleton<TelegramUserData>.Instance.userdata[message.UserId].Add(message.Text);//Agrego el comando ingresado por el usuario
                    if(Singleton<DataManager>.Instance.GetCompany(message.UserId) != null)
                    {
                        if(Singleton<TelegramUserData>.Instance.userdata[message.UserId][1].ToLower().Contains("/mis_ofertas_por_emprendimiento"))
                        {
                            if(Singleton<TelegramUserData>.Instance.userdata[message.UserId].Count == 2)
                            {
                                response = "Ingrese el nombre del emprendimiento";
                                return true;
                            }                                 
                            Singleton<TelegramUserData>.Instance.userdata[message.UserId].Add(message.Text);
                            Singleton<TelegramUserData>.Instance.userdata[message.UserId].Clear();
                            response=Singleton<Search>.Instance.GetMyOffersByEntrepreneur(message.Text, message.UserId);                             
                            return true;

                        }
                        else if(Singleton<TelegramUserData>.Instance.userdata[message.UserId][1].ToLower().Contains("/mis_ofertas"))
                        {
                            if(Singleton<TelegramUserData>.Instance.userdata[message.UserId].Count == 2)
                            {
                                Singleton<TelegramUserData>.Instance.userdata[message.UserId].Clear();
                                response=Singleton<Search>.Instance.GetOfferByCompany(message.UserId);       
                                return true;
                                
                            }
                        }
                        else if(Singleton<TelegramUserData>.Instance.userdata[message.UserId][1].ToLower().Contains("/remover_oferta"))
                        {
                            if(Singleton<TelegramUserData>.Instance.userdata[message.UserId].Count == 2)
                            {
                                Singleton<TelegramUserData>.Instance.userdata[message.UserId].Add(message.Text);
                                Singleton<TelegramUserData>.Instance.userdata[message.UserId].Clear();
                                response=$"Ingrese la oferta a remover \n{Singleton<Search>.Instance.GetOfferByCompany(message.UserId)}";       
                                return true;                                            
                            }
                            if(Singleton<TelegramUserData>.Instance.userdata[message.UserId].Count == 3)
                            {
                                if(Singleton<OfferManager>.Instance.Remove(long.Parse(message.Text)))
                                {
                                    response = $"Se removió la oferta con exito";
                                    return true;
                                }
                                else
                                {
                                    response = $"No se encontró la oferta con Id: {message.Text}";
                                    return true;
                                }
                            }      
                        }
                    }

                    if(Singleton<DataManager>.Instance.GetEntrepreneur(message.UserId) != null)
                    {
                        if(Singleton<TelegramUserData>.Instance.userdata[message.UserId][1].ToLower().Trim().Contains("/ofertas_por_palabra"))
                        {
                            if(Singleton<TelegramUserData>.Instance.userdata[message.UserId].Count == 2)
                            {
                                response = "Ingrese la palabra";
                                return true;
                            }                                 
                            Singleton<TelegramUserData>.Instance.userdata[message.UserId].Add(message.Text);                              
                            response=Singleton<Search>.Instance.GetOfferByWord(message.Text);
                            Singleton<TelegramUserData>.Instance.userdata[message.UserId].Clear();                             
                            return true;

                        }
                        else if(Singleton<TelegramUserData>.Instance.userdata[message.UserId][1].ToLower().Trim().Contains("/oferta_por_departamento"))
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
                                                    
                        /*}else if(Singleton<TelegramUserData>.Instance.userdata[message.UserId][1].ToLower().Trim().Contains("/oferta_por_distancia"))
                        {
                            //codigo para buscar ofertas por distancia
                            response = "";
                            return true;*/
                        }
                        else if(Singleton<TelegramUserData>.Instance.userdata[message.UserId][1].ToLower().Contains("/oferta_por_categoria"))
                        {
                            if(Singleton<TelegramUserData>.Instance.userdata[message.UserId].Count == 2)
                            {
                                string datosMaterial="";
                                Singleton<OfferManager>.Instance.LoadFromJsonOffer();
                                List<Offer> mat = Singleton<OfferManager>.Instance.catalog;
                                foreach (Offer item in mat  )
                                {
                                    datosMaterial += $"{item.Material.Type.Name}\n";
                                    
                                }
                                mat = matVacia;
                                response= $"Seleccione una Categoria\n{datosMaterial}";
                                return true;
                            }
                            //Singleton<TelegramUserData>.Instance.userdata[message.UserId].Add(message.Text); obtengo la cat qeu el user quiere                              
                            response=Singleton<Search>.Instance.GetOfferByCategory(message.Text);   
                            Singleton<TelegramUserData>.Instance.userdata[message.UserId].Clear();               
                            return true;
                        }
                        else if(Singleton<TelegramUserData>.Instance.userdata[message.UserId][1].ToLower().Contains("/mis_ofertas_adquiridas"))
                        {   
                            if(Singleton<TelegramUserData>.Instance.userdata[message.UserId].Count == 2)
                            {
                                Singleton<TelegramUserData>.Instance.userdata[message.UserId].Clear();
                                response=Singleton<Search>.Instance.GetOfferByEntrepreneur(message.UserId);       
                                return true;
                            }
                        }
                        else if(Singleton<TelegramUserData>.Instance.userdata[message.UserId][1].ToLower().Contains("/ofertas_por_empresa"))
                        {
                            if(Singleton<TelegramUserData>.Instance.userdata[message.UserId].Count == 2)
                            {
                                response = "Ingrese el nombre de la empresa";
                                return true;
                            }                                 
                            Singleton<TelegramUserData>.Instance.userdata[message.UserId].Add(message.Text);
                            Singleton<TelegramUserData>.Instance.userdata[message.UserId].Clear();
                            response=Singleton<Search>.Instance.GetOffersPublicatedByCompany(message.Text);                             
                            return true;
                        }
                        else if(Singleton<TelegramUserData>.Instance.userdata[message.UserId][1].ToLower().Contains("/todas_las_ofertas"))
                        {   
                            if(Singleton<TelegramUserData>.Instance.userdata[message.UserId].Count == 2)
                            {
                                Singleton<TelegramUserData>.Instance.userdata[message.UserId].Clear();
                                response=Singleton<Search>.Instance.GetOffers();       
                                return true;
                            }
                        }
                    }
                    else
                    {
                        response = "Debe estar ingresad@ como empresa o como emprendimiento para poder buscar ofertas\n/help";
                        return true;
                    }
                }
            }
            response = String.Empty ;
            return false;        
        }          
    }
}