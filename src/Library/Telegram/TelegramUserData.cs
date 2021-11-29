using System.Collections.ObjectModel;
using System.Collections.Generic;

namespace ClassLibrary{

    public class TelegramUserData{

        public Dictionary<string,Collection<string>> userdata = new Dictionary<string,Collection<string>>();
        public Dictionary<string,Collection<string>> materialtypeDict = new Dictionary<string,Collection<string>>();
        public Dictionary<string,Collection<string>> permissionsDict = new Dictionary<string,Collection<string>>();  
        public Dictionary<string,Collection<string>> tagsDict = new Dictionary<string,Collection<string>>();  

        public TelegramUserData()
        {

        }
    }
}