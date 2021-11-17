using System.Collections.Generic;
using System;
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

        public virtual T Handle(T request)
        {
                return this.HandleRequest(request);
                if (this._nextHandler != null)
                {
                    return this._nextHandler.Handle(request);
                }
                else
                {
                    return request;
                }
        }
        
        protected abstract T HandleRequest(T request);
    }
}