using FluentInteract;
using LoggingAspectWithProxyApiSample.Models;
using System.Threading.Tasks;

namespace LoggingAspectWithProxyApiSample.Repositories
{
    public interface IAccountRepository
    {
        Task<Account> GetAccount(int id);

        Task SaveAccount(Account account);
    }
}
