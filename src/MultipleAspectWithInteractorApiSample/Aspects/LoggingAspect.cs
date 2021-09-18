using FluentInteract;
using FluentInteract.Aspects;
using System;
using System.Threading.Tasks;

namespace LoggingAspectWithProxyApiSample.Aspects
{
    public class LoggingAspect : ILoggingAspect
    {
        public bool IsMatch(IInteractor interactor, object input)
        {
            return true;
        }

        public Task LogStartExecute(DateTime dateTime, IInteractor interactor, object input, ICallerInstance callerInstance, string memberName, string sourceFilePath, int sourceLineNumber)
        {
            Console.WriteLine("Start Execute");

            return Task.CompletedTask;
        }

        public Task LogEndExecute(DateTime dateTime, IInteractor interactor, TimeSpan elapsed, bool executeFromAspect, IAspect aspectExecutedInstance)
        {
            Console.WriteLine("End Execute");

            return Task.CompletedTask;
        }

        public Task LogExceptionExecute(DateTime dateTime, IInteractor interactor, object input, Exception exception, ICallerInstance callerInstance, string memberName, string sourceFilePath, int sourceLineNumber)
        {
            Console.WriteLine("Exception Execute");

            return Task.CompletedTask;
        }
    }
}
