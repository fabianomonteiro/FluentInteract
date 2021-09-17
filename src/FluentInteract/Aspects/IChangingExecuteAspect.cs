using System.Threading.Tasks;

namespace FluentInteract.Aspects
{
    public interface IChangingExecuteAspect : IAspect
    {
        Task<IOutput> Execute(IInteractor interactor, IInput input);
    }
}
