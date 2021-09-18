using FluentInteract.Aspects;
using FluentInteract.Interfaces;
using System.Collections.Generic;

namespace FluentInteract.Collections
{
    public interface ILogginAspectCollection : IEnumerable<ILoggingAspect>, ILogging
    {
    }
}
