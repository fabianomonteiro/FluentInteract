using System;
using System.Threading.Tasks;

namespace FluentInteract.Interfaces
{
    public interface ILogging
    {
        Task LogStartExecute(
            DateTime dateTime,
            IInteractor interactor,
            object input,
            ICallerInstance callerInstance,
            string memberName,
            string sourceFilePath,
            int sourceLineNumber);

        Task LogEndExecute(
            DateTime dateTime,
            IInteractor interactor,
            TimeSpan elapsed,
            bool executeFromAspect,
            IAspect aspectExecutedInstance);

        Task LogExceptionExecute(
            DateTime dateTime,
            IInteractor interactor,
            object input,
            Exception exception,
            ICallerInstance callerInstance,
            string memberName,
            string sourceFilePath,
            int sourceLineNumber);
    }
}
