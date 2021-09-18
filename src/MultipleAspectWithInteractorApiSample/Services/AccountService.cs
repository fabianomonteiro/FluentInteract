using FluentInteract;
using LoggingAspectWithProxyApiSample.Models;
using MultipleAspectWithInteractorApiSample.Queries;
using MultipleAspectWithInteractorApiSample.UseCases;
using System.Threading.Tasks;

namespace LoggingAspectWithProxyApiSample.Services
{
    public class AccountService : IAccountService, ICallerInstance
    {
        private readonly IGetAccountQuery _getAccountQuery;
        private readonly IDisableAccountUseCase _disableAccountUseCase;

        public AccountService(
            IGetAccountQuery getAccountQuery,
            IDisableAccountUseCase disableAccountUseCase)
        {
            _getAccountQuery = getAccountQuery;
            _disableAccountUseCase = disableAccountUseCase;
        }

        public async Task<Account> GetAccount(int id)
        {
            return await 
                _getAccountQuery
                    .SetInput(id)
                    .Execute(this)
                    .GetOutputAsync();
        }

        public async Task DisableAccount(int id)
        {
            await 
                _disableAccountUseCase
                    .SetInput(id)
                    .Execute(this)
                    .GetOutputAsync();
        }
    }
}
