using FluentInteract;
using LoggingAspectWithProxyApiSample.Models;
using System.Threading.Tasks;

namespace LoggingAspectWithProxyApiSample.Services
{
    public interface IAccountService
    {
        Task DisableAccount(int id);

        Task<Account> GetAccount(int id);
    }
}
