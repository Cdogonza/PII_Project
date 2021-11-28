using System.Collections.ObjectModel;
using System;
using Telegram.Bot.Types;
using System.Collections.ObjectModel;
using System.Data;
using System.Text;
using System.Collections;

namespace ClassLibrary
{
    public class SearchOffersHandler : BaseHandler
    {
        public SearchOffersHandler(BaseHandler next) : base(next)
        {
            this.Keywords = new string[] {"/buscar_oferta","/todas_las_ofertas","/oferta_por_palabra","/oferta_por_departamento","oferta_por_distancia","/oferta_por_categoria","/oferta_por_emprendedor","/oferta_por_company","/mis_ofertas"};
        }
            protected override bool InternalHandle(IMessage message, out string response)
            {
                if(!Singleton<TelegramUserData>.Instance.userdata.ContainsKey(message.UserId))
                {
                    Singleton<TelegramUserData>.Instance.userdata.Add(message.UserId,new Collection<string>());
                    
                }
                if(message.Text.ToLower().Equals("/buscar_oferta"))
                {
                    
                    //Agrego /buscar_oferta
                    if(Singleton<DataManager>.Instance.GetCompany(message.UserId) != null)
                    {
                        Singleton<TelegramUserData>.Instance.userdata[message.UserId].Add(message.Text); 
                        response = "Como Company tienes las siguientes opciones\n /oferta_por_emprendedor\n/mis_ofertas";
                        return true;
                    }
                    if(Singleton<DataManager>.Instance.GetEntrepreneur(message.UserId) != null)
                    {
                        Singleton<TelegramUserData>.Instance.userdata[message.UserId].Add(message.Text);   
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
                                    //codigo para buscar ofertas por emprendedor
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
                                //codigo para buscar ofertas por categoria
                                response = "";
                                return true;
                            }
                            else  if(Singleton<TelegramUserData>.Instance.userdata[message.UserId][1].ToLower().Contains("/oferta_por_emprendedor"))
                            {   
                                //codigo para buscar ofertas por emprendedor
                                response = "";
                                return true;
                                }
                                else if(Singleton<TelegramUserData>.Instance.userdata[message.UserId][1].ToLower().Contains("/oferta_por_company"))
                                {   
                                    //codigo para buscar ofertas por company
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
