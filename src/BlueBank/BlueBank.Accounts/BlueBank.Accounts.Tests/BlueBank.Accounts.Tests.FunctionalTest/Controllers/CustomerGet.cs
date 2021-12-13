using Ardalis.HttpClientTestExtensions;
using BlueBank.Accounts.Api;
using BlueBank.Accounts.Api.ApiModels;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace BlueBank.Accounts.Tests.FunctionalTest.Controllers
{
    [Collection("Sequential")]
    public class CustomerGet : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly HttpClient _client;

        public CustomerGet(CustomWebApplicationFactory<Startup> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task ReturnExistingCustomer()
        {
            var result = await _client.GetAndDeserialize<CustomerDTO>("/api/customers/1");

            Assert.Equal(1, result.Id);
        }

        [Fact]
        public async Task Returns404OnNonExistingCustomer()
        {
            var result = await _client.GetAndEnsureNotFound("/api/customers/100");

            Assert.Equal(System.Net.HttpStatusCode.NotFound, result.StatusCode);
        }
    }
}
