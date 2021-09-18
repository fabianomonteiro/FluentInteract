using FluentInteract;
using FluentInteract.Aspects;
using System.Threading.Tasks;

namespace LoggingAspectWithProxyApiSample.Aspects
{
    public class ValidatingAspect : IValidatingAspect
    {
        public bool IsMatch(IInteractor interactor, object input)
        {
            return true;
        }

        public Task<bool> Validate(IInteractor interactor, object input)
        {
            return Task.FromResult(true);
        }
    }
}
