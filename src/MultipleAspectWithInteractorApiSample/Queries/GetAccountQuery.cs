using FluentInteract;
using LoggingAspectWithProxyApiSample.Models;
using System;
using System.Threading.Tasks;

namespace MultipleAspectWithInteractorApiSample.Queries
{
    public class GetAccountQuery : Interactor<int, Account>, IGetAccountQuery
    {
        public GetAccountQuery(IAspectWeaver aspectWeaver) : base(aspectWeaver) { }

        protected async override Task<Account> ImplementExecute(int input)
        {
            return await Task.FromResult(new Account
            {
                Id = input,
                Name = "Test",
                Disabled = false,
                Created = DateTime.UtcNow
            });
        }
    }
}
