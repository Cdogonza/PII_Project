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
            // {
        //     // string result = "{\"Items\":[";

        //     // foreach (var item in this.content.Items)
        //     // {
        //     //     result = result + item.ConvertToJson() + ",";
        //     // }

        //     // result = result.Remove(result.Length - 1);
        //     // result = result + "]}";

        //     // string temp = JsonSerializer.Serialize(this.content);
        //     // return result;
        //     JsonSerializerOptions options = new()
        //     {
        //         ReferenceHandler = MyReferenceHandler.Instance,
        //         WriteIndented = true
        //     };

        //     return JsonSerializer.Serialize(this.content, options);            
        // }
            
        }
        
    }

}