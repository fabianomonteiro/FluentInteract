using System.Threading.Tasks;

namespace FluentInteract.Aspects
{
    public interface IChangingExecuteAspect : IAspect
    {
        Task<object> Execute(IInteractor interactor, object input);
    }
}
