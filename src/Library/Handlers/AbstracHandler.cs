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
        private ICondition<T> condition;

        public AbstractHandler<T> _nextHandler;
        public AbstractHandler<T> SetNext(AbstractHandler<T> handler)
        {
            this._nextHandler = handler;
            return handler;
        }
    
        protected AbstractHandler(ICondition<T> condition)
        {
            this.condition = condition;
        }

        public virtual T Handle(T request)
        {
                if (this.condition.IsSatisfied(request))
                {
                    return this.HandleRequest(request);
                }
                else
                {
                   if (this._nextHandler != null)
                    {
                    return this._nextHandler.Handle(request);
                    }
                    else
                    {
                        return request;
                    }
                }
        }
        
        protected abstract T HandleRequest(T request);
    }
}