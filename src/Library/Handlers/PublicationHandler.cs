using System;
using Telegram.Bot.Types;
using System.Collections.ObjectModel;
using System.Data;
using System.Text;
using System.Collections;
using System.Collections.Generic;


namespace ClassLibrary
{
    public class PublicationHandler : BaseHandler
    {
        public bool regularoffer;   
        private Dictionary<string,Collection<string>> materialtypeDict = new Dictionary<string,Collection<string>>();

        public ArrayList tags = new ArrayList();
        public PublicationHandler(BaseHandler next) : base(next)
        {
            this.Keywords = new string[] {"/publicar_oferta"};
        }
        protected override bool InternalHandle(IMessage message, out string response)
        {
            var _myinstance = Singleton<TelegramUserData>.Instance.userdata;

            if(!_myinstance.ContainsKey(message.UserId))
            {
                _myinstance.Add(message.UserId,new Collection<string>());
                
            }

            if(message.Text.ToLower().Equals("/publicar_oferta"))
            {
                if(Singleton<DataManager>.Instance.GetCompany(message.UserId) != null)
                {
                //1
                    _myinstance[message.UserId].Add(message.Text.ToLower());
                    response = "Ingrese el nombre de la oferta";                  
                    return true;
                }
           
            }
            if(_myinstance[message.UserId].Count >= 1 && _myinstance[message.UserId][0].ToLower().Contains("/publicar_oferta") )
            {
                if(_myinstance[message.UserId][0].ToLower().Contains("/publicar_oferta"))
                {
                    switch(_myinstance[message.UserId].Count)
                    {
                        case 1:  //2
                        _myinstance[message.UserId].Add(message.Text);
                        response = "Ingrese el material que desea publicar";
                        return true;

                        case 2:  //3
                        _myinstance[message.UserId].Add(message.Text);
                       
                        StringBuilder responsetemp = new StringBuilder();
                        responsetemp.Append("Ingrese el tipo de material \n");
                        responsetemp.Append($"{Singleton<DataManager>.Instance.GetTextToPrintMaterialType()}\n");
                        responsetemp.Append($"\nSi no encuentra el tipo de material en la lista ingrese /otro_materialtype");
                        response = $"{responsetemp}";
                        return true;

                        case 3:  //4
                        if(message.Text.ToLower().Equals("/otro_materialtype") )
                        {
                            this.materialtypeDict.Add(message.UserId,new Collection<string>());
                            _myinstance[message.UserId].Add(message.Text);;
                            response = "Ingrese el nombre del Tipo de Material";
                            return true;    
                        }
                        else if(Singleton<DataManager>.Instance.CheckMaterialType(Int32.Parse(message.Text)))
                        {
                            _myinstance[message.UserId].Add(message.Text);
                            response = "Se agrego el tipo de material, /continuar";         
                            return true;
                        }
                        else
                        {
                            response = "Opcion incorrecta, debe elegir nuevamente:";
                            return true;
                        }

                        case 4:  //5
                        if(_myinstance[message.UserId][3].ToLower().Equals("/otro_materialtype") && this.materialtypeDict[message.UserId].Count == 0)
                        {
                            this.materialtypeDict[message.UserId].Add(message.Text);
                            response = "Ingrese una breve descripción del material";
                            return true;
                        }
                        else if(_myinstance[message.UserId][3].ToLower().Equals("/otro_materialtype") && this.materialtypeDict[message.UserId].Count == 1)
                        {
                            _myinstance[message.UserId].Add("/continuar");
                            this.materialtypeDict[message.UserId].Add(message.Text);
                            response = "Ingrese la unidad del Material (Ej: Pallet)";
                            return true;
                        }
                        else
                        {
                            _myinstance[message.UserId].Add(message.Text);
                            response = "Ingrese la unidad del Material (Ej: Pallet)";
                            return true;
                        }

                        case 5:  //6
                        _myinstance[message.UserId].Add(message.Text);
                        response = "Ingrese calle y número de puerta";
                        return true;

                        case 6:  //7
                        _myinstance[message.UserId].Add(message.Text);
                        response = "Ingrese la ciudad";
                        return true;

                        case 7:  //8
                        _myinstance[message.UserId].Add(message.Text);
                        response = "Ingrese el departamento";
                        return true;

                        case 8:  //9
                        _myinstance[message.UserId].Add(message.Text);
                        response = "Ingrese la cantidad a ofrecer(Ej: 1) :";
                        return true;
            
                        case 9:  //9
                        _myinstance[message.UserId].Add(message.Text);
                        response = "Ingrese el costo de su oferta";
                        return true;

                        case 10:  //10
                        _myinstance[message.UserId].Add(message.Text);
                        response = "Su compra es una oferta regular? Si/No";   
                        return true;

                        case 11:  //11
                        if(message.Text.ToUpper() == "NO")
                        {
                            regularoffer = false;
                        }
                        else if(message.Text.ToUpper() == "SI")
                        {
                            regularoffer = true;
                        }

                        _myinstance[message.UserId].Add(message.Text);
                        response = "Desea agregar tags a su oferta? Si/No";

                        return true;

                        case 12:  //12

                        if(message.Text.ToUpper() == "NO")
                        {
                            _myinstance[message.UserId].Add(message.Text);
                            response = "no se agregan tags a la oferta \n \n presione /OK para finalizar";
                            return true;
                        }
                        else if(message.Text.ToUpper() == "SI")
                        {
                            _myinstance[message.UserId].Add(message.Text);
                            response = "Para Finalizar, agregue sus tags separados por '-' ";
                            return true;
                        }
                        else
                        {
                            response = "Dato mal ingresado, debe ingresar Si o No";
                            return true;
                        }

                        case 13: //13
                        Console.WriteLine("Entre aca caso 12");
                        if (_myinstance[message.UserId][12].ToUpper().Equals("SI"))
                        {
                            _myinstance[message.UserId].Add(message.Text);
                            tags.AddRange(message.Text.Split('-'));
                        }
                        else if (_myinstance[message.UserId][12].ToUpper().Equals("NO"))
                        {
                            _myinstance[message.UserId].Add(message.Text);
                            Console.WriteLine("Entre aca aca if caso 12");
                        }

                        DateTime publicationdate = DateTime.Now;
                        DateTime deliverydate = new DateTime();

                        if(_myinstance[message.UserId][3].ToLower().Equals("/otro_materialtype"))
                        {
                            Singleton<OfferManager>.Instance.AddOffer(_myinstance[message.UserId][1],Singleton<DataManager>.Instance.AddMaterial(_myinstance[message.UserId][2],Singleton<DataManager>.Instance.AddMaterialType(this.materialtypeDict[message.UserId][0],this.materialtypeDict[message.UserId][1]),_myinstance[message.UserId][5]),_myinstance[message.UserId][6],_myinstance[message.UserId][7],_myinstance[message.UserId][8],Int32.Parse(_myinstance[message.UserId][9]),Convert.ToDouble(_myinstance[message.UserId][10]),regularoffer,tags,deliverydate,publicationdate,Singleton<DataManager>.Instance.GetCompanyInstance(message.UserId));
                        }
                        else
                        //Ingresando por la lista desplegada
                        {    
                           Singleton<OfferManager>.Instance.AddOffer(_myinstance[message.UserId][1],Singleton<DataManager>.Instance.AddMaterial(_myinstance[message.UserId][2],Singleton<DataManager>.Instance.GetMaterialTypeByIndex(Int32.Parse(_myinstance[message.UserId][3])),_myinstance[message.UserId][5]),_myinstance[message.UserId][6],_myinstance[message.UserId][7],_myinstance[message.UserId][8],Int32.Parse(_myinstance[message.UserId][9]),Convert.ToDouble(_myinstance[message.UserId][10]),regularoffer,tags,deliverydate,publicationdate,Singleton<DataManager>.Instance.GetCompanyInstance(message.UserId));
                        }

                        _myinstance.Remove(message.UserId);
                        response = "Se publicó la oferta correctamente!";
                        return true;

                    }
                }
            }
            response = String.Empty ;
            return false;
        }
    }
}

