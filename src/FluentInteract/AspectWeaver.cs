using FluentInteract.Aspects;
using FluentInteract.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace FluentInteract
{
    public class AspectWeaver : IAspectWeaver
    {
        public static IAspectWeaver Singleton { get; set; }

        private List<IAspect> _aspects = new List<IAspect>();
        public IReadOnlyList<IAspect> Aspects => _aspects;

        public AspectWeaver(params IAspect[] aspects)
        {
            _aspects.AddRange(aspects);
        }

        public void AddAspect<T>() where T : class, IAspect
        {
            _aspects.Add(Activator.CreateInstance<T>());
        }

        public bool ContainsAspect<TAspect>(IInteractor interactor, object input) where TAspect : IAspect
        {
            foreach (var aspect in Aspects.Where(x => x is TAspect))
            {
                if (aspect.IsMatch(interactor, input))
                    return true;
            }

            return false;
        }

        public TAspect GetAspect<TAspect>(IInteractor interactor, object input, bool throwIfNotImplemented = false, Func<Exception> callbackException = null) where TAspect : IAspect
        {
            foreach (var aspect in Aspects.Where(x => x is TAspect))
            {
                if (aspect.IsMatch(interactor, input))
                    return (TAspect)aspect;
            }

            if (throwIfNotImplemented)
                throw callbackException.Invoke();

            return default(TAspect);
        }

        public TAspect GetAspect<TAspect>(IInteractor interactor, object input, out TAspect aspectOut) where TAspect : IAspect
        {
            foreach (var aspect in Aspects.Where(x => x is TAspect))
            {
                if (aspect.IsMatch(interactor, input))
                    return aspectOut = (TAspect)aspect;
            }

            return aspectOut = default(TAspect);
        }

        public ILogginAspectCollection GetLoggingAspects(IInteractor interactor, object input)
        {
            var aspects = Aspects.Where(x => x is ILoggingAspect && x.IsMatch(interactor, input)).OfType<ILoggingAspect>();

            return new LoggingAspectCollection(aspects);
        }
    }
}
