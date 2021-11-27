
using System.Collections.Generic;
using System.Collections;
using System;
namespace ClassLibrary
{
    /// <summary>
    /// /// Esta clase es la encargada de manejar los datos de AreaOfWork(Rubros) MaterialsTypes y Permissions(Habilitaciones)
    /// Se implementa utilizando singleton con el fin de utilizar una unica instancia, 
    /// ya que no queremos que hayan multiples listas de Rubros, Permisos y Tipos de materiales
    /// </summary>
    public class DataManager
    {
      
        public List <string> data = new List<string>();  
        /// <summary>
        /// Lista de String donde se almacenan los rubros
        /// </summary>
        /// <typeparam List="string"></typeparam>
        /// <returns></returns>        
        public List<AreaOfWork> areaofwork = new List<AreaOfWork>(){new AreaOfWork("construccion"),new AreaOfWork("cocina"),new AreaOfWork("industria")};
        public List<Entrepreneur> entrepreneurs = new List<Entrepreneur>();
        public List<Company> companies = new List<Company>();

        /// <summary>
        /// Lista de MaterialType donde se almacenan los tipos de materiales 
        /// </summary>
        /// <typeparam List="MaterialType"></typeparam>
        /// <returns></returns>
        public List<MaterialType> materialsType = new List<MaterialType>(){new MaterialType("plastico","Descripcion plastico"),new MaterialType("papel","Descripcion papel"),new MaterialType("organico", "Descripcion organico")};

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
        public List<Permission> permissions = new List<Permission>(){new Permission("Materiales Peligrosos"), new Permission("Residuos Medicos"), new Permission("Materiales Organicos"), new Permission("Materiales Inflamables"), new Permission("Sin Permisos")};


        public List<Company>  DataCompany()
        {
            List<Company> companiesEmpty = new List<Company>();
            companies = companiesEmpty;
            return companies;
        }
        
        /// <summary>
        /// Metodo para agregar permisos al listado de permisos
        /// </summary>
        /// <param name="item"></param>
        
        public void AddPermission(Permission item)
        {
            this.permissions.Add(item);           
        }
        
        public void CerrarSession()
        {
        List<Entrepreneur>  vacia = new List<Entrepreneur>();
        List<Company>  vacia2 = new List<Company>();
        entrepreneurs = vacia;
        companies = vacia2;
        }

        public void AddEntrepreneur(string id ,string name,string phone,string calle,string ciudad,string departamento,string area, string specialization, string permission )
        {
            LocationApiClient Loc = new LocationApiClient();
            Location location = Loc.GetLocation(calle,ciudad,departamento);
            this.entrepreneurs.Add(new Entrepreneur(id,name,phone,location,area,specialization,permission));
        }

        public string GetEntrepreneur(string userid)
        {
            string datos = $"Los datos de su Emprendimiento son: \n";
            foreach (Entrepreneur item in this.entrepreneurs)
            {
                if (item.Id == userid)
                {
                   datos =$" {item.Name}\n {item.Phone}\n{item.Location.FormattedAddress}\n{item.Specialization}\n{item.Permissions}\n";
                   return datos;
                }
                else
                {
                    return null;
                }
                 
            }
            return null;
        }
        public void AddCompany(string id ,string name,string phone,string calle,string ciudad,string departamento,string area)
        {
          /*  Console.WriteLine($"id - {id}");
            Console.WriteLine($"name - {name}");
            Console.WriteLine($"phone - {phone}");
            Console.WriteLine($"calle - {calle}");
            Console.WriteLine($"ciudad - {ciudad}");
            Console.WriteLine($"depto - {departamento}");
            Console.WriteLine($"area - {area}"); */
            LocationApiClient Loc = new LocationApiClient();
            Location location = Loc.GetLocation(calle,ciudad,departamento);
            this.companies.Add(new Company(id,name,phone,location,area));
        }

        public string GetCompany(string userid)
        {
            string datos = $"Los datos de su Company son: \n";
            foreach (Company item in this.companies)
            {
                if (item.Id == userid)
                {
                   datos =$" {item.Name}\n {item.Phone}\n{item.Location.FormattedAddress}\n{item.AreaOfWork.Name}\n";
                   return datos;
                }
                else
                {
                    return null;
                }
                 
            }
            return null;
        }
    
        /// <summary>
        /// Metodo que chequea si el permiso ingresado por el usuario existe en la lista de Permisos del sistema. 
        /// /// </summary>
        /// <param name="indice"></param>
        /// <returns></returns>
        public bool CheckPermission(int indice)
        {
            if (indice <= this.permissions.Count ){
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
            indice-=1;
            return this.permissions[indice];
        }

        /// <summary>
        ///  Metodo utilizado para obtener todos los permisos de la lista y restornarlos como texto,
        ///  Para que ConsolePrinter pueda obtener ese texto e imprimirlo en pantalla.
        /// </summary>
        /// <returns>data</returns> Texto que obtiene ConsolePrinter para imprimir
        public string GetTextToPrintPermission()
        {
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
            return this.permissions;
        }
        
        /// <summary>
        /// Metodo para agregar Rubros a la lista de Rubros
        /// </summary>
        /// <param name="item"></param>
        public void AddAreaOfWork(AreaOfWork item)
        {
            this.areaofwork.Add(item);           
        }

        /// <summary>
        /// Metodo que corrobora si el numero ingresado por el usuario para agregar el rubro en su listado, existe en el listado de rubros.
        /// </summary>
        /// <param name="indice"></param>
        /// <returns>Retorna True si existe, sino retorna False</returns>        
        public bool CheckAreaOfWork(int indice)
        {
            if (indice <= this.areaofwork.Count )
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
            indice-=1;
            return this.areaofwork[indice];
        }

        /// <summary>
        ///  Metodo utilizado para obtener todos los rubros de la lista y retornarlos como texto,
        ///  Para que ConsolePrinter pueda obtener ese texto e imprimirlo en pantalla. 
        /// </summary>
        /// <returns>data</returns> Texto que obtiene ConsolePrinter para imprimir
        public string GetTextToPrintAreaOfWork()
        {
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
            return this.areaofwork;
        }
      
        /// <summary>
        /// Agrega un tipo de Material a la lista de MaterialTypes
        /// </summary>
        /// <param name="item"></param>
       
       public void AddMaterialType(string name, string description)
       {
           this.materialsType.Add(new MaterialType(name, description));
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
        public Material AddMaterial (string name, MaterialType type, string quantity)
        {
            Material newmaterial = new Material(name,type,quantity);
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
            if (indice <= this.materialsType.Count )
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
            indice-=1;
            return this.materialsType[indice];
        }
        
        /// <summary>
        /// Metodo utilizado para obtener todos los rubros de la lista y retornarlos como texto,
        /// Para que ConsolePrinter pueda obtener ese texto e 
        /// </summary>
        public string GetTextToPrintMaterialType()
        {
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
            return this.materialsType;
        }

        
    }

}

