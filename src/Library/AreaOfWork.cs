using System.Collections.Generic;
using System;
namespace ClassLibrary
{
    public static class AreaOfWork
    {
        public static List<string> areaofwork = new List<string>();   
    
        public static void AddAreaOfWork(string area)
        {
            areaofwork.Add(area);
        }
        public static void RemoveAreaOfWork(string area)
        {
            areaofwork.Remove(area);
        }

        public static List<string> GetAreasOfWork()
        {
            return areaofwork;
        }

        public static void GetTextToPrint()
        {
            foreach (string item in areaofwork)
            {
               Console.WriteLine($"{item}");
            }

            
        }
    
        public static bool CheckAreaOfWork(int indice)
        {
            if (indice <= areaofwork.Count ){
                return true;
            }
            else
            {
                return false;
            } 
            
        }

        public static string GetAreaOfWorkByIndex(int indice)
        {
            return areaofwork[indice];
        }

    }
}
