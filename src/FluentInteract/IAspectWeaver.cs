using FluentInteract.Collections;
using System;

namespace FluentInteract
{
    public interface IAspectWeaver
    {
        ILogginAspectCollection GetLoggingAspects(IInteractor interactor, object input);

        bool ContainsAspect<TAspect>(IInteractor interactor, object input) where TAspect : IAspect;

        TAspect GetAspect<TAspect>(IInteractor interactor, object input, bool throwIfNotImplemented = false, Func<Exception> callbackException = null) where TAspect : IAspect;

        TAspect GetAspect<TAspect>(IInteractor interactor, object input, out TAspect aspectOut) where TAspect : IAspect;
    }
}
