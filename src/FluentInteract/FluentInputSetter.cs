using System;
using System.Linq.Expressions;

namespace FluentInteract
{
    public class FluentInputSetter<TInput>
    {
        public FluentInputSetter<TInput> SetValue<TValue>(Expression<Func<TInput>> memberExpression, TValue value)
        {
            return this;
        }
    }
}
