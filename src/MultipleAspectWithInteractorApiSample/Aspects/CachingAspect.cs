using FluentInteract;
using FluentInteract.Aspects;
using System.Threading.Tasks;

namespace MultipleAspectWithInteractorApiSample.Aspects
{
    public class CachingAspect : CachingAspectBase
    {
        public override bool IsMatch(IInteractor interactor, object input)
        {
            return false;
        }

        public async override Task<object> GetCache(IInteractor interactor, object input)
        {
            return await Task.FromResult(new object());
        }
    }
}
