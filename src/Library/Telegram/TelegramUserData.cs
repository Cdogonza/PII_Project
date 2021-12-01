using System.Collections.ObjectModel;
using System.Collections.Generic;
using System;
namespace ClassLibrary
{
    /// <summary>
    /// Esta clase auxiliar es utlizada para almacenar y manejar informacion corresondiente a las acciones del usuario en el flujo del chat.
    /// Esta clase se justifica con el principio SRP ya que existe para cumplir solamente con la responsabiliadad de manejar los datos de los usuarios.
    /// </summary>
    public class TelegramUserData
    {

        public Dictionary<string, Collection<string>> userdata = new Dictionary<string, Collection<string>>();
        public Dictionary<string, Collection<string>> materialtypeDict = new Dictionary<string, Collection<string>>();
        public Dictionary<string, Collection<string>> permissionsDict = new Dictionary<string, Collection<string>>();
        public Dictionary<string, Collection<string>> tagsDict = new Dictionary<string, Collection<string>>();

        public TelegramUserData()
        {

        }
        public string user()
        {
            string key = "";
            foreach (var pair in userdata)
            {

                key = pair.Key;
                Console.WriteLine(key);

            }
            return key;
        }
    }
}