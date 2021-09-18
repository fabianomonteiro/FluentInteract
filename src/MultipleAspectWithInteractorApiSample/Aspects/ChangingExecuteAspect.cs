using FluentInteract;
using FluentInteract.Aspects;
using System.Threading.Tasks;

namespace MultipleAspectWithInteractorApiSample.Aspects
{
    public class ChangingExecuteAspect : IChangingExecuteAspect
    {
        public bool IsMatch(IInteractor interactor, object input)
        {
            return false;
        }

        public Task<object> Execute(IInteractor interactor, object input)
        {
            return Task.FromResult(new object());
        }
    }
}
