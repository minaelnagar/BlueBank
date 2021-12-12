using BlueBank.Transactions.Api.ApiModels;
using BlueBank.Transactions.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using static Microsoft.AspNetCore.Http.StatusCodes;

namespace BlueBank.Accounts.Api.Controllers
{
    public class TransactionsController : BaseApiController
    {
        private readonly IAccountService _accountService;

        public TransactionsController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [ProducesResponseType(Status200OK)]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateTransactionDTO request)
        {
            var result = await _accountService.CreateNewTransaction(request.AccountId, request.Amount, request.Type);

            if (!result.DidFail)
            {
                return Ok();
            }
            else
            {
                switch (result.Error)
                {
                    default:
                        return BadRequest("Unknow error");
                }
            }
        }
    }
}
