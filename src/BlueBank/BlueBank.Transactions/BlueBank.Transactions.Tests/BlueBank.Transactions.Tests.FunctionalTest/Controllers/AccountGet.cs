using Ardalis.HttpClientTestExtensions;
using BlueBank.Transactions.Api;
using BlueBank.Transactions.Api.ApiModels;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace BlueBank.Transactions.Tests.FunctionalTest.Controllers
{
    [Collection("Sequential")]
    public class AccountGet : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly HttpClient _client;

        public AccountGet(CustomWebApplicationFactory<Startup> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task ReturnExistingAccount()
        {
            var result = await _client.GetAndDeserialize<AccountDTO>("/api/accounts/1");

            Assert.Equal(1, result.Id);
        }

        [Fact]
        public async Task Returns404OnNonExistingAccount()
        {
            var result = await _client.GetAndEnsureNotFound("/api/accounts/100");

            Assert.Equal(System.Net.HttpStatusCode.NotFound, result.StatusCode);
        }
    }
}
