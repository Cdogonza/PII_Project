using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
namespace ClassLibrary
{
    /// <summary>
    /// 
    /// </summary>
    public class RegistrationHandler: BaseHandler
    {
        private StringBuilder responsetemp = new StringBuilder();
        private List<Permission> userpermissions = new List<Permission>();
        public RegistrationHandler(BaseHandler next) : base(next)
        {
            this.Keywords = new string[] {"/registrarse"};
        }
        protected override bool InternalHandle(IMessage message, out string response)
        {           
            var _myuserdata = Singleton<TelegramUserData>.Instance.userdata;
            var _mypermissions = Singleton<TelegramUserData>.Instance.permissionsDict;
            if(!_myuserdata.ContainsKey(message.UserId))
            {
               _myuserdata.Add(message.UserId,new Collection<string>());    
            }    
            
            if(message.Text.ToLower().Equals("/registrarse") )
            {   
                _mypermissions.Add(message.UserId,new Collection<string>());
                if (Singleton<DataManager>.Instance.GetEntrepreneur(message.UserId) != null | Singleton<DataManager>.Instance.GetCompany(message.UserId) != null)
                {
                    response = "Usted ya se encuentra registrad@";
                    return true;
                    }
                    else
                    {
                       _myuserdata[message.UserId].Add(message.Text.ToLower()); //Agrego /registrarse al diccionario
                        response = "Registrarse como Empresa o como Emprendedor\n/Empresa\n/Emprendedor\no cancela con /cancel ";
                        return true;
                    }
            }
            
            if(_myuserdata[message.UserId].Count >= 1 &&_myuserdata[message.UserId][0].ToLower().Contains("/registrarse") )
            {
                if(_myuserdata[message.UserId][0].ToLower().Contains("/registrarse"))
                {
                    
                    if(_myuserdata[message.UserId].Count >= 1 && message.Text.ToLower().Contains("/empresa"))
                    {
                       _myuserdata[message.UserId].Add(message.Text.ToLower()); /// agrego texto /empresa
                        response = "Ingrese el código de invitación";
                        return true;
                    }
                    if(_myuserdata[message.UserId].Count == 1 && message.Text.ToLower().Equals("/emprendedor"))
                    {
                       _myuserdata[message.UserId].Add(message.Text); /// agrego texto /emprendendor
                        response = "Ingrese nombre de su emprendimiento";
                        return true;                   
                    }
                }
                    if(_myuserdata[message.UserId][1].ToLower().Contains("/empresa"))
                    {  
                    if(message.Text.ToLower().Equals( "1234") &&_myuserdata[message.UserId].Count == 2)
                        {
                           _myuserdata[message.UserId].Add(message.Text.ToLower());
                            response = "Ingrese el nombre de la empresa";
                            return true;
                        }
                        if(!message.Text.ToLower().Equals( "1234") &&_myuserdata[message.UserId].Count == 2) { 

                            response = "Código incorrecto, intente nuevamente";
                            return true;
                        }

                        switch(_myuserdata[message.UserId].Count)
                        {
                            case 3:                
                            response = "Ingrese su teléfono";
                            _myuserdata[message.UserId].Add(message.Text);
                            return true;

                            case 4:
                            _myuserdata[message.UserId].Add(message.Text);
                            response = "Ingrese Calle y Numero de puerta";
                            return true;

                            case 5:
                            _myuserdata[message.UserId].Add(message.Text);
                            response = "Ingrese Ciudad";                                
                            return true;

                            case 6:
                            _myuserdata[message.UserId].Add(message.Text);
                            response = "Ingrese Departamento";                                
                            return true;

                            case 7:                  
                            _myuserdata[message.UserId].Add(message.Text);
                            responsetemp.Append("Ingrese el rubro de la empresa\n");
                            responsetemp.Append($"{Singleton<DataManager>.Instance.GetTextToPrintAreaOfWork()}");
                            response = $"{responsetemp}";
                            responsetemp.Clear();
                            return true;
                
                            case 8:
                            if(Singleton<DataManager>.Instance.CheckAreaOfWork(Int16.Parse(message.Text)))
                            {
                                _myuserdata[message.UserId].Add(Singleton<DataManager>.Instance.areaofwork[Int32.Parse(message.Text)].Name);
                                Singleton<DataManager>.Instance.AddCompany(message.UserId,_myuserdata[message.UserId][3],_myuserdata[message.UserId][4],_myuserdata[message.UserId][5],_myuserdata[message.UserId][6],_myuserdata[message.UserId][7],_myuserdata[message.UserId][8]);
                                response = $"Se creó la Empresa correctamente\n \nPara ver las siguientes acciones posibles ingrese: \n /publicar_oferta \n /vermisdatos \n /materialtype \n /habilitaciones";
                                _myuserdata.Remove(message.UserId);
                                return true;
                            }
                            else
                            {
                                response = "Dato Mal ingresado, ingrese un numero de la lista";
                                return true;
                            }
                        }
                    }
            
                    if(_myuserdata[message.UserId][1].ToLower().Contains("/emprendedor"))
                    {
                        switch(_myuserdata[message.UserId].Count)
                        {
                            case 2:                    
                            _myuserdata[message.UserId].Add(message.Text);
                            response = "Ingrese su teléfono";
                            return true;
                                                
                            case 3:
                            _myuserdata[message.UserId].Add(message.Text);
                            response = "Ingrese calle y número de puerta";
                            return true;
                            
                            case 4:
                            _myuserdata[message.UserId].Add(message.Text);
                            response = "Ingrese ciudad";
                            return true;
                        
                            case 5:
                            _myuserdata[message.UserId].Add(message.Text);
                            response = "Ingrese departamento";
                            return true;
                        
                            case 6:                      
                            _myuserdata[message.UserId].Add(message.Text);
                            response = $"{Singleton<DataManager>.Instance.GetTextToPrintAreaOfWork()}";
                            return true;
                                                        
                            case 7:
                            if(Singleton<DataManager>.Instance.CheckAreaOfWork(Int16.Parse(message.Text)))
                            {
                                _myuserdata[message.UserId].Add(Singleton<DataManager>.Instance.areaofwork[Int32.Parse(message.Text)].Name);
                                response = "Ingrese una especialización de su Emprendimiento";
                                return true;
                            }
                            else
                            {
                                response = "Dato mal ingresado, ingrese un numero de la lista";
                                return true;
                            }

                            case 8:
                            _myuserdata[message.UserId].Add(message.Text);
                            response = $"Como emprendedor tiene algún permiso especial? Si/No";
                            return true;
                            
                            case 9:
                            if(message.Text.ToUpper().Equals("SI"))
                            {
                                _myuserdata[message.UserId].Add($"permiso = {message.Text}");
                                responsetemp.Clear();                    
                                responsetemp.Append("Ingrese el permiso \n");
                                responsetemp.Append($"{Singleton<DataManager>.Instance.GetTextToPrintPermission()}\n");
                                response = $"{responsetemp}";
                                return true;
                            }
                            else if(message.Text.ToUpper().Equals("NO"))
                            {
                                _myuserdata[message.UserId].Add($"{message.Text}");
                                if(_mypermissions[message.UserId].Count > 0)
                                {
                                    responsetemp.Clear();
                                    responsetemp.Append("Se agregan los siguientes permisos \n");
                                    for (int i = 0; i < _mypermissions[message.UserId].Count; i++)
                                    {
                                        this.userpermissions.Add(Singleton<DataManager>.Instance.GetPermissionByIndex(Int32.Parse(_mypermissions[message.UserId][i])));
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
                    /*
                            if(message.Text.ToUpper().Equals("SI"))
                            {   
                               _myuserdata[message.UserId].Add(message.Text);
                                response = $"Ingrese un permiso \n{Singleton<DataManager>.Instance.GetTextToPrintPermission()}";
                                return true;
                            }
                            else if(message.Text.ToUpper().Equals("NO"))
                            {
                               _myuserdata[message.UserId].Add(message.Text);
                                response = "No se agregan permisos especiales, /continuar";   
                            }    
                            else
                            {
                                response = "Debe ingresar Si/No";
                                
                            }                 
                            return true; 
                   */
                            case 10:
                            if(_myuserdata[message.UserId][9].ToUpper().Contains("SI"))
                            {  
                                _mypermissions[message.UserId].Add(message.Text);
                                _myuserdata[message.UserId].RemoveAt(9);
                                response = "Desea Agregar otro Permiso? Si/No";
                                return true;
                            }
                            else
                            {
                                _mypermissions[message.UserId].Add(message.Text);
                                _myuserdata[message.UserId].Add(message.Text);
                                response = "Para finalizar presione /ok";
                                return true;     
                            }
    
                            case 11:

                            //_myuserdata[message.UserId].Add(Singleton<DataManager>.Instance.permissions[Int32.Parse(message.Text)].Name);
                            Singleton<DataManager>.Instance.AddEntrepreneur(message.UserId,_myuserdata[message.UserId][2],_myuserdata[message.UserId][3],_myuserdata[message.UserId][4],_myuserdata[message.UserId][5],_myuserdata[message.UserId][6],_myuserdata[message.UserId][7],_myuserdata[message.UserId][8],this.userpermissions);
                            response = "Se creó el Emprendedor correctamente\n Para ver las siguientes acciones posibles ingrese:\n/help";
                            _myuserdata.Remove(message.UserId);
                            _mypermissions.Remove(message.UserId);                                
                            return true;
                            
                        }
                    }
                }
            response = String.Empty ;
            return false;
        } 
    }
}


