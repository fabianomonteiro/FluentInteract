using FluentInteract;
using LoggingAspectWithProxyApiSample.Models;

namespace MultipleAspectWithInteractorApiSample.Queries
{
    public interface IGetAccountQuery : IInteractor<int, Account>
    {
    }
}
