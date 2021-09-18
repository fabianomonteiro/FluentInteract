using FluentInteract;
using LoggingAspectWithProxyApiSample.Models;

namespace MultipleAspectWithInteractorApiSample.Commands
{
    public interface IUpdateAccountCommand : IInteractor<Account, VoidOutput>
    {
    }
}
