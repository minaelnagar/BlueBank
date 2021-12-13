using AutoMapper;
using BlueBank.Accounts.Api.ApiModels;
using BlueBank.Accounts.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlueBank.Accounts.Api.Controllers
{
    public class CustomersController : BaseApiController
    {
        private readonly IAccountService _accountService;

        private readonly IMapper _mapper;

        public CustomersController(IAccountService accountService, IMapper mapper)
        {
            _accountService = accountService;
            _mapper = mapper;
        }

        [Route("{id}")]
        [HttpGet]
        public async Task<IActionResult> Get(int id)
        {
            var customer = await _accountService.Get(id, true);

            if (customer != null)
            {
                var customerDTO = _mapper.Map<CustomerDTO>(customer);
                return Ok(customerDTO);
            }
            else
            {
                return NotFound();
            }

        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var customers = await _accountService.List(true);
            var customersDTO = _mapper.Map<List<CustomerDTO>>(customers);

            return Ok(customersDTO);
        }
    }
}
