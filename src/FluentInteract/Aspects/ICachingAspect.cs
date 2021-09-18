using System.Threading.Tasks;

namespace FluentInteract.Aspects
{
    public abstract class CachingAspectBase : IChangingExecuteAspect
    {
        public abstract bool IsMatch(IInteractor interactor, object input);

        public abstract Task<object> GetCache(IInteractor interactor, object input);

        public Task<object> Execute(IInteractor interactor, object input)
        {
            return GetCache(interactor, input);
        }
    }
}
