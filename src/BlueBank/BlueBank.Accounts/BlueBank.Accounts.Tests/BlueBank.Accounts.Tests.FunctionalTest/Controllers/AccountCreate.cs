using BlueBank.Accounts.Api;
using BlueBank.Accounts.Api.ApiModels;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Xunit;

namespace BlueBank.Accounts.Tests.FunctionalTest.Controllers
{
    [Collection("Sequential")]
    public class AccountCreate : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly HttpClient _client;

        public AccountCreate(CustomWebApplicationFactory<Startup> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task Returns200OnExistingCustomer()
        {
            CreateAccountDTO dto = new CreateAccountDTO()
            {
                CustomerId = 1,
                InitialCredit = 0
            };

            var content = JsonConvert.SerializeObject(dto);
            var buffer = System.Text.Encoding.UTF8.GetBytes(content);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");


            var result = await _client.PostAsync("/api/Accounts", byteContent);

            Assert.Equal(System.Net.HttpStatusCode.OK, result.StatusCode);
        }

        [Fact]
        public async Task Returns404OnNonExistingCustomer()
        {
            CreateAccountDTO dto = new CreateAccountDTO()
            {
                CustomerId = 100,
                InitialCredit = 0
            };

            var content = JsonConvert.SerializeObject(dto);
            var buffer = System.Text.Encoding.UTF8.GetBytes(content);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");


            var result = await _client.PostAsync("/api/Accounts", byteContent);

            Assert.Equal(System.Net.HttpStatusCode.NotFound, result.StatusCode);
        }
    }
}
