using FluentInteract;
using LoggingAspectWithProxyApiSample.Models;
using MultipleAspectWithInteractorApiSample.Commands;
using MultipleAspectWithInteractorApiSample.Queries;
using System.Threading.Tasks;

namespace LoggingAspectWithProxyApiSample.Repositories
{
    public class AccountRepository : IAccountRepository, ICallerInstance
    {
        private readonly IGetAccountQuery _getAccountQuery;
        private readonly IUpdateAccountCommand _updateAccountCommand;

        public AccountRepository(
            IGetAccountQuery getAccountQuery,
            IUpdateAccountCommand updateAccountCommand)
        {
            _getAccountQuery = getAccountQuery;
            _updateAccountCommand = updateAccountCommand;
        }

        public async Task<Account> GetAccount(int id)
        {
            return await 
                _getAccountQuery
                    .SetInput(id)
                    .Execute(this)
                    .GetOutputAsync();
        }

        public async Task SaveAccount(Account account)
        {
            await 
                _updateAccountCommand
                    .SetInput(account)
                    .Execute(this)
                    .GetOutputAsync();
        }
    }
}
