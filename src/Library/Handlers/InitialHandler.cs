using System;
namespace ClassLibrary
{
    /// <summary>
    /// El handler inicial, el cual modifica el estado del pedido según lo necesitado.
    /// </summary>
    public class InitialHandler: BaseHandler
    {
        public InitialHandler(BaseHandler next) : base(next)
        {
            this.Keywords = new string[] {"/registrarse"};
        }
        protected override bool InternalHandle(IMessage message, out string response)
        {
            
            if(message.Text.ToLower().Equals( "/registrarse") )
            {
                
               if (Singleton<DataManager>.Instance.GetEntrepreneur(message.UserId) != null | Singleton<DataManager>.Instance.GetCompany(message.UserId) != null)
                {
                    response = "Usted ya se encuentra registrado";
                    return true;
                }else
                {
                    
                }
                return true;
            }else
            {
                response = "no entendi";
                return false;
            }

    }
        
}

