using System;

namespace ClassLibrary
{
    /// <summary>
    /// Esta clase tiene como responsabilidad crear una sola instancia de las clases que la implementan (Datamanager y OfferManager)
 /// Esta clase se justifica con el patrón singleton, ya que es nos permite centralizar la información del programa en varias clases únicas que podemos utilizar dentro de nuestro programa de forma global.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Singleton <T> where T : new ()
    {
        private Singleton()
        {
            
        }
        private static T instance;
        /// <summary>
        /// Crea una instancia Singleton en caso de que no exista, en caso de que exista devuelve la clase existente.
        /// </summary>
        /// <value></value>
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