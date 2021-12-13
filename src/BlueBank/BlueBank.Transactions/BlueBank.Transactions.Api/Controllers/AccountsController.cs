using AutoMapper;
using BlueBank.Transactions.Api.ApiModels;
using BlueBank.Transactions.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BlueBank.Accounts.Api.Controllers
{
    public class AccountsController : BaseApiController
    {
        private readonly IAccountService _accountService;
        private readonly IMapper _mapper;

        public AccountsController(IAccountService accountService, IMapper mapper)
        {
            _accountService = accountService;
            _mapper = mapper;
        }


        // GET: api/Accounts
        [Route("{id}")]
        [HttpGet]
        public async Task<IActionResult> Get(int id)
        {
            var account = await _accountService.GetAccount(id);

            if (account != null)
            {

                var projectDTOs = _mapper.Map<AccountDTO>(account);
                return Ok(projectDTOs);
            }
            else
            {
                return NotFound();
            }

        }
    }

}
