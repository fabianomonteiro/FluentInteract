using System.Threading.Tasks;

namespace FluentInteract.Aspects
{
    public interface IAuthorizingAspect : IAspect
    {
        Task<bool> Authorize(IInteractor interactor, object input);
    }
}
