
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using System;
using System.ComponentModel;
using System.Collections.Immutable;

namespace ClassLibrary
{
    /// <summary>
    /// /// Esta clase es la encargada de manejar los datos de AreaOfWork(Rubros) MaterialsTypes y Permissions(Habilitaciones)
    /// Se implementa utilizando singleton con el fin de utilizar una única instancia,
    /// ya que no queremos que hayan múltiples listas de Rubros, Permisos y Tipos de materiales
    /// CREATOR: Esta clase cumple con el patrón creator, ya que contiene, agrega y guarda instancias de otra clase además de ser el responsable de la carcón de las mismas.
    /// </summary>
    /// 
    public class DataManager : IJsonConvertible

    {
        [JsonConstructor]        
        public DataManager()
        {
            this.companies = new List<Company>();
            this.entrepreneurs = new List<Entrepreneur>();
            this.permissions = new List<Permission>();
        }
       
        public List <string> data = new List<string>();  
        /// <summary>
        /// Lista de String donde se almacenan los rubros
        /// </summary>
        /// <typeparam List="string"></typeparam>
        /// <returns></returns>        
        public List<AreaOfWork> areaofwork = new List<AreaOfWork>();
        [JsonInclude]
        public List<Entrepreneur> entrepreneurs = new List<Entrepreneur>();
        [JsonInclude]
        public List<Company> companies = new List<Company>();

        /// <summary>
        /// Lista de MaterialType donde se almacenan los tipos de materiales 
        /// </summary>
        /// <typeparam List="MaterialType"></typeparam>
        /// <returns></returns>
        [JsonInclude]
        public List<MaterialType> materialsType = new List<MaterialType>();
        /// <summary>
        /// Lista de Material donde se almacenan los materiales
        /// </summary>
        /// <typeparam name="Material"></typeparam>
        /// <returns></returns>
        public List<Material> materials = new List<Material>();

        /// <summary>
        /// Lista de Permisos donde se almacenan los permisos a ser usados por las empresas y las ofertas
        /// </summary>
        /// <typeparam List="Permission"></typeparam>
        /// <returns></returns>
        [JsonInclude]
        public List<Permission> permissions = new List<Permission>(); 
        public List<Company>  DataCompany()
        {
            
            return companies;
        }
        public string  DataEnt(string id)
        {
           
           
            this.LoadFromJsonEntrepreneur();
            foreach (Entrepreneur item in this.entrepreneurs)
            {
              if(item.Id==id)
              {
                   return item.Id;
               }  
            }
  
           return null;
        }
        


        public List<Entrepreneur>  DataEntrepeneur()
        {
            
            return entrepreneurs;
        }
        public void CloseSession()
        {
            List<Entrepreneur>  vacia = new List<Entrepreneur>();
            List<Company>  vacia2 = new List<Company>();
            entrepreneurs = vacia;
            this.companies = vacia2;
        }
        public void AddEntrepreneur(string id ,string name,string phone,string calle,string ciudad,string departamento,string area, string specialization, List<Permission> permission )
        {
            LocationApiClient Loc = new LocationApiClient();
            Location location = Loc.GetLocation(calle,ciudad,departamento);
            this.entrepreneurs.Add(new Entrepreneur(id,name,phone,location,area,specialization,permission));
             this.ConvertToJsonEntrepreneur();
        }
        public void AddCompany(string id ,string name,string phone,string calle,string ciudad,string departamento,string area)
        {
            LocationApiClient Loc = new LocationApiClient();
            Location location = Loc.GetLocation(calle,ciudad,departamento);
            this.companies.Add(new Company(id,name,phone,location,area));
            this.ConvertToJsonCompany();
        }

        public string GetEntrepreneur(string userid)
        {
            this.LoadFromJsonEntrepreneur();
            string datos = $"Los datos de su Emprendimiento son: \n";
            foreach (Entrepreneur item in this.entrepreneurs)
            {
                if (item.Id == userid)
                {
                   datos =$"Nombre: {item.Name}\nTelefono: {item.Phone}\nDireccion:{item.Location.FormattedAddress}\nEspecializacion:{item.Specialization}\nPermisos: {item.Permissions}\n";
                   return datos;
                }  
            }
            return null;
        }
        
        public string GetCompany(string userid)
        {
            
            this.LoadFromJsonCompany();
            string datos = $"Los datos de su Company son: \n";
            foreach (Company item in this.companies)
            {
                if (item.Id == userid)
                {
                   datos =$"Nombre: {item.Name}\nTelefono: {item.Phone}\nDireccion: {item.Location.FormattedAddress}\nRubro: {item.AreaOfWork.Name}\n ";
                   return datos;
                }       
            }
            return null; 
        }
    

