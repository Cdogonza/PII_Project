using System.Collections.ObjectModel;

namespace ClassLibrary
{ 
    public class DefaultHandler : BaseHandler
    {
        public DefaultHandler(BaseHandler next) : base(next)
        {
            this.Keywords = new string[] {"/help"};
        }
        protected override bool InternalHandle(IMessage message, out string response)
        {
            if(message.Text.ToLower().Equals("/help"))
            {
                if (Singleton<DataManager>.Instance.GetCompany(message.UserId) != null)
                {
                    response = "Los comandos disponibles para las empresas son\n/vermisdatos\n/registrarse\n/mostrar_materiales\n/cerrar_session";
                    return true;
                }else
                {
                    if(Singleton<DataManager>.Instance.GetEntrepreneur(message.UserId) != null)
                    {
                        response = "Los comandos disponibles para los emprendedores son\n /registrarse\n/vermisdato\n/cerrar_session";
                        return true;
                }else
                {
                    response = "Para comenzar indeque el comando /start";
                    return true;
                }
                 
                }                               
            }
            response = "Para ayuda indique /help para ayuda con los comandos";
            return true;
        }
    }
}