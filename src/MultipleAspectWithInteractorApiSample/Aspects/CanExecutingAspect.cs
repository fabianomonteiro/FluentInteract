using FluentInteract;
using FluentInteract.Aspects;
using System.Threading.Tasks;

namespace MultipleAspectWithInteractorApiSample.Aspects
{
    public class CanExecutingAspect : ICanExecutingAspect
    {
        public bool IsMatch(IInteractor interactor, object input)
        {
            return true;
        }

        public Task<bool> CanExecute(IInteractor interactor, object input)
        {
            return Task.FromResult(true);
        }
    }
}
