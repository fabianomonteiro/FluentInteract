using FluentInteract;
using LoggingAspectWithProxyApiSample.Repositories;
using System.Threading.Tasks;

namespace MultipleAspectWithInteractorApiSample.UseCases
{
    public class DisableAccountUseCase : Interactor<int, VoidOutput>, IDisableAccountUseCase
    {
        private readonly IAccountRepository _accountRepository;

        public DisableAccountUseCase(IAccountRepository accountRepository, IAspectWeaver aspectWeaver) : base(aspectWeaver)
        {
            _accountRepository = accountRepository;
        }

        protected async override Task<VoidOutput> ImplementExecute(int input)
        {
            var account = await _accountRepository.GetAccount(input);

            account.Disabled = true;

            await _accountRepository.SaveAccount(account);

            return VoidOutput.Instance;
        }
    }
}
