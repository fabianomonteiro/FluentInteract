using LoggingAspectWithProxyApiSample.Models;
using LoggingAspectWithProxyApiSample.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace LoggingAspectWithProxyApiSample.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _service;

        public AccountController(IAccountService service) => _service = service;

        [HttpGet]
        [Route("GetAccount/{id}")]
        public async Task<Account> Get(int id) => await _service.GetAccount(id);

        [HttpPost]
        [Route("DisableAccount/{id}")]
        public async Task DisableAccount(int id) => await _service.DisableAccount(id);
    }
}