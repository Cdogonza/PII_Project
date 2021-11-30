using System;
using Telegram.Bot.Types;
using System.Collections.ObjectModel;
using System.Data;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Runtime.CompilerServices;
using Telegram.Bot.Requests;
using System.Linq;

namespace ClassLibrary
{
    public class PublicationHandler : BaseHandler
    {
        public bool regularoffer;   
 
        private StringBuilder responsetemp = new StringBuilder();
        private List<Permission> offerpermissions = new List<Permission>();
        private List<string> tags = new List<string> ();
        public PublicationHandler(BaseHandler next) : base(next)
        {
            this.Keywords = new string[] {"/publicar_oferta"};
        }
        protected override bool InternalHandle(IMessage message, out string response)
        {
            var _myuserdata = Singleton<TelegramUserData>.Instance.userdata;
            var _mymaterialtype = Singleton<TelegramUserData>.Instance.materialtypeDict;
            var _mypermissions = Singleton<TelegramUserData>.Instance.permissionsDict;
            var _mytags = Singleton<TelegramUserData>.Instance.tagsDict;
            if(!_myuserdata.ContainsKey(message.UserId))
            {
                _myuserdata.Add(message.UserId,new Collection<string>());                
            }

            if(message.Text.ToLower().Equals("/publicar_oferta"))
            {
                if(Singleton<DataManager>.Instance.GetCompany(message.UserId) != null)
                {
                //1
                    _mypermissions.Add(message.UserId,new Collection<string>());
                    _mymaterialtype.Add(message.UserId,new Collection<string>());
                    _mytags.Add(message.UserId,new Collection<string>());
                    _myuserdata[message.UserId].Add(message.Text.ToLower());
                    response = "Ingrese el nombre de la oferta";                  
                    return true;
                }
            }
            if(_myuserdata[message.UserId].Count >= 1 && _myuserdata[message.UserId][0].ToLower().Contains("/publicar_oferta") )
            {
                if(_myuserdata[message.UserId][0].ToLower().Contains("/publicar_oferta"))
                {
                    switch(_myuserdata[message.UserId].Count)
                    {
                        case 1:
                        _myuserdata[message.UserId].Add(message.Text);
                        response = "Ingrese el material que desea publicar";
                        return true;

                        case 2:
                        _myuserdata[message.UserId].Add(message.Text);
                        responsetemp.Append("Ingrese el tipo de material \n");
                        responsetemp.Append($"{Singleton<DataManager>.Instance.GetTextToPrintMaterialType()}\n");
                        responsetemp.Append($"\nSi no encuentra el tipo de material en la lista ingrese /otro_tipo_de_material");
                        response = $"{responsetemp}";
                        return true;

                        case 3:
                        if(message.Text.ToLower().Equals("/otro_tipo_de_material") )
                        {
                            _myuserdata[message.UserId].Add(message.Text);;
                            response = "Ingrese el nombre del tipo de material";
                            return true;    
                        }
                        else if(Singleton<DataManager>.Instance.CheckMaterialType(Int32.Parse(message.Text)))
                        {
                            _myuserdata[message.UserId].Add(message.Text);
                            response = "Se agregó el tipo de material /continuar";         
                            return true;
                        }
                        else
                        {
                            response = "Opción incorrecta, debe elegir nuevamente";
                            return true;
                        }

                        case 4:
                        if(_myuserdata[message.UserId][3].ToLower().Equals("/otro_tipo_de_material") && _mymaterialtype[message.UserId].Count == 0)
                        {
                            _mymaterialtype[message.UserId].Add(message.Text);
                            response = "Ingrese una breve descripción del tipo de material";
                            return true;
                        }
                        else if(_myuserdata[message.UserId][3].ToLower().Equals("/otro_tipo_de_material") && _mymaterialtype[message.UserId].Count == 1)
                        {
                            _myuserdata[message.UserId].Add("/continuar");
                            _mymaterialtype[message.UserId].Add(message.Text);
                            response = "Ingrese la unidad del material (Ej: Pallet)";
                            return true;
                        }
                        else
                        {
                            _myuserdata[message.UserId].Add(message.Text);
                            response = "Ingrese la unidad del material (Ej: Pallet)";
                            return true;
                        }

                        case 5:
                        _myuserdata[message.UserId].Add(message.Text);
                        response = "Ingrese la cantidad a ofrecer(Ej: 1) :";
                        return true;
            
                        case 6:
                        _myuserdata[message.UserId].Add(message.Text);
                        response = "Ingrese el costo de su oferta en $(Ej $100):";
                        return true;

                        case 7:  //6
                        _myuserdata[message.UserId].Add(message.Text.Replace("$",""));
                        response = "Ingrese calle y número de puerta";
                        return true;

                        case 8:
                        _myuserdata[message.UserId].Add(message.Text);
                        response = "Ingrese la ciudad";
                        return true;

                        case 9:
                        _myuserdata[message.UserId].Add(message.Text);
                        response = "Ingrese el departamento";
                        return true;

                        case 10:
                        _myuserdata[message.UserId].Add(message.Text);
                        response = $"La oferta requiere algún permiso especial? Si/No";
                        
                        return true;
                        
                        case 11:
                        
                        if(message.Text.ToUpper().Equals("SI"))
                        {
                            _myuserdata[message.UserId].Add($"permiso = {message.Text}");
                            responsetemp.Clear();                    
                            responsetemp.Append("Ingrese el permiso necesario para la oferta \n");
                            responsetemp.Append($"{Singleton<DataManager>.Instance.GetTextToPrintPermission()}\n");
                            response = $"{responsetemp}";
                            return true;
                        }
                        else if(message.Text.ToUpper().Equals("NO"))
                        {
                            _myuserdata[message.UserId].Add($"permiso = {message.Text}");
                            if(_mypermissions[message.UserId].Count > 0)
                            {
                                responsetemp.Clear();
                                responsetemp.Append("Se agregan los siguientes permisos \n");
                                for (int i = 0; i < _mypermissions[message.UserId].Count; i++)
                                {
                                    this.offerpermissions.Add(Singleton<DataManager>.Instance.GetPermissionByIndex(Int32.Parse(_mypermissions[message.UserId][i])));
                                    responsetemp.Append($"- {Singleton<DataManager>.Instance.GetPermissionByIndex(Int32.Parse(_mypermissions[message.UserId][i])).Name}\n");
                                }
                                responsetemp.Append($"Presione /continuar");
                                response = $"{responsetemp}";
                                responsetemp.Clear();   
                            }    
                            else
                            {
                                response = "No se agregan permisos especiales, /continuar";
                                
                            }                 
                            return true; 
                        }
                        else
                        {
                            response = "Dato mal ingresado debe ingresar Si/No";
                            return true; 
                        }

                        case 12:
                        if(_myuserdata[message.UserId][11].ToUpper().Contains("SI"))
                        {
                            if (!_mypermissions[message.UserId].Contains(message.Text))
                            {  
                                _mypermissions[message.UserId].Add(message.Text);
                                _myuserdata[message.UserId].RemoveAt(11);
                                response = "Desea Agregar otro Permiso? Si/No";
                                return true;
                            }
                            else
                            {
                                _myuserdata[message.UserId].RemoveAt(9);
                                response = "Esta Oferta ya tiene este Permiso asociado \nDesea Agregar otro Permiso? Si/No";
                                return true;
                            }
                        }
                        else
                        {
                            _mypermissions[message.UserId].Add(message.Text);
                            _myuserdata[message.UserId].Add(message.Text);
                            response = "Su compra es una oferta regular? Si/No";
                            return true;     
                        }
   
                        case 13:
                        if(message.Text.ToUpper() == "NO")
                        {
                            regularoffer = false;
                        }
                        else if(message.Text.ToUpper() == "SI")
                        {
                            regularoffer = true;
                        }
                        _myuserdata[message.UserId].Add(message.Text);
                        response = "Desea agregar palabras clave a su oferta? Si/No";
                        return true;

                        case 14:

                        if(message.Text.ToUpper() == "NO")
                        {
                            _myuserdata[message.UserId].Add(message.Text);
                            response = "no se agregan palabras clave a la oferta \n \n presione /OK para finalizar";
                            return true;
                        }
                        else if(message.Text.ToUpper() == "SI")
                        {
                            _myuserdata[message.UserId].Add(message.Text);
                            response = "Para Finalizar, agregue sus palabras clave separados por '-' ";
                            return true;
                        }
                        else
                        {
                            response = "Dato mal ingresado, debe ingresar Si o No";
                            return true;
                        }

                        case 15:
                        if (_myuserdata[message.UserId][14].ToUpper().Equals("SI"))
                        {
                            _myuserdata[message.UserId].Add(message.Text);
                            this.tags.AddRange(message.Text.Split('-').ToList());
                            foreach (var tag in this.tags)
                            {
                                _mytags[message.UserId].Add($"{tag}");
                            }

                            //tags.AddRange(message.Text.Split('-'));
                        }
                        else if (_myuserdata[message.UserId][14].ToUpper().Equals("NO"))
                        {
                            _myuserdata[message.UserId].Add(message.Text);
                        }
                        
                        string name = _myuserdata[message.UserId][1];
                        string namematerial = _myuserdata[message.UserId][2];
                        string unit = _myuserdata[message.UserId][5];
                        string street = _myuserdata[message.UserId][8];
                        string city = _myuserdata[message.UserId][9];
                        string department = _myuserdata[message.UserId][10];
                        int quantity = Convert.ToInt16(_myuserdata[message.UserId][6]);
                        double cost = Convert.ToDouble(_myuserdata[message.UserId][7]);
                        Company company = Singleton<DataManager>.Instance.GetCompanyInstance(message.UserId);
                        DateTime publicationdate = DateTime.Now;
                        DateTime deliverydate = new DateTime();
                                            
                        this.tags = _mytags[message.UserId].ToList();

                        if(_myuserdata[message.UserId][3].ToLower().Equals("/otro_tipo_de_material"))
                        {
                            string typename = _mymaterialtype[message.UserId][0];
                            string typedesc = _mymaterialtype[message.UserId][1];
                            Singleton<OfferManager>.Instance.AddOffer(name,Singleton<DataManager>.Instance.AddMaterial(namematerial,Singleton<DataManager>.Instance.AddMaterialType(typename,typedesc),unit), quantity, cost,street, city, department, this.offerpermissions, regularoffer, this.tags, deliverydate, publicationdate, company);
                        }
                        else
                        //Ingresando por la lista desplegada
                        {   
                           Singleton<OfferManager>.Instance.AddOffer(name,Singleton<DataManager>.Instance.AddMaterial(namematerial,Singleton<DataManager>.Instance.GetMaterialTypeByIndex(Int32.Parse(_myuserdata[message.UserId][3])),unit), quantity, cost,street, city, department, this.offerpermissions, regularoffer, this.tags, deliverydate, publicationdate, company);
                             
                        }
                   
                        _myuserdata.Remove(message.UserId);
                        _mypermissions.Remove(message.UserId);
                        _mymaterialtype.Remove(message.UserId);
                        tags.Clear();
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