        /// <summary>
        /// Metodo para agregar permisos al listado de permisos
        /// </summary>
        /// <param name="item"></param>
        public void AddPermission(string permission)
        {
            this.permissions.Add(new Permission (permission)); 
            this.ConvertToJsonPermissions();          
        }

        /// <summary>
        /// Metodo que chequea si el permiso ingresado por el usuario existe en la lista de Permisos del sistema. 
        /// /// </summary>
        /// <param name="indice"></param>
        /// <returns></returns>
        public bool CheckPermission(int indice)
        {
            this.LoadFromJsonPermission();
            if (indice <= this.permissions.Count-1 )
            {
                return true;
            }
            else
            {
                return false;
            } 

        }

        /// <summary>
        ///  Metodo que retorna el permiso segun el lugar de la lista ingresado
        /// </summary>
        /// <param name="indice"></param>
        /// <returns></returns> 
        public Permission GetPermissionByIndex(int indice)
        {
            this.LoadFromJsonPermission();
            return this.permissions[indice];
        }

        public string GetPermissionByIndexText(int indice)
        {
            this.LoadFromJsonPermission();
            Console.WriteLine($"This-Permission {this.permissions[indice].Name}");
            return this.permissions[indice].Name;
        }

        /// <summary>
        ///  Metodo utilizado para obtener todos los permisos de la lista y restornarlos como texto,
        ///  Para que ConsolePrinter pueda obtener ese texto e imprimirlo en pantalla.
        /// </summary>
        /// <returns>data</returns> Texto que obtiene ConsolePrinter para imprimir
        public string GetTextToPrintPermission()
        {
            this.LoadFromJsonPermission();
            int contador=0;
            string data = $"La lista de Permisos existentes son: \n";
            foreach (Permission item in this.permissions)
            {
               data = data + $"{contador}- {item.Name}\n"; 
               contador+=1;
            }
            return data;
        }

        /// <summary>
        ///  Retorna la lista de Permisos almacenados en el sistema
        /// </summary>
        /// <returns></returns>
        public List<Permission> GetPermissions()
        {
            this.LoadFromJsonPermission();
            return this.permissions;
        }
        
        /// <summary>
        /// Metodo para agregar Rubros a la lista de Rubros
        /// </summary>
        /// <param name="item"></param>
        public void AddAreaOfWork(string areaOfWork)
        {
            this.areaofwork.Add(new AreaOfWork (areaOfWork)); 
            this.ConvertToJsonAreaOfWork();          
        }

        /// <summary>
        /// Metodo que corrobora si el numero ingresado por el usuario para agregar el rubro en su listado, existe en el listado de rubros.
        /// </summary>
        /// <param name="indice"></param>
        /// <returns>Retorna True si existe, sino retorna False</returns>        
        public bool CheckAreaOfWork(int indice)
        {
            this.LoadFromJsonAreaOfWork();
            if (indice <= this.areaofwork.Count-1)
            {
                return true;
            }
            else
            {
                return false;
            } 
        }

        /// <summary>
        /// Metodo que retorna el Rubro segun el lugar ingresado de la lista
        /// </summary>
        /// <param name="indice"></param>
        /// <returns></returns>
        public AreaOfWork GetAreaOfWorkByIndex(int indice)
        {
            this.LoadFromJsonAreaOfWork();
            return this.areaofwork[indice];
        }

        /// <summary>
        ///  Metodo utilizado para obtener todos los rubros de la lista y retornarlos como texto,
        ///  Para que ConsolePrinter pueda obtener ese texto e imprimirlo en pantalla. 
        /// </summary>
        /// <returns>data</returns> Texto que obtiene ConsolePrinter para imprimir
        public string GetTextToPrintAreaOfWork()
        {
            this.LoadFromJsonAreaOfWork();
            string data = $"La lista de Rubros existentes son: \n";
            int contador=0;
            foreach (AreaOfWork item in this.areaofwork)
            {
               data = data + $"{contador} - {item.Name}\n";
               contador+=1;
            }
            return data;
        }

        /// <summary>
        /// Retorna la lista de Rubros almacenados en el sistema
        /// </summary>
        /// <returns></returns>
        public List<AreaOfWork> GetAreasOfWork()
        {
            this.LoadFromJsonAreaOfWork();
            return this.areaofwork;
        }
      
