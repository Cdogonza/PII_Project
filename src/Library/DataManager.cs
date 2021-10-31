
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

        public bool CheckPermission(int index)
        {
            if (index <= this.permissions.Count ){
                return true;
            }
            else
            {
                return false;
            } 

        }        
        
        public  Permission GetPermissionByIndex(int index)
        {
            index-=1;
            return this.permissions[index];
        }
        public  void GetTextToPrintPermission()
        {
            int counter=1;
            foreach (Permission item in this.permissions)
            {
               Console.WriteLine($"{counter}- {item}");
               counter+=1;
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
        
        public bool CheckAreaOfWork(int index)
        {
            if (index <= this.areaofwork.Count ){
                return true;
            }
            else
            {
                return false;
            } 

        }        

        public  string GetAreaOfWorkByIndex(int index)
        {
            index-=1;
            return this.areaofwork[index];
        }

        public  void GetTextToPrintAreaOfWork()
        {
            int counter=1;
            foreach (string item in this.areaofwork)
            {
               Console.WriteLine($"{counter}- {item}");
               counter+=1;
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

        public bool CheckMaterialType(int index)
        {
            if (index <= this.materialsType.Count ){
                return true;
            }
            else
            {
                return false;
            } 

        }        
        public  MaterialType GetMaterialTypeByIndex(int index)
        {
            index-=1;
            return this.materialsType[index];
        }

        public  void GetTextToPrintMaterialType()
        {
            int counter=1;
            foreach (MaterialType item in this.materialsType)
            {
               Console.WriteLine($"{counter}- {item}");
               counter+=1;
            }
        }

        public  List<MaterialType> GetMaterialsType()
        {
            return this.materialsType;
        }

        
    }

}

