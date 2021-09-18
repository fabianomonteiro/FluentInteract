using System.Threading.Tasks;

namespace FluentInteract.Aspects
{
    public interface ICanExecutingAspect : IAspect
    {
        Task<bool> CanExecute(IInteractor interactor, object input);
    }
}
