using System.Threading.Tasks;

namespace FluentInteract.Aspects
{
    public interface IValidatingAspect : IAspect
    {
        Task<bool> Validate(IInteractor interactor, object input);
    }
}
