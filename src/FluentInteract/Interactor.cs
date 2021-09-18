using FluentInteract.Aspects;
using FluentInteract.Exceptions;
using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace FluentInteract
{
    public abstract class Interactor<TInput, TOutput> : IInteractor<TInput, TOutput>
    {
        private TInput _input;
        private Task<TOutput> _output;

        private readonly IAspectWeaver _aspectWeaver;

        public Interactor() { }

        public Interactor(IAspectWeaver aspectWeaver)
        {
            _aspectWeaver = aspectWeaver;
        }

        protected virtual bool Authorize() => true;

        protected virtual bool CanExecute() => true;

        protected virtual bool Validate() => true;

        protected abstract Task<TOutput> ImplementExecute(TInput input);

        public virtual IInteractor<TInput, TOutput> Execute<TCallerInstance>(
            TCallerInstance callerInstance,
            [CallerMemberName] string memberName = "",
            [CallerFilePath] string sourceFilePath = "",
            [CallerLineNumber] int sourceLineNumber = 0)
            where TCallerInstance : class, ICallerInstance
        {
            if (!InternalAuthorize())
                throw new NotAuthorizedException();

            if (!InternalCanExecute())
                return this;

            if (!InternalValidate())
                return this;

            try
            {
                GetAspectWeaver()?
                    .GetLoggingAspects(this, _input)
                    .LogStartExecute(DateTime.Now, this, _input, callerInstance, memberName, sourceFilePath, sourceLineNumber);

                IChangingExecuteAspect changingExecuteAspect;

                var dateStart = DateTime.Now;

                _output = InternalImplementExecute(out changingExecuteAspect);

                var dateEnd = DateTime.Now;
                var elapsed = dateEnd.Subtract(dateStart);

                GetAspectWeaver()?
                   .GetLoggingAspects(this, _input)
                   .LogEndExecute(DateTime.Now, this, elapsed, changingExecuteAspect != null, changingExecuteAspect);
            }
            catch (Exception ex)
            {
                GetAspectWeaver()?
                   .GetLoggingAspects(this, _input)
                   .LogExceptionExecute(DateTime.Now, this, _input, ex, callerInstance, memberName, sourceFilePath, sourceLineNumber);

                throw ex;
            }

            return this;
        }

        private bool IsAspectWeaver()
        {
            return (_aspectWeaver ?? AspectWeaver.Singleton) != null;
        }

        private IAspectWeaver GetAspectWeaver()
        {
            return _aspectWeaver ?? AspectWeaver.Singleton;
        }

        private bool InternalAuthorize()
        {
            if (IsAspectWeaver())
            {
                return
                    GetAspectWeaver()
                        .GetAspect<IAuthorizingAspect>(this, _input)
                        .Authorize(this, _input)
                        .ConfigureAwait(false)
                        .GetAwaiter()
                        .GetResult();
            }

            return Authorize();
        }

        private bool InternalValidate()
        {
            if (IsAspectWeaver())
            {
                return
                    GetAspectWeaver()
                        .GetAspect<IValidatingAspect>(this, _input)
                        .Validate(this, _input)
                        .ConfigureAwait(false)
                        .GetAwaiter()
                        .GetResult();
            }

            return Validate();
        }

        private bool InternalCanExecute()
        {
            if (IsAspectWeaver())
            {
                return
                    GetAspectWeaver()
                        .GetAspect<ICanExecutingAspect>(this, _input)
                        .CanExecute(this, _input)
                        .ConfigureAwait(false)
                        .GetAwaiter()
                        .GetResult();
            }

            return CanExecute();
        }

        private Task<TOutput> InternalImplementExecute(out IChangingExecuteAspect changedExecuteAspect)
        {
            if (IsAspectWeaver() && GetAspectWeaver().ContainsAspect<IChangingExecuteAspect>(this, _input))
                return GetAspectWeaver()
                        .GetAspect(this, _input, out changedExecuteAspect)
                        .Execute(this, _input) as Task<TOutput>;

            changedExecuteAspect = null;

            return ImplementExecute(_input);
        }

        public IInteractor<TInput, TOutput> SetInput(TInput input)
        {
            _input = input;

            return this;
        }

        public async Task<TOutput> GetOutputAsync()
        {
            if (_output == null)
                return await Task.FromResult(default(TOutput));

            return await _output;
        }

        public TOutput GetOutput()
        {
            return _output.Result;
        }

        public IInteractor<TInput, TOutput> MapInput<TSource>(TSource source)
        {
            if (!IsAspectWeaver())
                throw new NotImplementedMappingAspectException();

            _input =
                GetAspectWeaver()
                    .GetAspect<IMappingAspect>(this, _input, true, () => new NotImplementedException())
                    .Map<TSource, TInput>(source).Result;

            return this;
        }

        public async Task<TDestination> GetOutputAsync<TDestination>()
        {
            if (!IsAspectWeaver())
                throw new NotImplementedMappingAspectException();

            return
                await GetAspectWeaver()
                        .GetAspect<IMappingAspect>(this, _input, true, () => new NotImplementedException())
                        .Map<TOutput, TDestination>(_output.Result);
        }
    }
}
