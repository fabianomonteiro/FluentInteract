using System.Net.NetworkInformation;
using System.Threading.Tasks;

namespace FluentInteract.Aspects
{
    public abstract class CachingAspectBase : IChangingExecuteAspect
    {
        public abstract bool IsMatch(IInteractor interactor, IInput input);

        public abstract Task<IOutput> GetCache(IInteractor interactor, IInput input);

        public Task<IOutput> Execute(IInteractor interactor, IInput input)
        {
            return GetCache(interactor, input);
        }
    }
}
