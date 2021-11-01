
using System.Collections.Generic;
using System.Collections;
using System;
namespace ClassLibrary
{
    /// <summary>
    /// 
    /// </summary>
    public class DataManager
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam List="string"></typeparam>
        /// <returns></returns>
        public List<string> areaofwork = new List<string>();
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam List="MaterialType"></typeparam>
        /// <returns></returns>
        public List<MaterialType> materialsType = new List<MaterialType>();
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam List="Permission"></typeparam>
        /// <returns></returns>
        public List<Permission> permissions = new List<Permission>();

        // PERMISSIONS
        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        public void AddPermission(Permission item){
            this.permissions.Add(item);           
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public  Permission GetPermissionByIndex(int index)
        {
            index-=1;
            return this.permissions[index];
        }
        /// <summary>
        /// 
        /// </summary>
        public  void GetTextToPrintPermission()
        {
            int counter=1;
            foreach (Permission item in this.permissions)
            {
               Console.WriteLine($"{counter}- {item}");
               counter+=1;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public  List<Permission> GetPermissions()
        {
            return this.permissions;
        }
        
        // AREAS OF WORK 
        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        
        public void AddAreaOfWork(string item){
            this.areaofwork.Add(item);           
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public  string GetAreaOfWorkByIndex(int index)
        {
            index-=1;
            return this.areaofwork[index];
        }
        /// <summary>
        /// 
        /// </summary>
        public  void GetTextToPrintAreaOfWork()
        {
            int counter=1;
            foreach (string item in this.areaofwork)
            {
               Console.WriteLine($"{counter}- {item}");
               counter+=1;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public  List<string> GetAreasOfWork()
        {
            return this.areaofwork;
        }
        ///
        /// 
        // MATERIALS
        public void AddMaterialType(MaterialType item){
            this.materialsType.Add(item);           
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public  MaterialType GetMaterialTypeByIndex(int index)
        {
            index-=1;
            return this.materialsType[index];
        }
        /// <summary>
        /// 
        /// </summary>
        public  void GetTextToPrintMaterialType()
        {
            int counter=1;
            foreach (MaterialType item in this.materialsType)
            {
               Console.WriteLine($"{counter}- {item}");
               counter+=1;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public  List<MaterialType> GetMaterialsType()
        {
            return this.materialsType;
        }

        
    }

}

