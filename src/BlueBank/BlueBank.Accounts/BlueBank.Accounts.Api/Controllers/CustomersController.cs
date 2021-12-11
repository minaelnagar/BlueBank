using BlueBank.Accounts.Api.ApiModels;
using BlueBank.Accounts.Core.CustomerAggregates;
using BlueBank.SharedKernel.Data.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace BlueBank.Accounts.Api.Controllers
{
    public class CustomersController : BaseApiController
    {
        private readonly IRepository<Customer> _repository;


        // GET: api/Customers
        [HttpGet]
        public async Task<IActionResult> List()
        {
            var projectDTOs = (await _repository.ListAsync())
                .Select(customer => new CustomerDTO
                {
                    Id = customer.Id,
                    Name = customer.Name,
                    Surename = customer.Surename,
                    Accounts = customer.Accounts
                })
                .ToList();

            return Ok(projectDTOs);
        }
    }
}
