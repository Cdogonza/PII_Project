using System.Collections.Generic;
using System;
using System.Text.Json;
using System.IO;
using System.Linq;
namespace ClassLibrary
{   
    
    public  class DataPersister
    {
        public DataPersister()
        {
            
        }
        
       public  static void SaveData(string colection,IJsonConvertible instance)
        {   
            string currentObjs = "";
            if (File.Exists($"{@colection}.json")){
                currentObjs  = File.ReadAllText($"{@colection}.json");
            }
            
            string json = instance.ConvertToJson();     
            // File.WriteAllText($"{@colection}.json", json);
            
            if (currentObjs != ""){
                File.WriteAllText($"{@colection}.json", currentObjs+ '|' + json);
            }else{
                File.WriteAllText($"{@colection}.json",json);
            }
            
        }
        
    }

}