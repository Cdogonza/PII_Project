
namespace ClassLibrary
{
    /// <summary>
    /// El handler inicial, el cual modifica el estado del pedido según lo necesitado.
    /// </summary>
    public class InitialHandler : AbstractHandler<UserRequest>
    {
        public InitialHandler()
        {
        }
        protected override UserRequest HandleRequest(UserRequest request)
        {
            request.Message = "Ingrese el título";
            if (request.Message == "Escribir")
            {
                // request.State = StateEnum.Status1;
                request.Message = "Ingrese el título";
                return request;
            }
            
            
            else if (request.Message == "Configurar")
            {
                // request.State= StateEnum.Status1;
                request.Message = "Ingrese Información";
                return request;
            }
            else
            {
                request.Message = "¿Que quiere hacer? \nIngresar informacion --> Escribir\nComenzar la configuración --> Configurar";
                return request;
            }
        }
    }
}