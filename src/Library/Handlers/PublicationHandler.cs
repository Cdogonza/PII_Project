using System;
using Telegram.Bot.Types;
using System.Collections.ObjectModel;
using System.Data;
using System.Text;
using System.Collections;

namespace ClassLibrary
{
    public class OfferHandler : BaseHandler
    {
        public bool regularoffer;
        

        public ArrayList tags = new ArrayList();
        public OfferHandler(BaseHandler next) : base(next)
        {
            this.Keywords = new string[] {"/publicar_oferta"};
        }
        protected override bool InternalHandle(IMessage message, out string response)
        {
            if(!Singleton<TelegramUserData>.Instance.userdata.ContainsKey(message.UserId))
            {
                Singleton<TelegramUserData>.Instance.userdata.Add(message.UserId,new Collection<string>());
            }
            if(message.Text.ToLower().Equals("/publicar_oferta"))
            {
                if(Singleton<DataManager>.Instance.GetCompany(message.UserId) != null)
                {
                //1
                    Singleton<TelegramUserData>.Instance.userdata[message.UserId].Add(message.Text);
                    response = "Ingrese el nombre de la oferta";
                    return true;
                }
            }
            
            if(Singleton<TelegramUserData>.Instance.userdata[message.UserId].Count >= 1)
            {
                if(Singleton<TelegramUserData>.Instance.userdata[message.UserId][0].ToLower().Contains("/publicar_oferta"))
                {

                    switch(Singleton<TelegramUserData>.Instance.userdata[message.UserId].Count)
                    {
                        case 1:  //2
                        Singleton<TelegramUserData>.Instance.userdata[message.UserId].Add(message.Text);
                        response = "Ingrese el material que desea publicar.";
                        return true;

                        case 2:  //3
                        Singleton<TelegramUserData>.Instance.userdata[message.UserId].Add(message.Text);
                        response = "Ingrese el tipo de material";
                        return true;


                        case 3:  //4
                        Singleton<TelegramUserData>.Instance.userdata[message.UserId].Add(message.Text);
                        response = "Ingrese una breve descripcion del material.";

                        return true;

                        case 4:  //5
                        Singleton<TelegramUserData>.Instance.userdata[message.UserId].Add(message.Text);
                        response = "Ingrese la cantidad que desea publicar";

                        return true;

                        case 5:  //6
                        Singleton<TelegramUserData>.Instance.userdata[message.UserId].Add(message.Text);
                        response = "Ingrese calle y numero de puerta";

                        return true;

                        case 6:  //7
                        Singleton<TelegramUserData>.Instance.userdata[message.UserId].Add(message.Text);
                        response = "Ingrese la Ciudad";

                        return true;

                        case 7:  //8
                        Singleton<TelegramUserData>.Instance.userdata[message.UserId].Add(message.Text);
                        response = "Ingrese el departamento";

                        return true;

                        case 8:  //9
                        Singleton<TelegramUserData>.Instance.userdata[message.UserId].Add(message.Text);
                        response = "Ingrese el costo de su oferta";

                        return true;

                        case 9:  //10
                        Singleton<TelegramUserData>.Instance.userdata[message.UserId].Add(message.Text);
                        response = "Su compra es una oferta regular? Y/N";

                        if(message.Text.ToUpper() == "N")
                        {
                            regularoffer = false;
                        }
                        else if(message.Text.ToUpper() == "Y")
                        {
                            regularoffer = true;
                        }
                        // TODO Probar si funciona el esle
                        return true;

                        case 10:  //11
                        Singleton<TelegramUserData>.Instance.userdata[message.UserId].Add(message.Text);
                        response = "Desea agregar tags a su oferta) Y/N";

                        return true;

                        case 11:  //12

                        if(message.Text.ToUpper() == "N")
                        {
                            Singleton<TelegramUserData>.Instance.userdata[message.UserId].Add(message.Text);
                            response = "no se agregan tags a la oferta";
                        }
                        else if(message.Text.ToUpper() == "Y")
                        {
                            Singleton<TelegramUserData>.Instance.userdata[message.UserId].Add(message.Text);
                            response = "Agrege sus tags separados por '-' ";
                        }
                        else
                        {
                            response = "Dato mal ingresado, debe ingresar Y/N";
                        }

                        return true;

                        case 12: //13
                        if (Singleton<TelegramUserData>.Instance.userdata[message.UserId][11].ToUpper().Equals("Y"))
                        {
                            Singleton<TelegramUserData>.Instance.userdata[message.UserId].Add(message.Text);
                            // ArrayList tags = message.Text.Split(',');
                            tags.AddRange(message.Text.Split('-'));
                        }

                        Singleton<TelegramUserData>.Instance.userdata[message.UserId].Add(message.Text);
                        DateTime publicationdate = DateTime.Now;
                        DateTime deliverydate = new DateTime();

                        Console.WriteLine($"0 - {Singleton<TelegramUserData>.Instance.userdata[message.UserId][0]}");
                        Console.WriteLine($"1 - {Singleton<TelegramUserData>.Instance.userdata[message.UserId][1]}");
                        Console.WriteLine($"2 - {Singleton<TelegramUserData>.Instance.userdata[message.UserId][2]}");
                        Console.WriteLine($"3 - {Singleton<TelegramUserData>.Instance.userdata[message.UserId][3]}");
                        Console.WriteLine($"4 - {Singleton<TelegramUserData>.Instance.userdata[message.UserId][4]}");
                        Console.WriteLine($"5 - {Singleton<TelegramUserData>.Instance.userdata[message.UserId][5]}");
                        Console.WriteLine($"6 - {Singleton<TelegramUserData>.Instance.userdata[message.UserId][6]}");
                        Console.WriteLine($"7 - {Singleton<TelegramUserData>.Instance.userdata[message.UserId][7]}");
                        Console.WriteLine($"8 - {Singleton<TelegramUserData>.Instance.userdata[message.UserId][8]}");
                        Console.WriteLine($"9 - {Singleton<TelegramUserData>.Instance.userdata[message.UserId][9]}");
                        Console.WriteLine($"10 - {Singleton<TelegramUserData>.Instance.userdata[message.UserId][10]}");
                        Console.WriteLine($"11 - {Singleton<TelegramUserData>.Instance.userdata[message.UserId][11]}");
                        Console.WriteLine($"12 - {Singleton<TelegramUserData>.Instance.userdata[message.UserId][12]}");
                        Console.WriteLine($"13 - {Singleton<TelegramUserData>.Instance.userdata[message.UserId][13]}");

                        Singleton<DataManager>.Instance.AddMaterial(Singleton<TelegramUserData>.Instance.userdata[message.UserId][2],new MaterialType(Singleton<TelegramUserData>.Instance.userdata[message.UserId][3],Singleton<TelegramUserData>.Instance.userdata[message.UserId][4]),Singleton<TelegramUserData>.Instance.userdata[message.UserId][5]);
                        Singleton<OfferManager>.Instance.AddOffer(Singleton<TelegramUserData>.Instance.userdata[message.UserId][1],Singleton<DataManager>.Instance.AddMaterial(Singleton<TelegramUserData>.Instance.userdata[message.UserId][2],new MaterialType(Singleton<TelegramUserData>.Instance.userdata[message.UserId][3],Singleton<TelegramUserData>.Instance.userdata[message.UserId][4]),Singleton<TelegramUserData>.Instance.userdata[message.UserId][5]),Singleton<TelegramUserData>.Instance.userdata[message.UserId][6],Singleton<TelegramUserData>.Instance.userdata[message.UserId][7],Singleton<TelegramUserData>.Instance.userdata[message.UserId][8],Convert.ToDouble(Singleton<TelegramUserData>.Instance.userdata[message.UserId][9]),regularoffer,tags,deliverydate,publicationdate,Singleton<DataManager>.Instance.GetCompanyInstance(message.UserId));
                        Singleton<TelegramUserData>.Instance.userdata.Remove(message.UserId);

                        response = $"Se Creo La Oferta Correctamente";
                        return true;
                    }
                }
            }
            response = String.Empty ;
            return false;
        }
    }
}
