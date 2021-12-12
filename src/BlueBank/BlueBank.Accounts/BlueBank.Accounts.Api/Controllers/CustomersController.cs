using Ardalis.Specification;
using AutoMapper;
using BlueBank.Accounts.Api.ApiModels;
using BlueBank.Accounts.Core.CustomerAggregates;
using BlueBank.SharedKernel.Data.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlueBank.Accounts.Api.Controllers
{
    public class CustomersController : BaseApiController
    {
        private readonly IReadRepository<Customer> _repository;
        private readonly IMapper _mapper;

        public CustomersController(IReadRepository<Customer> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }


        // GET: api/Customers
        [HttpGet]
        public async Task<IActionResult> List()
        {
            var projects = await _repository.ListAsync(new CustomerWithAccountsSpecification());
            var projectDTOs = _mapper.Map<List<CustomerDTO>>(projects);

            return Ok(projectDTOs);
        }
    }

    public class CustomerWithAccountsSpecification : Specification<Customer>
    {
        public CustomerWithAccountsSpecification()
        {
            Query
                .Include(customer => customer.Accounts);
        }
    }
}
