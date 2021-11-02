using System;

namespace ClassLibrary
{
    public class Singleton <T> where T : new ()
    {
        private Singleton()
        {
            
        }
        private static T instance;

        public static T Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new T();
                }

                return instance;
            }
        }
    }
}