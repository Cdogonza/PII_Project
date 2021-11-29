using System.Collections.ObjectModel;
using System.Collections.Generic;
using System;
namespace ClassLibrary{

    public class TelegramUserData{

        public Dictionary<string,Collection<string>> userdata = new Dictionary<string,Collection<string>>();
        public TelegramUserData()
        {

        }
        public string user()
        {
            string key = "";
            foreach(var pair in userdata)
            {
                
                    key = pair.Key;
                    Console.WriteLine(key);
                
            }
            return key;
        }
    }
}