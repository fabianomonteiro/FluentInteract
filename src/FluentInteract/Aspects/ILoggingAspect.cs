using System;
using System.Threading.Tasks;

namespace FluentInteract.Aspects
{
    public interface ILoggingAspect : IAspect
    {
        void LogStartExecute(
            IInteractor interactor,
            object input,
            ICallerInstance callerInstance,
            string memberName,
            string sourceFilePath,
            int sourceLineNumber);

        void LogEndExecute(
            IInteractor interactor,
            TimeSpan timeSpanExecution,
            bool executeFromAspect,
            IAspect aspectExecutedInstance);

        void LogExceptionExecute(
            IInteractor interactor,
            Exception exception);
    }
}