        /// <summary>
        /// Agrega un tipo de Material a la lista de MaterialTypes
        /// </summary>
        /// <param name="item"></param>
       
       public MaterialType AddMaterialType(string name, string description)
       {
           MaterialType newmaterialtype = new MaterialType(name, description);
           this.materialsType.Add(newmaterialtype);
           this.ConvertToJsonMaterialTypes();
           return newmaterialtype;
       }
       /* public void AddMaterialType(MaterialType item)
        {
            this.materialsType.Add(item);           
        }
       */
       
        /// <summary>
        /// El metodo crea una instacia de Material y la agrega al catalogo.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="type"></param>
        /// <param name="quantity"></param>
        /// <returns>newmaterial</returns>
        public Material AddMaterial (string name, MaterialType type, string unit)
        {
            Material newmaterial = new Material(name,type,unit);
            this.materials.Add(newmaterial);
            return newmaterial;
        }

        /// <summary>
        /// Crea una instancia de la empresa
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        public Company GetCompanyInstance(string userid)
        {
            foreach (Company item in this.companies)
            {
                if (item.Id == userid)
                {
                   return item;
                }
            }
            return null;
        }


        /// <summary>
        /// Verifica si el material ingresado por el usuario existe en la lista de Materiales.
        /// </summary>
        /// <param name="indice"></param>
        /// <returns>Retorna True si el Tipo de Material existe en la lista, sino existe devuelve False</returns>
        public bool CheckMaterialType(int indice)
        {
            this.LoadFromJsonMaterialTypes();
            if (indice <= this.materialsType.Count-1 )
            {
                return true;
            }
            else
            {
                return false;
            } 
        }

        /// <summary>
        /// Metodo que retorna el Tipo de Material segun el lugar ingresado de la lista
        /// </summary>
        /// <param name="indice"></param>
        /// <returns></returns>
        public MaterialType GetMaterialTypeByIndex(int indice)
        {
            this.LoadFromJsonMaterialTypes();
            return this.materialsType[indice];
        }
        
        /// <summary>
        /// Metodo utilizado para obtener todos los rubros de la lista y retornarlos como texto,
        /// Para que ConsolePrinter pueda obtener ese texto e 
        /// </summary>
        public string GetTextToPrintMaterialType()
        {
            this.LoadFromJsonMaterialTypes();
            string data = $"La lista de Materiales existentes son: \n";
            int contador=0;
            foreach (MaterialType item in this.materialsType)
            {
                data = data + $"{contador} - {item.Name} - {item.Description}\n";
                contador+=1;
            }
            return data;
        }

        /// <summary>
        /// Retorna la lista de Materiales almacenados en el sistema
        /// </summary>
        /// <returns></returns>
        public List<MaterialType> GetMaterialsType()
        {
            this.LoadFromJsonMaterialTypes();
            return this.materialsType;
        }
        public string ConvertToJsonCompany()
        {
            string result = "{\"Items\":[";

            foreach (Company item in this.companies)
            {
                result = result + item.ConvertToJsonCompany() + ",";
            }

            result = result.Remove(result.Length - 1);
            result = result + "]}";

            string temp = JsonSerializer.Serialize(this.companies);
             File.WriteAllText(@"Companies.json", temp);
            return result;
            
            JsonSerializerOptions options = new()
            {
                ReferenceHandler = MyReferenceHandler.Instance,
                WriteIndented = true
            };

            return JsonSerializer.Serialize(this.companies, options);            
        }
         public void LoadFromJsonCompany()
        {
            if(!File.Exists(@"Companies.json"))
            {
                File.AppendAllText(@"Companies.json", "");
            }                        
            string json = File.ReadAllText(@"Companies.json");
            if(json!="")
            {
            //this.Initialize();
            //this.companies = JsonSerializer.Deserialize<Company>(json);
            JsonSerializerOptions options = new()
            {
                ReferenceHandler = MyReferenceHandler.Instance,
                WriteIndented = true
            };

            this.companies = JsonSerializer.Deserialize<List<Company>>(json, options);
           
            }
        }
        public string ConvertToJsonOffer()
        {return null;}
        public string ConvertToJsonEntrepreneur()
        {
            string result = "{\"Items\":[";

            foreach (Entrepreneur item in this.entrepreneurs)
            {
                result = result + item.ConvertToJsonEntrepreneur() + ",";
            }

            result = result.Remove(result.Length - 1);
            result = result + "]}";

            string temp = JsonSerializer.Serialize(this.entrepreneurs);
             File.WriteAllText(@"Entrepreneur.json", temp);
            return result;
            JsonSerializerOptions options = new()
            {
                ReferenceHandler = MyReferenceHandler.Instance,
                WriteIndented = true
            };

            return JsonSerializer.Serialize(this.entrepreneurs, options);            
        }
     
