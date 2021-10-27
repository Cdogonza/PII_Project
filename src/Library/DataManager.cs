
using System.Collections.Generic;
using System.Collections;
using System;
namespace ClassLibrary
{
    
    public class DataManager
    {
        public List<string> areaofwork = new List<string>();
        public List<MaterialType> materialsType = new List<MaterialType>();
        public List<Permission> permissions = new List<Permission>();


        // PERMISSIONS
        public void AddPermission(Permission item){
            this.permissions.Add(item);           
        }

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
     
        public  Permission GetPermissionByIndex(int indice)
        {
            indice-=1;
            return this.permissions[indice];
        }

        public  void GetTextToPrintPermission()
        {
            int contador=1;
            foreach (Permission item in this.permissions)
            {
               Console.WriteLine($"{contador}- {item}");
               contador+=1;
            }
        }

        public  List<Permission> GetPermissions()
        {
            return this.permissions;
        }
        
        
        // AREAS OF WORK 
        public void AddAreaOfWork(string item){
            this.areaofwork.Add(item);           
        }
        
        public bool CheckAreaOfWork(int indice)
        {
            if (indice <= this.areaofwork.Count ){
                return true;
            }
            else
            {
                return false;
            } 

        }        

        public  string GetAreaOfWorkByIndex(int indice)
        {
            indice-=1;
            return this.areaofwork[indice];
        }

        public  void GetTextToPrintAreaOfWork()
        {
            int contador=1;
            foreach (string item in this.areaofwork)
            {
               Console.WriteLine($"{contador}- {item}");
               contador+=1;
            }
        }

        public  List<string> GetAreasOfWork()
        {
            return this.areaofwork;
        }
      
        // MATERIALS
        public void AddMaterialType(MaterialType item){
            this.materialsType.Add(item);           
        }

        public bool CheckMaterialType(int indice)
        {
            if (indice <= this.materialsType.Count ){
                return true;
            }
            else
            {
                return false;
            } 

        }        
        public  MaterialType GetMaterialTypeByIndex(int indice)
        {
            indice-=1;
            return this.materialsType[indice];
        }

        public  void GetTextToPrintMaterialType()
        {
            int contador=1;
            foreach (MaterialType item in this.materialsType)
            {
               Console.WriteLine($"{contador}- {item}");
               contador+=1;
            }
        }

        public  List<MaterialType> GetMaterialsType()
        {
            return this.materialsType;
        }
    }

}

