using System.Collections.Generic;
using System;
//using System.ComponentModel.Composition;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;

namespace ClassLibrary
{
    
    public abstract class AbstractHandler<T>
    {
       

        public AbstractHandler<T> _nextHandler;
        public AbstractHandler<T> SetNext(AbstractHandler<T> handler)
        {
            this._nextHandler = handler;
            return handler;
        }
    
        protected AbstractHandler()
        {
           
        }

        public virtual UserRequest Handle(UserRequest request)
        {

                if (request.Status == true)
                {
                    
                    request.Status=false;
                    return this.HandleRequest(request);
                   
                }
                else
                {
                   if (this._nextHandler != null)
                    {                   
                    request.Status=true;
                    return this._nextHandler.Handle(request);
                    }
                    else
                    {
                        return request;
                    }
                }
        }
        
        protected abstract UserRequest HandleRequest(UserRequest request);
    }
}