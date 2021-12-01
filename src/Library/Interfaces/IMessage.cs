namespace ClassLibrary
{

    /// <summary>
    /// Esta interfaz define el formato que tienen que tener los mensajes manejados por nuestro programa.
    /// /// ADAPTER: Esta interfaz es justificada con el patron adaptar ya que se utilizo para que los mensajes manejados por el programa puedan ser de cualquier clase que implemente esta interfaz 
    /// y asi poder extender su funcionalidad a otras plataformas.
    /// </summary>
    public interface IMessage
    {
        string Text { get; set; }
        string ChatId { get; }
        string UserId { get; }
        string FirstName { get; }

    }

}