using BlueBank.Accounts.Api.ApiModels;
using BlueBank.Accounts.Core.Interfaces;
using BlueBank.SharedKernel.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using static Microsoft.AspNetCore.Http.StatusCodes;

namespace BlueBank.Accounts.Api.Controllers
{
    public class AccountsController : BaseApiController
    {
        private readonly IAccountService _accountService;

        public AccountsController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [ProducesResponseType(Status200OK)]
        [ProducesResponseType(Status404NotFound)]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateAccountDTO request)
        {
            var result = await _accountService.OpenNewCurrentAccount(request.CustomerId, request.InitialCredit);

            if (!result.DidFail)
            {
                return Ok();
            }
            else
            {
                switch (result.Error)
                {
                    case BusinessError.CustomerNotFound:
                        return NotFound("Customer not found");
                    default:
                        return BadRequest("Unknow error");
                }
            }
        }
    }
}
