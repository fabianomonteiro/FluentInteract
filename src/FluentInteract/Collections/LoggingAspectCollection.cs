using FluentInteract.Aspects;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FluentInteract.Collections
{
    public class LoggingAspectCollection : List<ILoggingAspect>, ILogginAspectCollection
    {
        public LoggingAspectCollection(IEnumerable<ILoggingAspect> loggingAspects) : base(loggingAspects) { }

        public Task LogStartExecute(DateTime dateTime, IInteractor interactor, object input, ICallerInstance callerInstance, string memberName, string sourceFilePath, int sourceLineNumber)
        {
            foreach (var loggingAspect in this)
            {
                loggingAspect.LogStartExecute(dateTime, interactor, input, callerInstance, memberName, sourceFilePath, sourceLineNumber);
            }

            return Task.CompletedTask;
        }

        public Task LogEndExecute(DateTime dateTime, IInteractor interactor, TimeSpan elapsed, bool executeFromAspect, IAspect aspectExecutedInstance)
        {
            foreach (var loggingAspect in this)
            {
                loggingAspect.LogEndExecute(dateTime, interactor, elapsed, executeFromAspect, aspectExecutedInstance);
            }

            return Task.CompletedTask;
        }

        public Task LogExceptionExecute(DateTime dateTime, IInteractor interactor, object input, Exception exception, ICallerInstance callerInstance, string memberName, string sourceFilePath, int sourceLineNumber)
        {
            foreach (var loggingAspect in this)
            {
                loggingAspect.LogExceptionExecute(dateTime, interactor, input, exception, callerInstance, memberName, sourceFilePath, sourceLineNumber);
            }

            return Task.CompletedTask;
        }
    }
}
