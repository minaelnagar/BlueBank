using BlueBank.Transactions.Api;
using BlueBank.Transactions.Api.ApiModels;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Xunit;

namespace BlueBank.Transactions.Tests.FunctionalTest.Controllers
{
    [Collection("Sequential")]
    public class TransactionCreate : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly HttpClient _client;

        public TransactionCreate(CustomWebApplicationFactory<Startup> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task Returns200()
        {
            CreateTransactionDTO dto = new CreateTransactionDTO()
            {
                AccountId = 1,
                Amount = 10,
                Type = Core.AccountAggregates.TransactionType.Credit
            };

            var content = JsonConvert.SerializeObject(dto);
            var buffer = System.Text.Encoding.UTF8.GetBytes(content);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");


            var result = await _client.PostAsync("/api/Transactions", byteContent);

            Assert.Equal(System.Net.HttpStatusCode.OK, result.StatusCode);
        }
    }
}
