using Telegram.Bot.Types;

namespace ClassLibrary
{
    
    /// <summary>
    /// 
    // COR: En este caso aplicamos el patrón COR(Chain of Responsabilities), definidiendo una interfaz con todos los metodos de las clases(hanlders) que forman para de nuestra cadena.
    // OCP: El patron ocp se respeta ya que de esta manera si se quiere extender el
    // el comportamiento no será necesario que se modifiquen las clases, sino que se creen nuevos handlers que implementen esta interfaz.
    /// </summary>
    public interface IHandler
    {
        /// <summary>
        /// Obtiene el próximo "handler".
        /// </summary>
        /// <value>El "handler" que será invocado si este "handler" no procesa el mensaje.</value>
        IHandler Next { get; set; }

        /// <summary>
        /// Procesa el mensaje o la pasa al siguiente "handler" si existe.
        /// </summary>
        /// <param name="message">El mensaje a procesar.</param>
        /// <param name="response">La respuesta al mensaje procesado.</param>
        /// <returns>El "handler" que procesó el mensaje si el mensaje fue procesado; null en caso contrario.</returns>
        IHandler Handle(IMessage message, out string response);

        /// <summary>
        /// Retorna este "handler" al estado inicial y cancela el próximo "handler" si existe. Es utilizado para que los
        /// "handlers" que procesan varios mensajes cambiando de estado entre mensajes puedan volver al estado inicial en
        /// caso de error por ejemplo.
        /// </summary>
        void Cancel();
    }
}