        public void LoadFromJsonEntrepreneur()
        {
            if(!File.Exists(@"Entrepreneur.json"))
            {
                File.AppendAllText(@"Entrepreneur.json", "");
            }            
            string json = File.ReadAllText(@"Entrepreneur.json");
            if(json!="")
            {

            JsonSerializerOptions options = new()
            {
                ReferenceHandler = MyReferenceHandler.Instance,
                WriteIndented = true
            };

            this.entrepreneurs = JsonSerializer.Deserialize<List<Entrepreneur>>(json, options);
           
            }
        }

        public string ConvertToJsonPermissions()
        {
            string result = "{\"Items\":[";

            foreach (Permission item in this.permissions)
            {
                result = result + item.ConvertToJsonPermissions() + ",";
            }

            result = result.Remove(result.Length - 1);
            result = result + "]}";

            string temp = JsonSerializer.Serialize(this.permissions);
            File.WriteAllText(@"Permissions.json", temp);
            return result;
            JsonSerializerOptions options = new()
            {
                ReferenceHandler = MyReferenceHandler.Instance,
                WriteIndented = true
            };

            return JsonSerializer.Serialize(this.permissions, options);            
        }

        public void LoadFromJsonPermission()
        {
            if(!File.Exists(@"Permissions.json"))
            {
                File.AppendAllText(@"Permissions.json", "");
            }
            string json = File.ReadAllText(@"Permissions.json");
            if(json!="")
            {

            JsonSerializerOptions options = new()
            {
                ReferenceHandler = MyReferenceHandler.Instance,
                WriteIndented = true
            };

            this.permissions = JsonSerializer.Deserialize<List<Permission>>(json, options);
           
            }
        }
     

        public string ConvertToJsonMaterialTypes()
        {
            string result = "{\"Items\":[";

            foreach (MaterialType item in this.materialsType)
            {
                result = result + item.ConvertToJsonMaterialTypes() + ",";
            }

            result = result.Remove(result.Length - 1);
            result = result + "]}";

            string temp = JsonSerializer.Serialize(this.materialsType);
            File.WriteAllText(@"MaterialTypes.json", temp);
            return result;
            JsonSerializerOptions options = new()
            {
                ReferenceHandler = MyReferenceHandler.Instance,
                WriteIndented = true
            };

            return JsonSerializer.Serialize(this.materialsType, options);            
        }

        public void LoadFromJsonMaterialTypes()
        {
            if(!File.Exists(@"MaterialTypes.json"))
            {
                File.AppendAllText(@"MaterialTypes.json", "");
            }
            string json = File.ReadAllText(@"MaterialTypes.json");
            if(json!="")
            {

            JsonSerializerOptions options = new()
            {
                ReferenceHandler = MyReferenceHandler.Instance,
                WriteIndented = true
            };

            this.materialsType = JsonSerializer.Deserialize<List<MaterialType>>(json, options);
           
            }
        }

        public string ConvertToJsonAreaOfWork()
        {
            string result = "{\"Items\":[";

            foreach (AreaOfWork item in this.areaofwork)
            {
                result = result + item.ConvertToJsonAreaOfWork() + ",";
            }

            result = result.Remove(result.Length - 1);
            result = result + "]}";

            string temp = JsonSerializer.Serialize(this.areaofwork);
            File.WriteAllText(@"AreaOfWork.json", temp);
            return result;
            JsonSerializerOptions options = new()
            {
                ReferenceHandler = MyReferenceHandler.Instance,
                WriteIndented = true
            };

            return JsonSerializer.Serialize(this.areaofwork, options);            
        }

        public void LoadFromJsonAreaOfWork()
        {
            if(!File.Exists(@"AreaOfWork.json"))
            {
                File.AppendAllText(@"AreaOfWork.json", "");
            }
            string json = File.ReadAllText(@"AreaOfWork.json");
            if(json!="")
            {

            JsonSerializerOptions options = new()
            {
                ReferenceHandler = MyReferenceHandler.Instance,
                WriteIndented = true
            };

            this.areaofwork = JsonSerializer.Deserialize<List<AreaOfWork>>(json, options);
           
            }
        }
    }

}

