using FluentInteract;
using FluentInteract.Aspects;
using System.Threading.Tasks;

namespace LoggingAspectWithProxyApiSample.Aspects
{
    public class AuthorizingAspect : IAuthorizingAspect
    {
        public bool IsMatch(IInteractor interactor, object input)
        {
            return true;
        }

        public Task<bool> Authorize(IInteractor interactor, object input)
        {
            return Task.FromResult(true);
        }
    }
}
